namespace ApartmentsBooking.Services;

public class ServiceResponse<T>
{
    public bool IsValid = true;
    public T? Value { get; set; }
    public string? ErrorMessage;
}