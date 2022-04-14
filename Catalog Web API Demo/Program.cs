using Catalog_Web_API_Demo.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Singleton for having one copy of the instance of a type across the entire life of the service
builder.Services.AddSingleton<IItemsRepository, InMemItemsRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
