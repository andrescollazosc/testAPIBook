using BooksStore.Domain.Contracts;
using BooksStore.Domain.Models;
using BooksStore.Ifrastructure.Data;
using BooksStore.Ifrastructure.Data.Repositories;
using BooksStore.Services.WebApi.Mapper;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<BookContext>(options =>
            options.UseSqlServer(builder.Configuration["dbBook"]));
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IGenericRepository<Book>, BookRepository>();
builder.Services.AddScoped<IMapper, Mapper>();


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
