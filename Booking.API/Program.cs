using Booking.Api;
using Booking.Api.Exceptions;
using Booking.Application.DependencyInjection;
using Booking.Infrastructure;
using Booking.Infrastructure.DependencyInjection;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<BookingDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")
    ));
builder.Services.AddProblemDetails();
builder.Services.AddOpenApi();
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();

builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);

var app = builder.Build();


app.UseExceptionHandler();        
app.UseHttpsRedirection();       
app.UseAuthentication();          
app.UseAuthorization();

app.MapOpenApi();
app.MapUserEndpoints();

app.MapGet("/v1/test/protected", () => "You are authenticated!")
   .RequireAuthorization();

app.Run();