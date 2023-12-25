using Domain.Dtos.Incoming;
using Domain.Wrapper;

namespace Infrastructure.Services.IncomingService;

public interface IIncomingService
{
    public Task<List<GetIncomingFullInfoDto>> GetIncomingFullInfo();
    public Task<Response<List<GetIncomingDto>>> GetIncoming();
    public Task<Response<GetIncomingDto>> GetIncomingById(int id);
    public Task<Response<GetIncomingDto>> AddIncoming(AddIncomingDto incoming);
    public Task<Response<GetIncomingDto>> UpdateIncoming(AddIncomingDto incoming);
    public Task<Response<bool>> DeleteIncoming(int id);
}
