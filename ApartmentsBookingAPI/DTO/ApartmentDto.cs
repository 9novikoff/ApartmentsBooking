using ApartmentsBooking.DAL.Entities;

namespace ApartmentsBooking.DTO;

public class ApartmentDto
{
    public int CityId { get; set; }
    public decimal PrizePerHour { get; set; }
    public ApartmentType ApartmentType { get; set; }
    public bool IsAvailable { get; set; }
    public string? Description { get; set; }
}