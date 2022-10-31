using Api_Articulos.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// var ConStr = builder.Configuration.GetConnectionString("ConStr");
var Default = builder.Configuration.GetConnectionString("Default");

builder.Services.AddDbContext<Contexto>(options =>
    options.UseSqlServer(Default)
);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<Contexto, Contexto>();
var app = builder.Build();

    app.UseSwagger();
    app.UseSwaggerUI();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
