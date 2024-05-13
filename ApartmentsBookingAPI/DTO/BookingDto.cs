using System.Security.Claims;
using ApartmentsBooking.DAL.Entities;
using Microsoft.AspNetCore.Identity;

namespace ApartmentsBooking.DTO;

public class BookingDto
{
    public int ApartmentId { get; set; }
    public string UserId { get; set; }
    public DateTime TimeFrom { get; set; }
    public DateTime TimeTo { get; set; }
}