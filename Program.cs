using Microsoft.EntityFrameworkCore;
using Smart_Yard_Manager.Infrastructure.Context;
using AutoMapper;
using Smart_Yard_Manager.Infrastructure.Mappings;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Configuração do banco
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseOracle(builder.Configuration.GetConnectionString("OracleConnection")));

// AutoMapper
builder.Services.AddAutoMapper(typeof(MappingProfile));

// Controllers e Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(x =>
{
    x.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = builder.Configuration["Swagger:Title"],
        Description = "API para controle de motos dentro do ambiente Mottu",
        Contact = new OpenApiContact { Name = "Felipe Santana, Emily Macedo, Gabriela Gomes Cezar", Email = "RM558916@fiap.com.br" }
    });
});

var app = builder.Build();

// Middlewares
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();