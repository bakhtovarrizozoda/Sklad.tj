using Domain.Dtos.Branch;
using Domain.Wrapper;

namespace Infrastructure.Services.BranchService;

public interface IBranchService
{
    public Task<List<GetBranchFullInfoDto>> GetBranchFullInfo();
    public Task<Response<List<GetBranchDto>>> GetBranch();
    public Task<Response<GetBranchDto>> GetBranchById(int id);
    public Task<Response<GetBranchDto>> AddBranch(AddBranchDto branch);
    public Task<Response<GetBranchDto>> UpdateBranch(AddBranchDto branch);
    public Task<Response<bool>> DeleteBranch(int id); 
}
