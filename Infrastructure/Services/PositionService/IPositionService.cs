using Domain.Dtos.Position;
using Domain.Wrapper;

namespace Infrastructure.Services.PositionService;

public interface IPositionService
{
    public Task<Response<List<GetPositionDto>>> GetPosition();
    public Task<Response<GetPositionDto>> GetPositionById(int id);
    public Task<Response<GetPositionDto>> AddPosition(AddPositionDto position);
    public Task<Response<GetPositionDto>> UpdatePosition(AddPositionDto position);
    public Task<Response<bool>> DeletePosition(int id);
}
