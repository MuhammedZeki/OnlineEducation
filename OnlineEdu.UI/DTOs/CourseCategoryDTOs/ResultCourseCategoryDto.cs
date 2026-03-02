using OnlineEdu.UI.DTOs.CourseDTOs;

namespace OnlineEdu.UI.DTOs.CourseCategoryDTOs
{
    public class ResultCourseCategoryDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
        public bool IsShown { get; set; }
        public int CourseId { get; set; }
        public List<ResultCourseDto> Courses { get; set; } //change
    }
}
