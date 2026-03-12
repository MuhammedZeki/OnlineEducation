using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineEdu.Entity.Entities
{
    public class CourseRegister // öğrencinin kursa kayıt olduğu tablo
    {
    
        public int CourseRegisterId { get; set; }

        public int AppUserId{ get; set; } //StudentId
        public AppUser AppUser { get; set; }

        public int CourseId { get; set; }
        public Course Course { get; set; }

    }
}
