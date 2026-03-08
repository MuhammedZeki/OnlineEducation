using Microsoft.EntityFrameworkCore;
using OnlineEdu.DataAccess.Abstract;
using OnlineEdu.DataAccess.Repositories;
using OnlineEdu.DTO.Context;
using OnlineEdu.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineEdu.DataAccess.Concrete
{
    public class BlogRepository : GenericRepository<Blog>, IBlogRepository
    {
        private readonly OnlineEduContext _xcontext;
        public BlogRepository(OnlineEduContext _context) : base(_context)
        {
            _xcontext = _context;
        }

        public List<Blog> GetBlogsWithCategories()
        {
            return _xcontext.Blogs.Include(x =>x.BlogCategory).ToList();
        }
    }
}
