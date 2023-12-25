using System.Net;
using AutoMapper;
using Domain.Dtos.Branch;
using Domain.Entities;
using Domain.Wrapper;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services.BranchService;

public class BranchService : IBranchService
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;
    public BranchService(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<GetBranchFullInfoDto>> GetBranchFullInfo()
    {
        var result = await (from b in _context.Branches
        join u in _context.Users on b.UserId equals u.Id into branchuser
        from bu in branchuser.DefaultIfEmpty()
        select new GetBranchFullInfoDto()
        {
            Id = b.Id,
            BrachName = b.BrachName,
            Address = b.Address,
            FirstName = bu.FirstName,
            UserId = bu.Id
        }).ToListAsync();
        return result;
    }
    public async Task<Response<GetBranchDto>> AddBranch(AddBranchDto branch)
    {
        try
        {
            var model = _mapper.Map<Branch>(branch);
            await _context.Branches.AddAsync(model);
            await _context.SaveChangesAsync();
            var result = _mapper.Map<GetBranchDto>(model);
            return new Response<GetBranchDto>(result);
        }
        catch (Exception e)
        {
            return new Response<GetBranchDto>(HttpStatusCode.InternalServerError, e.Message);
        }
    }

    public async Task<Response<bool>> DeleteBranch(int id)
    {
        try
        {
            var model = await _context.Branches.FindAsync(id);
            if (model == null) return new Response<bool>(false);
            _context.Branches.Remove(model);
            await _context.SaveChangesAsync();
            return new Response<bool>(true);
        }
        catch (Exception e)
        {
            return new Response<bool>(HttpStatusCode.InternalServerError, e.Message);
        }
    }

    public async Task<Response<List<GetBranchDto>>> GetBranch()
    {
        try
        {
            var model = await _context.Branches.ToListAsync();
            var result = _mapper.Map<List<GetBranchDto>>(model);
            return new Response<List<GetBranchDto>>(result);
        }
        catch (Exception e)
        {
            return new Response<List<GetBranchDto>>(HttpStatusCode.InternalServerError, e.Message);
        }
    }

    public async Task<Response<GetBranchDto>> GetBranchById(int id)
    {
        try
        {
            var model = await _context.Branches.FindAsync(id);
            if (model == null) return new Response<GetBranchDto>(new GetBranchDto());
            await _context.SaveChangesAsync();
            var result = _mapper.Map<GetBranchDto>(model);
            return new Response<GetBranchDto>(result);
        }
        catch (Exception e)
        {
            return new Response<GetBranchDto>(HttpStatusCode.InternalServerError, e.Message);
        }
    }

    public async Task<Response<GetBranchDto>> UpdateBranch(AddBranchDto branch)
    {
        try
        {
            var model = await _context.Branches.FindAsync(branch.Id);
            _mapper.Map(branch, model);
            _context.Entry(model).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            var result = _mapper.Map<GetBranchDto>(model);
            return new Response<GetBranchDto>(result);
        }
        catch (Exception e)
        {
            return new Response<GetBranchDto>(HttpStatusCode.InternalServerError, e.Message);
        }
    }

}
