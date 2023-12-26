using AutoMapper;
using PestKitOnionAB104.Application.DTOs.Department;
using PestKitOnionAB104.Application.DTOs.Departments;
using PestKitOnionAB104.Domain.Entities;

namespace PestKitOnionAB104.Application.MappingProfiles
{
    public class DepartmentProfile : Profile
    {
        public DepartmentProfile()
        {
            CreateMap<Department, DepartmentItemDto>();
            CreateMap<Department, DepartmentGetDto>();
            CreateMap<BlogCreateDto, Department>();
            CreateMap<Department, IncludeDepartmentDto>();
        }
    }
}
