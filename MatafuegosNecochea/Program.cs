using MatafuegosNecochea.Context;
using MatafuegosNecochea.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


// Configure environment variables
builder.Configuration.AddEnvironmentVariables();

// Add services to the container.
// Create connection string.
var connectionString = builder.Configuration.GetConnectionString("Connection");
// Register connection service
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));

// Register JwtTokenGenerator as a service
builder.Services.AddTransient<AuthorizationService>();

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
