using ApartmentsBooking.DAL.Entities;
using ApartmentsBooking.DTO;
using ApartmentsBooking.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace ApartmentsBooking.Controllers;

[ApiController]
[Route("[controller]")]
public class ApartmentsController : ControllerBase
{
    private readonly Service<Apartment, ApartmentDto> _service;

    public ApartmentsController(Service<Apartment, ApartmentDto> service)
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
    public async Task<IActionResult> Post(ApartmentDto apartment)
    {
        await _service.AddAsync(apartment);
        return Ok();
    }
    
    [HttpPut]
    [Authorize]
    [Route("{id}")]
    public async Task<IActionResult> Put(int id, ApartmentDto apartment)
    {
        var response = await _service.UpdateAsync(id, apartment);
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