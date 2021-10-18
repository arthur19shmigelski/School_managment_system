using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace School.PerfomanceTests
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/sync", async context =>
                {
                   
                    context.Response.WriteAsync(RunSync().ToString());
                });
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/async", async context =>
                {
                    RunAsync();
                });
            });
        }

        private void RunAsync()
        {
            
        }

        private double RunSync()
        {
            using (var client = new HttpClient())
            {
                var start = client.Timeout.TotalMilliseconds;
                client.GetAsync("https://localhost:44302/api/students");
                var end = client.Timeout.TotalMilliseconds;
                return end - start;
            }
        }
    }
}
