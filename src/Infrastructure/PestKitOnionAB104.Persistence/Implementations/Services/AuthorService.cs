using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PestKitOnionAB104.Application.Abstractions.Repositories;
using PestKitOnionAB104.Application.Abstractions.Services;
using PestKitOnionAB104.Application.DTOs.Author;
using PestKitOnionAB104.Application.DTOs.Authors;
using PestKitOnionAB104.Domain.Entities;

namespace PestKitOnionAB104.Persistence.Implementations.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _repository;
        private readonly IMapper _mapper;

        public AuthorService(IAuthorRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task CreateAsync(AuthorCreateDto authorCreateDto)
        {

            await _repository.AddAsync(_mapper.Map<Author>(authorCreateDto));

            await _repository.SaveChangesAsync();
        }

        public async Task<ICollection<AuthorItemDto>> GetAllAsync(int page, int take)
        {
            ICollection<Author> authors = await _repository.GetAllWhere(skip: (page - 1) * take, take: take, IsTracking: false, isDeleted: true).ToListAsync();

            ICollection<AuthorItemDto> authorItemDtos = _mapper.Map<ICollection<AuthorItemDto>>(authors);

            return authorItemDtos;
        }
        public async Task UpdateAsync(int id, AuthorUpdateDto authorUpdateDto)
        {
            Author author = await _repository.GetByIdAsync(id);

            if (author is null) throw new Exception("Not found");

            author.Name = authorUpdateDto.Name;

            _repository.Update(author);
            await _repository.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            Author author = await _repository.GetByIdAsync(id);

            if (author is null) throw new Exception("Not found");

            _repository.Delete(author);
            await _repository.SaveChangesAsync();
        }
        public async Task SoftDeleteAsync(int id)
        {
            Author author = await _repository.GetByIdAsync(id);
            if (author is null) throw new Exception("Not found");
            _repository.SoftDelete(author);
            await _repository.SaveChangesAsync();
        }

        public async Task<AuthorGetDto> GetAsync(int id)
        {
            Author author = await _repository.GetByIdAsync(id);
            if (author is null) throw new Exception("Not found");
            var dto=_mapper.Map<AuthorGetDto>(author);

            return dto;
        }
    }
}
