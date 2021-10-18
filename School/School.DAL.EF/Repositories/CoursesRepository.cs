using Microsoft.EntityFrameworkCore;
using School.Core.Models;
using School.Core.Models.Filters;
using School.Core.Models.Pages;
using School.DAL.EF.Contexts;
using School.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace School.DAL.EF.Repositories
{
    public class CoursesRepository : ICourseRepository
    {
        private readonly AcademyContext _context;

        public CoursesRepository(AcademyContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Course>> GetAll()
        {
            return await _context.Courses
                .Include(c => c.Topic)
                .ToListAsync();
        }
        public async Task<Course> GetById(int id)
        {
            return await _context.Courses.FindAsync(id);
        }

        public async Task Create(Course item)
        {
            await _context.Courses.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var item = _context.Courses.FindAsync(id);
            _context.Courses.Remove(item.Result);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Course>> Find(Func<Course, bool> predicate)
        {
            return await _context.Courses
                            .Where(predicate).AsQueryable().ToListAsync();
        }

        public async Task Update(Course item)
        {
            var originalCourse = _context.Courses.Find(item.Id);

            originalCourse.Description = item.Description;
            originalCourse.Program = item.Program;
            originalCourse.Title = item.Title;
            originalCourse.TopicId = item.TopicId;
            originalCourse.Level = item.Level;
            originalCourse.Price = item.Price;
            originalCourse.DurationWeeks = item.DurationWeeks;

            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Course>> Filter(CourseFilter filter)
        {
            var filteredCourses = _context.Courses.AsQueryable();

            if (!string.IsNullOrWhiteSpace(filter.TitleContains))
                filteredCourses = filteredCourses.Where(c =>
                c.Title.Contains(filter.TitleContains));

            if (!string.IsNullOrWhiteSpace(filter.DescriptionContains))
                filteredCourses = filteredCourses.Where(c =>
                c.Description.Contains(filter.DescriptionContains));

            if (!string.IsNullOrWhiteSpace(filter.ProgramContains))
                filteredCourses = filteredCourses.Where(c =>
                c.Program.Contains(filter.ProgramContains));

            if (filter.PriceFrom.HasValue)
                filteredCourses = filteredCourses.Where(c => c.Price >= filter.PriceFrom.Value);

            if (filter.PriceTo.HasValue)
                filteredCourses = filteredCourses.Where(c => c.Price <= filter.PriceTo.Value);

            if (filter.DurationWeeksFrom.HasValue)
                filteredCourses = filteredCourses.Where(c => c.DurationWeeks >= filter.DurationWeeksFrom.Value);

            if (filter.DurationWeeksTo.HasValue)
                filteredCourses = filteredCourses.Where(c => c.DurationWeeks <= filter.DurationWeeksTo.Value);

            return await filteredCourses.ToListAsync();
        }

        public async Task<PageList<Course>> GetByPages(QueryOptions options)
        {
            var coursesHowPageList = new PageList<Course>(_context.Courses
                .Include(c => c.Topic).AsQueryable(), options);

            var pageListHowTask = Task.FromResult(coursesHowPageList);
            return await pageListHowTask;
        }
    }
}