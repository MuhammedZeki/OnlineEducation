using OnlineEdu.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineEdu.DataAccess.Abstract
{
    public interface ICourseRepository : IRepository<Course>
    {
        List<Course> GetCoursesWithCategories();
    }
}
