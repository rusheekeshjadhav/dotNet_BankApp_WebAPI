using Microsoft.EntityFrameworkCore;
using BankApp_WebAPI.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();



builder.Services.AddDbContext<BankContext>(opt =>
    opt.UseInMemoryDatabase("AccountList"));

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy((builder) =>
    {
        builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//  builder.Services.AddEndpointsApiExplorer();
//  builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    //  app.UseSwagger();
    //  app.UseSwaggerUI();
}

app.UseCors();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

