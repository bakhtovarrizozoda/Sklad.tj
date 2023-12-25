using System.Net;
using AutoMapper;
using Domain.Dtos.Position;
using Domain.Entities;
using Domain.Wrapper;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services.PositionService;

public class PositionService : IPositionService
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;
    public PositionService(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<Response<GetPositionDto>> AddPosition(AddPositionDto position)
    {
        try
        {
            var model = _mapper.Map<Position>(position);
            await _context.Positions.AddAsync(model);
            await _context.SaveChangesAsync();
            var result = _mapper.Map<GetPositionDto>(model);
            return new Response<GetPositionDto>(result);
        }
        catch (Exception e)
        {
            return new Response<GetPositionDto>(HttpStatusCode.InternalServerError, e.Message);
        }
    }

    public async Task<Response<bool>> DeletePosition(int id)
    {
        try
        {
            var model = await _context.Positions.FindAsync(id);
            if (model == null) return  new Response<bool>(false);
            _context.Positions.Remove(model);
            await _context.SaveChangesAsync();
            return new Response<bool>(true);
        }
        catch (Exception e)
        {
            return new Response<bool>(HttpStatusCode.InternalServerError, e.Message);
        }
    }

    public async Task<Response<List<GetPositionDto>>> GetPosition()
    {
        try
        {
            var model = await _context.Positions.ToListAsync();
            var result = _mapper.Map<List<GetPositionDto>>(model);
            return new Response<List<GetPositionDto>>(result);
        }
        catch (Exception e)
        {
            return new Response<List<GetPositionDto>>(HttpStatusCode.InternalServerError, e.Message);
        }
    }

    public async Task<Response<GetPositionDto>> GetPositionById(int id)
    {
        try
        {
            var model = await _context.Positions.FindAsync(id);
            if (model == null) return new Response<GetPositionDto>(new GetPositionDto());
            var result = _mapper.Map<GetPositionDto>(model);
            return new Response<GetPositionDto>(result);
        }
        catch (Exception e)
        {
            return new Response<GetPositionDto>(HttpStatusCode.InternalServerError, e.Message);
        }
    }

    public async Task<Response<GetPositionDto>> UpdatePosition(AddPositionDto position)
    {
        try
        {
            var model = await _context.Positions.FindAsync(position.Id);
            _mapper.Map(position, model);
            _context.Entry(model).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            var result = _mapper.Map<GetPositionDto>(model);
            return new Response<GetPositionDto>(result);
        }
        catch (Exception e)
        {
            return new Response<GetPositionDto>(HttpStatusCode.InternalServerError, e.Message);
        }
    }

}
