using Inlog.Desafio.Backend.Infra.Database.Context;
using Inlog.Desafio.Backend.WebApi.DependencyMap;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Map
//builder.Services.ServiceMap(System.Configuration);
builder.Services.RepositoryMap();

////Inje��o de dependencia do banco de dados
builder.Services.AddDbContext<DataContext>(x => x.UseSqlite(connectionString));

builder.Services.AddMediatR(AppDomain.CurrentDomain.Load("Inlog.Desafio.Backend.Application"));

builder.Services.AddCors();
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//db.Database.EnsureCreated();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors(x => x
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader()
);

app.UseAuthentication();
app.UseAuthorization();

app.Run();