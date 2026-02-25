using Booking.Infrastructure;
using Booking.Application.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Booking.Api;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<BookingDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();
app.MapUserEndpoints();
app.MapAuthEndpoints();

app.MapGet("/v1/test/protected", () => "You are authenticated!")
   .RequireAuthorization();

app.Run();