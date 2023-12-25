using System.Net;
using AutoMapper;
using Domain.Dtos.Outcoming;
using Domain.Entities;
using Domain.Wrapper;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services.OutcomingService;

public class OutcomingService : IOutcomingService
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;
    public OutcomingService(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<GetOutcomingFullInfoDto>> GetOutcomingFullInfo()
    {
        var result = await (from o in _context.Outcomings
        join i in _context.Incomings on o.IncomingId equals i.Id
        join s in _context.Storages on o.StorageId equals s.Id into outcomingstorage
        from os in outcomingstorage.DefaultIfEmpty()
        select new GetOutcomingFullInfoDto()
        {
            Id = o.Id,
            IncomingName = i.IncomingName,
            IncomingId = i.Id,
            Counto = o.Counto,
            Recipient = o.Recipient,
            Profit = (i.Current_Price - i.Price_Came) * o.Counto,
            StorageName = os.StorageName,
            StorageId = os.Id
        }).ToListAsync();
        return result;
    }

    public async Task<Response<GetOutcomingDto>> AddOutcoming(AddOutcomingDto outcoming)
    {
        try
        {
            var model = _mapper.Map<Outcoming>(outcoming);
            await _context.Outcomings.AddAsync(model);
            await _context.SaveChangesAsync();
            var result = _mapper.Map<GetOutcomingDto>(model);
            return new Response<GetOutcomingDto>(result);
        }
        catch (Exception e)
        {
            return new Response<GetOutcomingDto>(HttpStatusCode.InternalServerError, e.Message);
        }
    }

    public async Task<Response<bool>> DeleteOutcoming(int id)
    {
        try
        {
            var model = await _context.Outcomings.FindAsync(id);
            if (model == null) return new Response<bool>(false);
            _context.Outcomings.Remove(model);
            await _context.SaveChangesAsync();
            return new Response<bool>(true);
        }
        catch (Exception e)
        {
            return new Response<bool>(HttpStatusCode.InternalServerError, e.Message);
        }
    }

    public async Task<Response<GetOutcomingDto>> GetOutcomingById(int id)
    {
        try
        {
            var model = await _context.Outcomings.FindAsync(id);
            if (model == null) return new Response<GetOutcomingDto>(new GetOutcomingDto());
            var result = _mapper.Map<GetOutcomingDto>(model);
            return new Response<GetOutcomingDto>(result);
        }
        catch (Exception e)
        {
            return new Response<GetOutcomingDto>(HttpStatusCode.InternalServerError, e.Message);
        }
    }

    public async Task<Response<List<GetOutcomingDto>>> GetOutcoming()
    {
        try
        {
            var model = await _context.Outcomings.ToListAsync();
            var result = _mapper.Map<List<GetOutcomingDto>>(model);
            return new Response<List<GetOutcomingDto>>(result);
        }
        catch (Exception e)
        {
            return new Response<List<GetOutcomingDto>>(HttpStatusCode.InternalServerError, e.Message);
        }
    }

    public async Task<Response<GetOutcomingDto>> UpdateOutcoming(AddOutcomingDto outcoming)
    {
        try
        {
            var model = await _context.Outcomings.FindAsync(outcoming.Id);
            _mapper.Map(outcoming, model);
            _context.Entry(model).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            var result = _mapper.Map<GetOutcomingDto>(model);
            return new Response<GetOutcomingDto>(result);
        }
        catch (Exception e)
        {
            return new Response<GetOutcomingDto>(HttpStatusCode.InternalServerError, e.Message);
        }
    }

}
