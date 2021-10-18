using Microsoft.EntityFrameworkCore;
using School.Core.Models;
using School.Core.Models.Pages;
using School.DAL.EF.Contexts;
using School.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace School.DAL.EF.Repositories
{
    public class TeachersRepository : IRepository<Teacher>
    {
        private readonly AcademyContext _context;
        public TeachersRepository(AcademyContext context)
        {
            _context = context;
        }

        public async Task Create(Teacher item)
        {
            await _context.Teachers.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var teacher = await _context.Teachers.FindAsync(id);

            var groups = _context.StudentGroups.Where(c => c.TeacherId == id).Select(c => c).ToList();

            foreach (var item in groups)
            {
                item.TeacherId = null;
                item.Teacher = null;
                _context.StudentGroups.Update(item);
            }

            _context.Teachers.Remove(teacher);

            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Teacher>> Find(Func<Teacher, bool> predicate)
        {
            return await _context.Teachers
                                        .Where(predicate)
                                        .AsQueryable()
                                        .ToListAsync();
        }

        public async Task<IEnumerable<Teacher>> GetAll()
        {
            return await _context.Teachers.ToListAsync();
        }

        public async Task<Teacher> GetById(int id)
        {
            return  await _context.Teachers.FindAsync(id);
        }

        public async Task<PageList<Teacher>> GetByPages(QueryOptions options)
        {
            var teachersHowPageList = new PageList<Teacher>(_context.Teachers.AsQueryable(), options);

            var pageListHowTask = Task.FromResult(teachersHowPageList);
            return await pageListHowTask;
        }

        public async Task Update(Teacher item)
        {
            var originalTeacher = await _context.Teachers.FindAsync(item.Id);
            
            originalTeacher.Bio = item.Bio;
            originalTeacher.Age = item.Age;
            originalTeacher.Email = item.Email;
            originalTeacher.FirstName = item.FirstName;
            originalTeacher.LastName = item.LastName;
            originalTeacher.LinkToProfile = item.LinkToProfile;
            originalTeacher.Phone = item.Phone;

            if(item.Photo.Length == 0)
                await _context.SaveChangesAsync();
            else
            {
                originalTeacher.Photo = item.Photo;
                await _context.SaveChangesAsync();
            }
        }
    }
}