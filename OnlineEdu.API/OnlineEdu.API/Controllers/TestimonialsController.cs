using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.Business.Abstract;
using OnlineEdu.DTO.DTOs.TestimonialDTOs;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialsController(IGenericService<Testimonial> _testimonailService, IMapper _mapper) : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_testimonailService.TGetList());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_testimonailService.TGetById(id));
        }



        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _testimonailService.TDelete(id);
            return Ok("Silindi!");
        }

        [HttpPost]
        public IActionResult Create(CreateTestimonialDto createTestimonialDto)
        {
            var newValue = _mapper.Map<Testimonial>(createTestimonialDto);
            _testimonailService.TCreate(newValue);
            return Ok("Eklindi");
        }

        [HttpPut]
        public IActionResult Update(UpdateTestimonialDto updateTestimonialDto)
        {
            var newValue = _mapper.Map<Testimonial>(updateTestimonialDto);
            _testimonailService.TUpdate(newValue);
            return Ok("Güncellendi");
        }
    }
}
