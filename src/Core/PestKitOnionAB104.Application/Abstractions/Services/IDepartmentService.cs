using PestKitOnionAB104.Application.DTOs.Department;
using PestKitOnionAB104.Application.DTOs.Departments;

namespace PestKitOnionAB104.Application.Abstractions.Services
{
    public interface IDepartmentService
    {
        Task<ICollection<DepartmentItemDto>> GetAllAsync(int page, int take);
        Task<DepartmentGetDto> GetAsync(int id);
        Task CreateAsync(DepartmentCreateDto departmentCreateDto);
        Task UpdateAsync(int id, DepartmentUpdateDto departmentUpdateDto);
        Task DeleteAsync(int id);
        Task SoftDeleteAsync(int id);
    }
}
