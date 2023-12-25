using System.Net;
using AutoMapper;
using Domain.Dtos.Incoming;
using Domain.Entities;
using Domain.Wrapper;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services.IncomingService;

public class IncomingService : IIncomingService
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;
    public IncomingService(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }



    public async Task<List<GetIncomingFullInfoDto>> GetIncomingFullInfo()
    {
        var result = await (from i in _context.Incomings
        join o in _context.Outcomings on i.Id equals o.IncomingId
        join s in _context.Storages on i.StorageId equals s.Id into incomingstorage
        from inst in incomingstorage.DefaultIfEmpty()
        select new GetIncomingFullInfoDto
        {
            Id = i.Id,
            IncomingName = i.IncomingName,
            Counti = i.Counti - o.Counto,
            IncomingDate = i.IncomingDate,
            Price_Came = i.Price_Came,
            Current_Price = i.Current_Price,
            StorageName = inst.StorageName,
            StorageId = inst.Id
        }).ToListAsync();
        return result;
    }

    public async Task<Response<GetIncomingDto>> AddIncoming(AddIncomingDto incoming)
    {
        try
        {
            var incomingCreat = new Incoming
            {
                Id = incoming.Id,
                IncomingName = incoming.IncomingName,
                Counti = incoming.Counti,
                IncomingDate = incoming.IncomingDate,
                Price_Came = incoming.Price_Came,
                Current_Price = incoming.Current_Price,
                StorageId = incoming.StorageId
            };
            await _context.Incomings.AddAsync(incomingCreat);
            await _context.SaveChangesAsync();
            var result = _mapper.Map<GetIncomingDto>(incomingCreat);
            return new Response<GetIncomingDto>(result);
        }
        catch (Exception e)
        {
            return new Response<GetIncomingDto>(HttpStatusCode.InternalServerError, e.Message);
        }
    }

    public async Task<Response<bool>> DeleteIncoming(int id)
    {
        try
        {
            var model = await _context.Incomings.FindAsync(id);
            if (model == null) return new Response<bool>(false);
            _context.Incomings.Remove(model);
            await _context.SaveChangesAsync();
            return new Response<bool>(true);
        }
        catch (Exception e)
        {
            return new Response<bool>(HttpStatusCode.InternalServerError, e.Message);
        }
    }

    public async Task<Response<List<GetIncomingDto>>> GetIncoming()
    {
        try
        {
            var model = await _context.Incomings.ToListAsync();
            var result = _mapper.Map<List<GetIncomingDto>>(model);
            return new Response<List<GetIncomingDto>>(result);
        }
        catch (Exception e)
        {
            return new Response<List<GetIncomingDto>>(HttpStatusCode.InternalServerError, e.Message);
        }
    }

    public async Task<Response<GetIncomingDto>> GetIncomingById(int id)
    {
        try
        {
            var model = await _context.Incomings.FindAsync(id);
            if (model == null) return new Response<GetIncomingDto>(new GetIncomingDto());
            var result = _mapper.Map<GetIncomingDto>(model);
            return new Response<GetIncomingDto>(result);
        }
        catch (Exception e)
        {
            return new Response<GetIncomingDto>(HttpStatusCode.InternalServerError, e.Message);
        }
    }

    public async Task<Response<GetIncomingDto>> UpdateIncoming(AddIncomingDto incoming)
    {
        try
        {
            var model = await _context.Incomings.FindAsync(incoming.Id);
            _mapper.Map(incoming, model);
            _context.Entry(model).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            var result = _mapper.Map<GetIncomingDto>(model);
            return new Response<GetIncomingDto>(result);
        }
        catch (Exception e)
        {
            return new Response<GetIncomingDto>(HttpStatusCode.InternalServerError, e.Message);
        }
    }

}
