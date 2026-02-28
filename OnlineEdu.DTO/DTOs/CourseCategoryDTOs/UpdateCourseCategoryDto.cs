namespace OnlineEdu.DTO.DTOs.CourseCategoryDTOs
{
    public class UpdateCourseCategoryDto
    {
        public int CourseCategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
        public bool IsShown { get; set; }
        public int CourseId { get; set; }
    }
}
