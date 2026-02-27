using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.Business.Abstract;
using OnlineEdu.DTO.DTOs.AboutDTOs;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AboutsController(IGenericService<About> _aboutService, IMapper _mapper) : ControllerBase
{

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_aboutService.TGetList());
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        return Ok(_aboutService.TGetById(id));
    }


        
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _aboutService.TDelete(id);
        return Ok("Silindi!");
    }

    [HttpPost]
    public IActionResult Create(CreateAboutDto createAboutDto)
    {
        var newValue = _mapper.Map<About>(createAboutDto);
        _aboutService.TCreate(newValue);
        return Ok("Eklindi");
    }

    [HttpPut]
    public IActionResult Update(UpdateAboutDto updateAboutDto)
    {
        var newValue = _mapper.Map<About>(updateAboutDto);
        _aboutService.TUpdate(newValue);
        return Ok("Güncellendi");
    }
}
