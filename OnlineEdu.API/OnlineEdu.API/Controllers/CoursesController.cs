using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.Business.Abstract;
using OnlineEdu.DTO.DTOs.CourseDTOs;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController(
        ICourseService _courseService,
        IMapper _mapper
    ) : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var values = _courseService.TGetCoursesWithCategories();
            var courses = _mapper.Map<List<ResultCourseDto>>(values);
            return Ok(courses);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_courseService.TGetById(id));
        }



        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _courseService.TDelete(id);
            return Ok("Silindi!");
        }

        [HttpPost]
        public IActionResult Create(CreateCourseDto createCourseDto)
        {
            var newValue = _mapper.Map<Course>(createCourseDto);
            _courseService.TCreate(newValue);
            return Ok("Eklindi");
        }

        [HttpPut]
        public IActionResult Update(UpdateCourseDto updateCourseDto)
        {
            var newValue = _mapper.Map<Course>(updateCourseDto);
            _courseService.TUpdate(newValue);
            return Ok("Güncellendi");
        }

        [HttpGet("getActiveCourse")]
        public IActionResult GetActiveCourse()
        {
            var values = _courseService.TGetFilteredList(x=>x.IsShown);
            var courses = _mapper.Map<List<ResultCourseDto>>(values);
            return Ok(courses);
        }
    }
}
