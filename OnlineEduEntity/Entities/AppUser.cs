using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineEdu.Entity.Entities
{
    public class AppUser: IdentityUser<int>
    {
        public string FirstName{ get; set; }
        public string LastName { get; set; }
        public string? ImageUrl{ get; set; }

        public List<Course> Courses { get; set; } // Öğretmenin verdiği tüm kurslar
        public List<CourseRegister> CourseRegisters { get; set; } // Öğrencinin tüm kayıtları
    }
}
