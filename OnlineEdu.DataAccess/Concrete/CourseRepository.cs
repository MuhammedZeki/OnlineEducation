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
    public class CourseRepository : GenericRepository<Course>, ICourseRepository
    {
        private readonly OnlineEduContext _xcontext;
        public CourseRepository(OnlineEduContext _context) : base(_context)
        {
            _xcontext = _context;
        }

        public List<Course> GetCoursesWithCategories()
        {
            return _xcontext.Courses.Include( x => x.CourseCategory).ToList();
        }
    }
}
