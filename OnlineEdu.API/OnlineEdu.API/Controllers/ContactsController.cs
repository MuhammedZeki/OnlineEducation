using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.Business.Abstract;
using OnlineEdu.DTO.DTOs.ContactDTOs;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController(IGenericService<Contact> _contactService, IMapper _mapper) : ControllerBase
    {
        [HttpGet]
    public IActionResult Get()
    {
        return Ok(_contactService.TGetList());
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        return Ok(_contactService.TGetById(id));
    }


        
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _contactService.TDelete(id);
        return Ok("Silindi!");
    }

    [HttpPost]
    public IActionResult Create(CreateContactDto createContactDto)
    {
        var newValue = _mapper.Map<Contact>(createContactDto);
        _contactService.TCreate(newValue);
        return Ok("Eklindi");
    }

    [HttpPut]
    public IActionResult Update(UpdateContactDto updateContactDto)
    {
        var newValue = _mapper.Map<Contact>(updateContactDto);
        _contactService.TUpdate(newValue);
        return Ok("Güncellendi");
    }
    }
}
