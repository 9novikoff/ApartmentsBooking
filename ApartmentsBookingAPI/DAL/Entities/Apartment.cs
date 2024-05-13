using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApartmentsBooking.DAL.Entities;

public class Apartment
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public int CityId { get; set; }
    public decimal PrizePerHour { get; set; }
    public ApartmentType ApartmentType { get; set; }
    public bool IsAvailable { get; set; }
    public string? Description { get; set; }
    
    public City City { get; set; }
}