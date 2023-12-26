using PestKitOnionAB104.Application.DTOs.Position;
using PestKitOnionAB104.Application.DTOs.Positions;
using PestKitOnionAB104.Application.DTOs.Tag;

namespace PestKitOnionAB104.Application.Abstractions.Services
{
    public interface IPositionService
    {
        Task<ICollection<PositionItemDto>> GetAllAsync(int page, int take);
        Task<PositionGetDto> GetAsync(int id);
        Task CreateAsync(PositionCreateDto positionCreateDto);
        Task UpdateAsync(int id, PositionUpdateDto positionUpdateDto);
        Task DeleteAsync(int id);
        Task SoftDeleteAsync(int id);
    }
}
