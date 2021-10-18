using System.Collections.Generic;
using System.Linq;

namespace School.Core.Models.Pages
{
    public class PageList<T> : List<T>
    {
        public PageList(IQueryable<T> query, QueryOptions options = null)
        {
            CurrentPage = options.CurrentPage;
            PageSize = options.PageSize;
            TotalPages = (double)query.Count() / (double)PageSize;
            AddRange(query.Skip((CurrentPage - 1) * PageSize).Take(PageSize));
        }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public double TotalPages { get; set; }
        public bool HasPreviosPage => CurrentPage > 1;
        public bool HasNextPage => CurrentPage < TotalPages;
    }
}
