using BidCalculator.Base.Interfaces;
using BidCalculator.Base.Models;
using BidCalculator.Base.Services;

// Setup Builder

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();

builder.Services.AddScoped<ICalculationService, CalculationService>();

// Setup Application

var app = builder.Build();

app.MapDefaultEndpoints();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

// Endpoints

app.MapPost("/calculate", (CalculationRequest request, ICalculationService calculationService) =>
{
    return calculationService.Calculate(request);
})
.WithName("Calculate")
.WithOpenApi();

app.Run();
