using OnlineEdu.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineEdu.Business.Abstract
{
    public interface ICourseService: IGenericService<Course>
    {
        List<Course> TGetCoursesWithCategories();
    }
}
