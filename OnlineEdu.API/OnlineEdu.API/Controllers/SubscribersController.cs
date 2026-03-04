using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.Business.Abstract;
using OnlineEdu.DTO.DTOs.SubscriberDTOs;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscribersController(IGenericService<Subscriber> _subcriberService, IMapper _mapper) : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_subcriberService.TGetList());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_subcriberService.TGetById(id));
        }



        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _subcriberService.TDelete(id);
            return Ok("Silindi!");
        }

        [HttpPost]
        public IActionResult Create(CreateSubscriberDto createSubscriberDto)
        {
            var newValue = _mapper.Map<Subscriber>(createSubscriberDto);
            _subcriberService.TCreate(newValue);
            return Ok("Eklindi");
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, UpdateSubscriberDto updateSubscriberDto)
        {   
            if(id != updateSubscriberDto.SubscriberId)
            {
                return BadRequest("Id'ler uyuşmuyor!");
            }
            var newValue = _mapper.Map<Subscriber>(updateSubscriberDto);
            _subcriberService.TUpdate(newValue);
            return Ok("Güncellendi");
        }
    }
}
