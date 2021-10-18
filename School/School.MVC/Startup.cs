using AutoMapper;
using ElmahCore.Mvc;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using School.BLL.Extensions;
using School.Core.Models;
using School.DAL.EF.Contexts;
using School.DAL.EF.Extensions;
using School.MVC.Configuration;
using School.MVC.Filters;
using School.MVC.Mapper;
using School.MVC.Middleware;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace School.MVC
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AcademyContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddIdentity<IdentityUser, IdentityRole>(options => { options.SignIn.RequireConfirmedAccount = true; options.User.RequireUniqueEmail = true; })
                .AddDefaultUI()
                .AddEntityFrameworkStores<AcademyContext>()
                .AddDefaultTokenProviders();
            services.AddControllersWithViews();

            services.AddBusinessLogicServicesFromDalEF();
            services.AddBusinessLogicServicesFromBLL();

            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });
            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.Configure<SecurityOptions>(
                   Configuration.GetSection(SecurityOptions.SectionTitle));

            services.AddRazorPages();

            services.AddElmah();

            services.AddMvc(options =>
                            options.Filters.Add<GlobalExceptionFilter>()
                        );
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider, IOptions<SecurityOptions> securityOptions)
        {
            app.UseMiddleware<CustomExceptionMiddleware>();
            if (env.IsDevelopment())
            {
                //app.UseDeveloperExceptionPage();
                //app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });

            //CreateRoles(serviceProvider, securityOptions).Wait();

            app.UseElmah();
        }

        private async Task CreateRoles(IServiceProvider serviceProvider, IOptions<SecurityOptions> securityOptions)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            var roles = new[] { "admin", "manager", "student" };

            foreach (var roleName in roles)
            {
                roleManager.CreateAsync(new IdentityRole
                {
                    Name = roleName,
                    NormalizedName = roleName.ToUpper()
                }).Wait();
            }

            var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();

            var adminUser = await userManager.FindByEmailAsync(Configuration["Security:AdminUserEmail"]);
            if (adminUser != null)
            {
                await userManager.AddToRoleAsync(adminUser, "ADMIN");
            }

            var managerUser = await userManager.FindByEmailAsync(Configuration["Security:ManagerUserEmail"]);
            if (managerUser != null)
            {
                await userManager.AddToRoleAsync(managerUser, "MANAGER");
            }

            var value = userManager.Users.Where(email => email.Email != Configuration["Security:ManagerUserEmail"]
            && email.Email != Configuration["Security:AdminUserEmail"]).Select(users => users).ToList();
            foreach (var student in value)
            {
                await userManager.AddToRoleAsync(student, "STUDENT");
            }
        }
    }
}