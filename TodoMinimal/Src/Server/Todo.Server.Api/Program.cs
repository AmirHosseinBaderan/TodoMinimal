using Application;
using Infrastructure.Presistance;
using Server.Api;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.ConfigureInfrastructureLayer(builder.Configuration);
builder.Services.ConfigureApplicationLayer(builder.Configuration);
builder.Services.ConfigureMapster();
builder.Services.ConfigureValidator();
builder.Services.ConfigureCors();

builder.Services.AddEndpoints();
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseCors("AllowOrigin");

app.UseSwagger();
app.UseSwaggerUI();

app.MapEndpoints();


app.UseHttpsRedirection();

await app.RunAsync();