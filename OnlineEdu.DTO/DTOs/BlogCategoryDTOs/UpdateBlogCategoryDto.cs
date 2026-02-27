using OnlineEdu.DTO.DTOs.BlogDTOs;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.DTO.DTOs.BlogCategoryDTOs;
public class UpdateBlogCategoryDto
{
    public int BlogCategoryId { get; set; }
    public string Name { get; set; }

    public int BlogId { get; set; }

}

