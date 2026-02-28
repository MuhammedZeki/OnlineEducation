using AutoMapper;
using OnlineEdu.DTO.DTOs.CourseCategoryDTOs;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.API.Mapping
{
    public class CourseCategoryMapping:Profile
    {
        public CourseCategoryMapping()
        {
            CreateMap<ResultCourseCategoryDto, CourseCategory>().ReverseMap();
            CreateMap<CreateCourseCategoryDto, CourseCategory>().ReverseMap();
            CreateMap<UpdateCourseCategoryDto, CourseCategory>().ReverseMap();
        }
    }
}
