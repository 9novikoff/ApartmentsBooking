using ApartmentsBooking.DAL.Entities;
using ApartmentsBooking.DTO;
using AutoMapper;

namespace ApartmentsBooking;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<City, CityDto>();
        CreateMap<CityDto, City>();

        CreateMap<Country, CountryDto>();
        CreateMap<CountryDto, Country>();

        CreateMap<Apartment, ApartmentDto>();
        CreateMap<ApartmentDto, Apartment>();

        CreateMap<Booking, BookingDto>();
        CreateMap<BookingDto, Booking>();

        CreateMap<BookingNoUserDto, BookingDto>();
    }
}