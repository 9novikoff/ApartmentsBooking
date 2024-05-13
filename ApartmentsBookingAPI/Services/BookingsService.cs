using System.Security.Claims;
using ApartmentsBooking.DAL;
using ApartmentsBooking.DAL.Entities;
using ApartmentsBooking.DAL.Repositories;
using ApartmentsBooking.DTO;
using AutoMapper;

namespace ApartmentsBooking.Services;

class BookingsService : Service<Booking, BookingDto>
{
    public BookingsService(IRepository<Booking> repository, IMapper mapper) : base(repository, mapper)
    {
    }

    public async Task AddAsync(BookingNoUserDto booking, ClaimsPrincipal claims)
    {
        var bookingDto = _mapper.Map<BookingDto>(booking);
        bookingDto.UserId = claims.Claims.First(c => c.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier").Value;
        await AddAsync(bookingDto);
    }
}