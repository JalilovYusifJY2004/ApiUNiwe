using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PestKitOnionAB104.Application.Abstractions.Repositories;
using PestKitOnionAB104.Application.Abstractions.Services;
using PestKitOnionAB104.Application.DTOs.Position;
using PestKitOnionAB104.Application.DTOs.Positions;
using PestKitOnionAB104.Application.DTOs.Tag;
using PestKitOnionAB104.Application.DTOs.Tags;
using PestKitOnionAB104.Domain.Entities;

namespace PestKitOnionAB104.Persistence.Implementations.Services
{
    public class TagService:ITagService
    {
        private readonly ITagRepository _repository;
        private readonly IMapper _mapper;

        public TagService(ITagRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task CreateAsync(TagCreateDto tagCreateDto)
        {
            await _repository.AddAsync(_mapper.Map<Tag>(tagCreateDto));
            await _repository.SaveChangesAsync();
        }

        public async Task<ICollection<TagItemDto>> GetAllAsync(int page, int take)
        {
            ICollection<Tag> tags = await _repository.GetAllWhere(skip: (page - 1) * take, take: take, IsTracking: false, isDeleted: true).ToListAsync();

            ICollection<TagItemDto> tagItemDtos = _mapper.Map<ICollection<TagItemDto>>(tags);

            return tagItemDtos;
        }
        public async Task UpdateAsync(int id, TagUpdateDto tagUpdateDto)
        {
            Tag tag = await _repository.GetByIdAsync(id);

            if (tag is null) throw new Exception("Not found");

            tag.Name = tagUpdateDto.Name;

            _repository.Update(tag);
            await _repository.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            Tag tag = await _repository.GetByIdAsync(id);

            if (tag is null) throw new Exception("Not found");

            _repository.Delete(tag);
            await _repository.SaveChangesAsync();
        }
        public async Task SoftDeleteAsync(int id)
        {
            Tag tag = await _repository.GetByIdAsync(id);
            if (tag is null) throw new Exception("Not found");
            _repository.SoftDelete(tag);
            await _repository.SaveChangesAsync();
        }

        public async Task<TagGetDto> GetAsync(int id)
        {
            Tag tag = await _repository.GetByIdAsync(id);
            if (tag is null) throw new Exception("Not found");
            var dto = _mapper.Map<TagGetDto>(tag);

            return dto;
        }
    }
}
