using AutoWrapper;
using Common;
using Common.Filters;
using Data.DBContext;
using Data.Transactions;
using Infrastructure.Interfaces;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
var cn = builder.Configuration.GetConnectionString("LocalConnection");
// Add services to the container.
builder.Services.AddDbContext<DBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("LocalConnection")));
builder.Services.AddControllers(options =>
{
    options.Filters.Add(typeof(ResponseFormatterFilter));
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => {
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Airline Booking Portal API Documentation"
    });
    c.SwaggerDoc("v2", new OpenApiInfo
    {
        Version = "v2",
        Title = "this is V2"
    });

    c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
});

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IBookingService, BookingService>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IFlightDestinationService, FlightRouteService>();
builder.Services.AddScoped<IFlightScheduleService, FlightScheduleService>();
builder.Services.AddScoped<IFlightService, FlightService>();
builder.Services.AddScoped<IPassengerService, PassengerService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseApiResponseAndExceptionWrapper<Result>();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
