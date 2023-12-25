using Domain.Dtos.Outcoming;
using Domain.Wrapper;

namespace Infrastructure.Services.OutcomingService;

public interface IOutcomingService
{
    public Task<List<GetOutcomingFullInfoDto>> GetOutcomingFullInfo();
    public Task<Response<List<GetOutcomingDto>>> GetOutcoming();
    public Task<Response<GetOutcomingDto>> GetOutcomingById(int id);
    public Task<Response<GetOutcomingDto>> AddOutcoming(AddOutcomingDto outcoming);
    public Task<Response<GetOutcomingDto>> UpdateOutcoming(AddOutcomingDto outcoming);
    public Task<Response<bool>> DeleteOutcoming(int id);
}
