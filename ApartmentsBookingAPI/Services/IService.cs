using ApartmentsBooking.DTO;

namespace ApartmentsBooking.Services;

public interface IService<T>
{
    public Task AddAsync(T entity);
    public IEnumerable<T> GetAll();
    public Task<T> GetByIdAsync(object id);
    public Task<ServiceResponse<T>> UpdateAsync(object id, T city);
    public Task<ServiceResponse<T>> DeleteAsync(object id);



}