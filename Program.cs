using Microsoft.EntityFrameworkCore;
using Smart_Yard_Manager.Infrastructure.Context;
using AutoMapper;
using Smart_Yard_Manager.Infrastructure.Mappings; // ou o namespace do seu MappingProfileusing Oracle.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// 1. Adiciona o DbContext (configure sua connection string corretamente)
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseOracle(builder.Configuration.GetConnectionString("OracleConnection")));
// Use o provider correto: Oracle, SQL Server, etc

// 2. Adiciona AutoMapper
builder.Services.AddAutoMapper(typeof(MappingProfile)); // ou use Assembly.GetExecutingAssembly()

// 3. Add Controllers e Swagger (já está ok)
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// pipeline de requisição HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
