using AlicundeTechTest.Mappings;
using ESettOpenApiInterfaces.Interfaces;
using ESettOpenApiService;
using ESettRepositories;
using ESettRepositoriesInterfaces.DBContext;
using ESettRepositoriesInterfaces.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.ClearProviders();
builder.Logging.AddConsole();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add database context
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ESettDbContext>(options =>
    options.UseSqlServer(connectionString));


// Repositories
builder.Services.AddScoped<IeSettDataAccess, ESettDataAccess>();
builder.Services.AddScoped<IBankService, BankService>();

// Automapper
builder.Services.AddAutoMapper(typeof(MappingConfiguration).Assembly);

// External Services
builder.Services.AddHttpClient<ESettDataAccess>();

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
