using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PestKitOnionAB104.Application.Abstractions.Repositories;
using PestKitOnionAB104.Application.Abstractions.Services;
using PestKitOnionAB104.Application.DTOs.Author;
using PestKitOnionAB104.Application.DTOs.Authors;
using PestKitOnionAB104.Application.DTOs.Department;
using PestKitOnionAB104.Application.DTOs.Departments;
using PestKitOnionAB104.Application.DTOs.Position;
using PestKitOnionAB104.Domain.Entities;

namespace PestKitOnionAB104.Persistence.Implementations.Services
{
    public class DepartmentService:IDepartmentService
    {
        private readonly IDepartmentRepository _repository;
        private readonly IMapper _mapper;

        public DepartmentService(IDepartmentRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task CreateAsync(DepartmentCreateDto departmentCreateDto)
        {
            
            await _repository.AddAsync(_mapper.Map<Department>(departmentCreateDto));
            await _repository.SaveChangesAsync();
        }

        public async Task<ICollection<DepartmentItemDto>> GetAllAsync(int page, int take)
        {
            ICollection<Department> departments = await _repository.GetAllWhere(skip: (page - 1) * take, take: take, IsTracking: false, isDeleted: true).ToListAsync();

            ICollection<DepartmentItemDto> departmentItemDtos = _mapper.Map<ICollection<DepartmentItemDto>>(departments);

            return departmentItemDtos;
        }
        public async Task UpdateAsync(int id, DepartmentUpdateDto departmentUpdateDto)
        {
            Department department = await _repository.GetByIdAsync(id);

            if (department is null) throw new Exception("Not found");

            department.Name = departmentUpdateDto.Name;

            _repository.Update(department);
            await _repository.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            Department department = await _repository.GetByIdAsync(id);

            if (department is null) throw new Exception("Not found");

            _repository.Delete(department);
            await _repository.SaveChangesAsync();
        }
        public async Task SoftDeleteAsync(int id)
        {
            Department department = await _repository.GetByIdAsync(id);
            if (department is null) throw new Exception("Not found");
            _repository.SoftDelete(department);
            await _repository.SaveChangesAsync();
        }
        public async Task<DepartmentGetDto> GetAsync(int id)
        {
            Department department = await _repository.GetByIdAsync(id);
            if (department is null) throw new Exception("Not found");
            var dto = _mapper.Map<DepartmentGetDto>(department);

            return dto;
        }
    }
}
