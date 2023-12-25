using System.Net;
using AutoMapper;
using Domain.Dtos.Storage;
using Domain.Entities;
using Domain.Wrapper;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services.StorageService;

public class StorageService : IStorageService
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;
    public StorageService(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<GetStorageFullInfoDto>> GetStorageFullInfo()
    {
        var result = await (from s in _context.Storages
        join b in _context.Branches on s.BranchId equals b.Id
        join u in _context.Users on s.UserId equals u.Id into storageuser
        from su in storageuser.DefaultIfEmpty()
        select new GetStorageFullInfoDto()
        {
            Id = s.Id,
            StorageName = s.StorageName,
            BrachName = b.BrachName,
            BranchId = b.Id,
            FirstName = su.FirstName,
            UserId = su.Id
        }).ToListAsync();
        return result;
    }

    public async Task<Response<GetStorageDto>> AddStorage(AddStorageDto storage)
    {
        try
        {
            var model = _mapper.Map<Storage>(storage);
            await _context.Storages.AddAsync(model);
            await _context.SaveChangesAsync();
            var result = _mapper.Map<GetStorageDto>(model);
            return new Response<GetStorageDto>(result);
        }
        catch (Exception e)
        {
            return new Response<GetStorageDto>(HttpStatusCode.InternalServerError, e.Message);
        }
    }

    public async Task<Response<bool>> DeleteStorage(int id)
    {
        try
        {
            var model = await _context.Storages.FindAsync(id);
            if (model == null) return new Response<bool>(false);
            _context.Storages.Remove(model);
            await _context.SaveChangesAsync();
            return new Response<bool>(true);
        }
        catch (Exception e)
        {
            return new Response<bool>(HttpStatusCode.InternalServerError, e.Message);
        }
    }

    public async Task<Response<List<GetStorageDto>>> GetStorage()
    {
        try
        {
            var model = await _context.Storages.ToListAsync();
            var result = _mapper.Map<List<GetStorageDto>>(model);
            return new Response<List<GetStorageDto>>(result);
        }
        catch (Exception e)
        {
            return new Response<List<GetStorageDto>>(HttpStatusCode.InternalServerError, e.Message);
        }
    }

    public async Task<Response<GetStorageDto>> GetStorageById(int id)
    {
        try
        {
            var model = await _context.Storages.FindAsync(id);
            if (model == null) return new Response<GetStorageDto>(new GetStorageDto());
            var result = _mapper.Map<GetStorageDto>(model);
            return new Response<GetStorageDto>(result);
        }
        catch (Exception e)
        {
            return new Response<GetStorageDto>(HttpStatusCode.InternalServerError, e.Message);
        }
    }

    public async Task<Response<GetStorageDto>> UpdateStorage(AddStorageDto storage)
    {
        try
        {
            var model = await _context.Storages.FindAsync(storage.Id);
            _mapper.Map(storage, model);
            _context.Entry(model).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            var result = _mapper.Map<GetStorageDto>(model);
            return new Response<GetStorageDto>(result);
        }
        catch (Exception e)
        {
            return new Response<GetStorageDto>(HttpStatusCode.InternalServerError, e.Message);
        }
    }

}
