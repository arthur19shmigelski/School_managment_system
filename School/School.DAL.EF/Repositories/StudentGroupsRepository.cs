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
    public class StudentGroupsRepository : IRepository<Group>
    {
        private readonly AcademyContext _context;

        public StudentGroupsRepository(AcademyContext context)
        {
            _context = context;
        }

        public async Task<Group> GetById(int id)
        {
            return await _context.StudentGroups.Include(g => g.Students).FirstAsync(g => g.Id == id);
        }
        public async Task<IEnumerable<Group>> GetAll()
        {
            return await _context.StudentGroups.Include(g => g.Teacher).ToListAsync();
        }

        public async Task Update(Group item)
        {
            var originalStudentGroup = _context.StudentGroups.Find(item.Id);

            originalStudentGroup.Course = item.Course;
            originalStudentGroup.CourseId = item.CourseId;
            originalStudentGroup.StartDate = item.StartDate;
            originalStudentGroup.Status = item.Status;
            originalStudentGroup.Students = item.Students;
            originalStudentGroup.Teacher = item.Teacher;
            originalStudentGroup.TeacherId = item.TeacherId;
            originalStudentGroup.Title = item.Title;

            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Group>> Find(Func<Group, bool> predicate)
        {
            return await _context.StudentGroups
                           .Where(predicate)
                           .AsQueryable()
                           .ToListAsync();
        }

        public async Task Create(Group item)
        {
            await _context.StudentGroups.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            Group item = await _context.StudentGroups.FindAsync(id);
            _context.StudentGroups.Remove(item);
            await _context.SaveChangesAsync();
        }

        public async Task<PageList<Group>> GetByPages(QueryOptions options)
        {
            var groupHowPageList = new PageList<Group>( _context.StudentGroups.Include(g => g.Teacher).AsQueryable(), options);

            var pageListHowTask = Task.FromResult(groupHowPageList);
            return await pageListHowTask;
        }
    }
}