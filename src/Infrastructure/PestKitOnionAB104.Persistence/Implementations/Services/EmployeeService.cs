using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PestKitOnionAB104.Application.Abstractions.Repositories;
using PestKitOnionAB104.Application.Abstractions.Services;
using PestKitOnionAB104.Application.DTOs.Department;
using PestKitOnionAB104.Application.DTOs.Employee;
using PestKitOnionAB104.Application.DTOs.Position;
using PestKitOnionAB104.Domain.Entities;

namespace PestKitOnionAB104.Persistence.Implementations.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IPositionRepository _positionRepository;
        private readonly IEmployeeRepository _repository;
        private readonly IMapper _mapper;

        public EmployeeService(IEmployeeRepository repository, IDepartmentRepository departmentRepository, IMapper mapper, IPositionRepository positionRepository)
        {
            _departmentRepository = departmentRepository;
            _positionRepository = positionRepository;
            _mapper = mapper;
            _repository = repository;
        }

        public async Task CreateAsync(EmployeeCreateDto employeeCreateDto)
        {
            await _repository.AddAsync(_mapper.Map<Employee>(employeeCreateDto));

            await _repository.SaveChangesAsync();
        }

        

        public async Task<IEnumerable<EmployeeItemDto>> GetAllPaginatedAsync(int page, int take)
        {
            IEnumerable<EmployeeItemDto> dtos = _mapper.Map<IEnumerable<EmployeeItemDto>>(
                await _repository.GetAllWhere(skip: (page - 1) * take, take: take, IsTracking: false).ToArrayAsync()
                );
            return dtos;
        }
        public async Task<EmployeeGetDto> GetByIdAsync(int id)
        {
            Employee employee = await _repository.GetByIdAsync(id, includes: new string[] { nameof(Employee.Department), nameof(Employee.Position) });
            EmployeeGetDto dto = _mapper.Map<EmployeeGetDto>(employee);
            return dto;
        }

       


        public async Task UpdateAsync(int id, EmployeeUpdateDto employeeUpdateDto)
        {
            Employee employee = await _repository.GetByIdAsync(id);

            if (employee is null) throw new Exception("Not found");

            employee.Name = employeeUpdateDto.Name;

            _repository.Update(employee);
            await _repository.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            Employee employee = await _repository.GetByIdAsync(id);

            if (employee is null) throw new Exception("Not found");

            _repository.Delete(employee);
            await _repository.SaveChangesAsync();
        }
        public async Task SoftDeleteAsync(int id)
        {
            Employee employee = await _repository.GetByIdAsync(id);
            if (employee is null) throw new Exception("Not found");
            _repository.SoftDelete(employee);
            await _repository.SaveChangesAsync();
        }
    }
}
