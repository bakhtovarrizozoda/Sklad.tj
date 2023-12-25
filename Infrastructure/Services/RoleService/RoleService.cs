using System.Net;
using AutoMapper;
using Domain.Dtos.Role;
using Domain.Entities;
using Domain.Wrapper;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services.RoleService;

public class RoleService : IRoleService
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;
    public RoleService(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<Response<GetRoleDto>> AddRole(AddRoleDto role)
    {
        try
        {
            var model = _mapper.Map<Role>(role);
            await _context.Roles.AddAsync(model);
            await _context.SaveChangesAsync();
            var result = _mapper.Map<GetRoleDto>(model);
            return new Response<GetRoleDto>(result);
            
        }
        catch (Exception e)
        {
            return new Response<GetRoleDto>(HttpStatusCode.InternalServerError, e.Message);
        }
    }

    public async Task<Response<bool>> DeleteRole(int id)
    {
        try
        {
            var model = await _context.Roles.FindAsync(id);
            if (model == null) return new Response<bool>(false);
            _context.Roles.Remove(model);
            await _context.SaveChangesAsync();
            return new Response<bool>(true);
        }
        catch (Exception e)
        {
            return new Response<bool>(HttpStatusCode.InternalServerError, e.Message);            
        }
    }

    public async Task<Response<List<GetRoleDto>>> GetRole()
    {
        try
        {
            var model = await _context.Roles.ToListAsync();
            var result = _mapper.Map<List<GetRoleDto>>(model);
            return new Response<List<GetRoleDto>>(result);
        }
        catch (Exception e)
        {
            return new Response<List<GetRoleDto>>(HttpStatusCode.InternalServerError, e.Message);            
        }
    }

    public async Task<Response<GetRoleDto>> GetRoleById(int id)
    {
        try
        {
            var model = await _context.Roles.FindAsync(id);
            if (model == null) return new Response<GetRoleDto>(new GetRoleDto());
            var result = _mapper.Map<GetRoleDto>(model);
            return new Response<GetRoleDto>(result);
        }
        catch (Exception e)
        {
            return new Response<GetRoleDto>(HttpStatusCode.InternalServerError, e.Message);
        }
    }

    public async Task<Response<GetRoleDto>> UpdateRole(AddRoleDto role)
    {
        try
        {
            var model = await _context.Roles.FindAsync(role.Id);
            _mapper.Map(role, model);
            _context.Entry(model).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            var result = _mapper.Map<GetRoleDto>(model);
            return new Response<GetRoleDto>(result);
        }
        catch (Exception e)
        {
            return new Response<GetRoleDto>(HttpStatusCode.InternalServerError, e.Message);
        }
    }

}
