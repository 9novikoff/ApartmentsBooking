using System.Security.Claims;
using ApartmentsBooking.DAL.Entities;
using ApartmentsBooking.DTO;
using ApartmentsBooking.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApartmentsBooking.Controllers;

[ApiController]
[Route("[controller]")]
public class CountriesController : ControllerBase
{
    private readonly Service<Country, CountryDto> _service;

    public CountriesController(Service<Country, CountryDto> service)
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
    public async Task<IActionResult> Post(CountryDto country)
    {
        await _service.AddAsync(country);
        return Ok();
    }
    
    [HttpPut]
    [Authorize]
    [Route("{id}")]
    public async Task<IActionResult> Put(int id, CountryDto country)
    {
        var response = await _service.UpdateAsync(id, country);
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