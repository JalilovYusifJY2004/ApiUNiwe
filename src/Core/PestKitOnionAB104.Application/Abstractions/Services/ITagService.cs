using PestKitOnionAB104.Application.DTOs.Tag;
using PestKitOnionAB104.Application.DTOs.Tags;

namespace PestKitOnionAB104.Application.Abstractions.Services
{
    public interface ITagService
    {
        Task<ICollection<TagItemDto>> GetAllAsync(int page, int take);
        Task<TagGetDto> GetAsync(int id);
        Task CreateAsync(TagCreateDto tagCreateDto);
        Task UpdateAsync(int id, TagUpdateDto tagUpdateDto);
        Task DeleteAsync(int id);
        Task SoftDeleteAsync(int id);
    }
}
