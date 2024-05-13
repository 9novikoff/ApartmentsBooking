using ApartmentsBooking.DAL.Entities;
using ApartmentsBooking.DTO;
using ApartmentsBooking.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApartmentsBooking.Controllers;

[ApiController]
[Route("[controller]")]
public class CitiesController : ControllerBase
{
    private readonly Service<City, CityDto> _service;

    public CitiesController(Service<City, CityDto> service)
    {
        _service = service;
    }
    
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_service.GetAll());
    }
    
    
    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        return Ok(await _service.GetByIdAsync(id));
    }
    
    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Post(CityDto city)
    {
        await _service.AddAsync(city);
        return Ok();
    }
    
    [HttpPut]
    [Authorize]
    [Route("{id}")]
    public async Task<IActionResult> Put(int id, CityDto city)
    {
        var response = await _service.UpdateAsync(id, city);
        if (response.IsValid)
        {
            return Ok();
        }

        return NoContent();
    }
    
    
    [HttpDelete]
    [Authorize]
    public async Task<IActionResult> Delete(int id)
    {
        var response = await _service.DeleteAsync(id);
        if (response.IsValid)
        {
            return Ok();
        }
        
        return NoContent();
    }
}