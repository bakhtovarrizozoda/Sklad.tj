using System.Net;
using AutoMapper;
using Domain.Dtos.BranchAccess;
using Domain.Entities;
using Domain.Wrapper;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services.BranchAccessService;

public class BranchAccessService : IBranchAccessService
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;
    public BranchAccessService(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<GetBranchAccessFullInfoDto>> GetBranchAccessFullInfo()
    {
        var result = await (from ba in _context.BranchAccesses
        join u in _context.Users on ba.UserId equals u.Id
        join b in _context.Branches on ba.BranchId equals b.Id
        join s in _context.Storages on ba.StorageId equals s.Id into bAStorege
        from bas in bAStorege.DefaultIfEmpty()
        select new GetBranchAccessFullInfoDto()
        {
            Id = ba.Id,
            FirstName = u.FirstName,
            UserId = u.Id,
            BrachName = b.BrachName,
            BranchId = b.Id,
            StorageName = bas.StorageName,
            StorageId = bas.Id
        }).ToListAsync();
        return result;
    }

    public async Task<Response<GetBranchAccessDto>> AddBranchAccess(AddBranchAccessDto branchAccess)
    {
        try
        {
            var model = _mapper.Map<BranchAccess>(branchAccess);
            await _context.BranchAccesses.AddAsync(model);
            await _context.SaveChangesAsync();
            var result = _mapper.Map<GetBranchAccessDto>(model);
            return new Response<GetBranchAccessDto>(result);
        }
        catch (Exception e)
        {
            return new Response<GetBranchAccessDto>(HttpStatusCode.InternalServerError, e.Message);
        }
    }

    public async Task<Response<bool>> DeleteBranchAccess(int id)
    {
        try
        {
            var model = await _context.BranchAccesses.FindAsync(id);
            if (model == null) return new Response<bool>(false);
            _context.BranchAccesses.Remove(model);
            await _context.SaveChangesAsync();
            return new Response<bool>(true);
        }
        catch (Exception e)
        {
            return new Response<bool>(HttpStatusCode.InternalServerError, e.Message);
        }
    }

    public async Task<Response<List<GetBranchAccessDto>>> GetBranchAccess()
    {
        try
        {
            var model = await _context.BranchAccesses.ToListAsync();
            var result = _mapper.Map<List<GetBranchAccessDto>>(model);
            return new Response<List<GetBranchAccessDto>>(result);
        }
        catch (Exception e)
        {
            return new Response<List<GetBranchAccessDto>>(HttpStatusCode.InternalServerError, e.Message);
        }
    }

    public async Task<Response<GetBranchAccessDto>> GetBranchAccessById(int id)
    {
        try
        {
            var model = await _context.BranchAccesses.FindAsync(id);
            if (model == null) return new Response<GetBranchAccessDto>(new GetBranchAccessDto());
            var result = _mapper.Map<GetBranchAccessDto>(model);
            return new Response<GetBranchAccessDto>(result);
        }
        catch (Exception e)
        {
            return new Response<GetBranchAccessDto>(HttpStatusCode.InternalServerError, e.Message);
        }
    }

    public async Task<Response<GetBranchAccessDto>> UpdateBranchAccess(AddBranchAccessDto branchAccess)
    {
        try
        {
            var model = await _context.BranchAccesses.FindAsync(branchAccess.Id);
            _mapper.Map(branchAccess, model);
            _context.Entry(model).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            var result = _mapper.Map<GetBranchAccessDto>(model);
            return new Response<GetBranchAccessDto>(result);
        }
        catch (Exception e)
        {
            return new Response<GetBranchAccessDto>(HttpStatusCode.InternalServerError, e.Message);
        }
    }

}
