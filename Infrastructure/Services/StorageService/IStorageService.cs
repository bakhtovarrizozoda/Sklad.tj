using Domain.Dtos.Storage;
using Domain.Wrapper;


namespace Infrastructure.Services.StorageService;

public interface IStorageService
{
    public Task<List<GetStorageFullInfoDto>> GetStorageFullInfo();
    public Task<Response<List<GetStorageDto>>> GetStorage();
    public Task<Response<GetStorageDto>> GetStorageById(int id);
    public Task<Response<GetStorageDto>> AddStorage(AddStorageDto storage);
    public Task<Response<GetStorageDto>> UpdateStorage(AddStorageDto storage);
    public Task<Response<bool>> DeleteStorage(int id);
}
