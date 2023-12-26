using PestKitOnionAB104.Application.Abstractions.Repositories;
using PestKitOnionAB104.Application.DTOs.Author;
using PestKitOnionAB104.Application.DTOs.Authors;
using PestKitOnionAB104.Application.DTOs.Employee;

namespace PestKitOnionAB104.Application.Abstractions.Services
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeItemDto>> GetAllPaginatedAsync(int page, int take);
        Task<EmployeeGetDto> GetByIdAsync(int id);
        Task CreateAsync(EmployeeCreateDto employeeCreateDto);
        Task UpdateAsync(int id, EmployeeUpdateDto employeeUpdateDto);
        Task DeleteAsync(int id);
        Task SoftDeleteAsync(int id);
    }
}

