using OnlineEdu.UI.DTOs.BlogDTOs;

namespace OnlineEdu.UI.DTOs.BlogCategoryDTOs
{
    public class ResultBlogCategoryDto
    {
        public int BlogCategoryId { get; set; }
        public string Name { get; set; }

        public int BlogId { get; set; }
        public List<ResultBlogDto> Blogs { get; set; }
    }
}
