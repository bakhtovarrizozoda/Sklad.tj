using Domain.Dtos.BranchAccess;
using Domain.Wrapper;

namespace Infrastructure.Services.BranchAccessService;

public interface IBranchAccessService
{
    public Task<List<GetBranchAccessFullInfoDto>> GetBranchAccessFullInfo();
    public Task<Response<List<GetBranchAccessDto>>> GetBranchAccess();
    public Task<Response<GetBranchAccessDto>> GetBranchAccessById(int id);
    public Task<Response<GetBranchAccessDto>> AddBranchAccess(AddBranchAccessDto branchAccess);
    public Task<Response<GetBranchAccessDto>> UpdateBranchAccess(AddBranchAccessDto branchAccess);
    public Task<Response<bool>> DeleteBranchAccess(int id);
}