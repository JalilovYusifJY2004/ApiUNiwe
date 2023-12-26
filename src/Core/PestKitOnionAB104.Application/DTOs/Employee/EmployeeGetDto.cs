using PestKitOnionAB104.Application.DTOs.Departments;
using PestKitOnionAB104.Application.DTOs.Positions;

namespace PestKitOnionAB104.Application.DTOs.Employee
{
    public record EmployeeGetDto(int Id, string Name, int DepartmentId, IncludeDepartmentDto Department, int PositionId, IncludePositionDto Position);
}
