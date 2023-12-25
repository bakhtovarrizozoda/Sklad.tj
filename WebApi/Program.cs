using Infrastructure.AutomapperProfile;
using Infrastructure.Context;
using Infrastructure.Services.AccountService;
using Infrastructure.Services.BranchAccessService;
using Infrastructure.Services.BranchService;
using Infrastructure.Services.IncomingService;
using Infrastructure.Services.OutcomingService;
using Infrastructure.Services.PositionService;
using Infrastructure.Services.RoleService;
using Infrastructure.Services.StorageService;
using Infrastructure.Services.UserService;
using Microsoft.EntityFrameworkCore;
using WebApi.ExstensionMethods.AuthConfiguration;
using WebApi.ExtensionMethods.RegisterService;
using WebApi.ExtensionMethods.SwaggerConfiguration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddScoped<IPositionService, PositionService>();
builder.Services.AddScoped<IStorageService, StorageService>();
builder.Services.AddScoped<IOutcomingService, OutcomingService>();
builder.Services.AddScoped<IIncomingService, IncomingService>();
builder.Services.AddScoped<IBranchService, BranchService>();
builder.Services.AddScoped<IBranchAccessService, BranchAccessService>();
builder.Services.AddScoped<IAccountService, AccountService>();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddRegisterService(builder.Configuration);
builder.Services.SwaggerService();
builder.Services.AddAuthConfigureService(builder.Configuration);

builder.Services.AddDbContext<DataContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(ServiceProfile));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
