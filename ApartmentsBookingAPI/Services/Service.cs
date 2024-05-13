using ApartmentsBooking.DAL;
using ApartmentsBooking.DAL.Entities;
using ApartmentsBooking.DAL.Repositories;
using ApartmentsBooking.DTO;
using AutoMapper;

namespace ApartmentsBooking.Services;

public class Service<T, TDto> : IService<TDto> where T : class
{
    protected readonly IRepository<T> _repository;
    protected readonly IMapper _mapper;

    public Service(IRepository<T> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    
    public async Task AddAsync(TDto entity)
    {
        await _repository.AddAsync(_mapper.Map<T>(entity));
        await _repository.SaveAsync();
    }

    public IEnumerable<TDto> GetAll()
    {
        return _repository.GetAll().Select(c => _mapper.Map<TDto>(c));
    }

    public async Task<TDto> GetByIdAsync(object id)
    {
        var entity = await _repository.GetByIdAsync(id);
        return _mapper.Map<TDto>(entity);
    }
    
    public async Task<ServiceResponse<TDto>> UpdateAsync(object id, TDto entity)
    {
        var isValid = await ValidateId(id);
        if (!isValid)
        {
            return new ServiceResponse<TDto>
            {
                IsValid = false,
                ErrorMessage = ErrorMessages.NoRecordsWithId
            };
        }
        
        await _repository.Update(id, _mapper.Map<T>(entity));
        await _repository.SaveAsync();
        
        return new ServiceResponse<TDto>()
        {
            IsValid = true
        };
    }
    
    public async Task<ServiceResponse<TDto>> DeleteAsync(object id)
    {
        var isValid = await ValidateId(id);
        if (!isValid)
        {
            return new ServiceResponse<TDto>
            {
                IsValid = false,
                ErrorMessage = ErrorMessages.NoRecordsWithId
            };
        }
        
        await _repository.DeleteAsync(id);
        await _repository.SaveAsync();

        return new ServiceResponse<TDto>()
        {
            IsValid = true
        };
    }

    public async Task<bool> ValidateId(object id)
    {
        return await _repository.IsExistingId(id);
    }
}