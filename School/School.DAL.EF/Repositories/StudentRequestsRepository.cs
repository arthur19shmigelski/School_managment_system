using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.DynamicLinq;
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
    public class StudentRequestsRepository : IRepository<StudentRequest>
    {
        private readonly AcademyContext _context;

        public StudentRequestsRepository(AcademyContext context)
        {
            _context = context;
        }

        public async Task Create(StudentRequest item)
        {
            item.Course = null;
            item.Student = null;

            await _context.StudentRequests.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            StudentRequest item = await _context.StudentRequests.FindAsync(id);
            _context.StudentRequests.Remove(item);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<StudentRequest>> Find(Func<StudentRequest, bool> predicate)
        {
            return await _context.StudentRequests
                            .Where(predicate)
                            .AsQueryable()
                            .ToListAsync();
        }

        public async Task<IEnumerable<StudentRequest>> GetAll()
        {
            return await _context.StudentRequests
                .Include(r => r.Student)
                .Include(r => r.Course)
                .ToListAsync();
        }

        public async Task<StudentRequest> GetById(int id)
        {
            return await _context.StudentRequests.Include(x => x.Student).Include(x=>x.Course).FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<PageList<StudentRequest>> GetByPages(QueryOptions options)
        {
            var requestHowPageList = new PageList<StudentRequest>(_context.StudentRequests
                .Include(r => r.Student)
                .Include(r => r.Course).AsQueryable(), options);

            var pageListHowTask = Task.FromResult(requestHowPageList);
            return await pageListHowTask;
        }

        public async Task Update(StudentRequest item)
        {
            var originalStudentRequest = await _context.StudentRequests.FindAsync(item.Id);

            originalStudentRequest.Comments = item.Comments;
            originalStudentRequest.CourseId = item.CourseId;
            originalStudentRequest.Created = item.Created;
            originalStudentRequest.Status = item.Status;
            originalStudentRequest.StudentId = item.StudentId;
            originalStudentRequest.Updated = item.Updated;

            await _context.SaveChangesAsync();
        }
    }
}