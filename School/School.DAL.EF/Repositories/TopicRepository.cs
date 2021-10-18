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
    public class TopicRepository : IRepository<Topic>
    {
        private readonly AcademyContext _context;

        public TopicRepository(AcademyContext context)
        {
            _context = context;
        }
        public async Task Create(Topic item)
        {
            await _context.Topics.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var topic = await _context.Topics.FindAsync(id);
            _context.Topics.Remove(topic);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Topic>> Find(Func<Topic, bool> predicate)
        {
            return await _context.Topics
                           .Where(predicate)
                           .AsQueryable()
                           .ToListAsync();
        }

        public async Task<IEnumerable<Topic>> GetAll()
        {
            return await _context.Topics.ToListAsync();
        }

        public async Task<Topic> GetById(int id)
        {
            return await _context.Topics.FindAsync(id);
        }

        public async Task<PageList<Topic>> GetByPages(QueryOptions options)
        {
            var topicsHowPageList = new PageList<Topic>(_context.Topics.AsQueryable(), options);

            var pageListHowTask = Task.FromResult(topicsHowPageList);
            return await pageListHowTask;
        }

        public async Task Update(Topic item)
        {
            var originalTopic = await _context.Topics.FindAsync(item.Id);

            originalTopic.Description = item.Description;
            originalTopic.Parent = item.Parent;
            originalTopic.ParentId = item.ParentId;
            originalTopic.Title = item.Title;

            await _context.SaveChangesAsync();
        }
    }
}
