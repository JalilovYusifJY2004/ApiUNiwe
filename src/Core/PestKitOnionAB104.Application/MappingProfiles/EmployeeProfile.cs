using AutoMapper;
using PestKitOnionAB104.Application.DTOs.Employee;
using PestKitOnionAB104.Domain.Entities;

namespace PestKitOnionAB104.Application.MappingProfiles
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Employee, EmployeeItemDto>().ReverseMap();
            CreateMap<Employee, EmployeeGetDto>().ReverseMap();
            CreateMap<EmployeeCreateDto, Employee>().ReverseMap();
        }
    }
}
