using Microsoft.EntityFrameworkCore;
using Products.API.Filters;
using Products.API.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// reconhecendo o filtro de excecao
builder.Services.AddMvc(option => option.Filters.Add(typeof(ExceptionFilter)));

// Configuração do DbContext com o SQLite
builder.Services.AddDbContext<ProductDbContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
