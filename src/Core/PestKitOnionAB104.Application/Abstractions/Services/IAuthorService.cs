using PestKitOnionAB104.Application.DTOs.Author;
using PestKitOnionAB104.Application.DTOs.Authors;

namespace PestKitOnionAB104.Application.Abstractions.Services
{
    public interface IAuthorService
    {
        Task<ICollection<AuthorItemDto>> GetAllAsync(int page, int take);
        Task<AuthorGetDto> GetAsync(int id);
        Task CreateAsync(AuthorCreateDto authorCreateDto);
        Task UpdateAsync(int id, AuthorUpdateDto authorUpdateDto);
        Task DeleteAsync(int id);
        Task SoftDeleteAsync(int id);
    }
}
