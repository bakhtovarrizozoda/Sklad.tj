using AutoMapper;
using Domain.Dtos.Account.AccountDto;
using Domain.Dtos.Branch;
using Domain.Dtos.BranchAccess;
using Domain.Dtos.Incoming;
using Domain.Dtos.Outcoming;
using Domain.Dtos.Position;
using Domain.Dtos.Role;
using Domain.Dtos.Storage;
using Domain.Dtos.User;
using Domain.Entities;

namespace Infrastructure.AutomapperProfile;

public class ServiceProfile : Profile
{
    public ServiceProfile()
    {
        CreateMap<User, GetUserDto>().ReverseMap();
        CreateMap<AddUserDto, User>().ReverseMap();

        CreateMap<Storage, GetStorageDto>().ReverseMap();
        CreateMap<AddStorageDto, Storage>().ReverseMap();

        CreateMap<Role, GetRoleDto>().ReverseMap();
        CreateMap<AddRoleDto, Role>().ReverseMap();

        CreateMap<Position, GetPositionDto>().ReverseMap();
        CreateMap<AddPositionDto, Position>().ReverseMap();

        CreateMap<Outcoming, GetOutcomingDto>().ReverseMap();
        CreateMap<AddOutcomingDto, Outcoming>().ReverseMap();

        CreateMap<Incoming, GetIncomingDto>().ReverseMap();
        CreateMap<AddIncomingDto, Incoming>().ReverseMap();

        CreateMap<BranchAccess, GetBranchAccessDto>().ReverseMap();
        CreateMap<AddBranchAccessDto, BranchAccess>().ReverseMap();

        CreateMap<Branch, GetBranchDto>().ReverseMap();
        CreateMap<AddBranchDto, Branch>().ReverseMap();

        CreateMap<Account, GetAllAccountDto>().ReverseMap();
    }
}