using System.Text;
using ApartmentsBooking.DAL;
using ApartmentsBooking.DAL.Entities;
using ApartmentsBooking.DAL.Repositories;
using ApartmentsBooking.DTO;
using ApartmentsBooking.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace ApartmentsBooking;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        
        builder.Services.AddAuthentication().AddBearerToken(IdentityConstants.BearerScheme);
        
        builder.Services.AddDbContext<ApartmentBookingContext>(option => option.UseSqlServer(
            builder.Configuration.GetConnectionString("DefaultConnection")
        ));

        builder.Services.AddAutoMapper(typeof(MappingProfile));

        builder.Services.AddScoped<IRepository<City>, Repository<City>>();
        builder.Services.AddScoped<IRepository<Country>, Repository<Country>>();
        builder.Services.AddScoped<IRepository<Apartment>, Repository<Apartment>>();
        builder.Services.AddScoped<IRepository<Booking>, Repository<Booking>>();
        
        builder.Services.AddScoped<Service<City, CityDto>>();
        builder.Services.AddScoped<Service<Country, CountryDto>>();
        builder.Services.AddScoped<Service<Apartment, ApartmentDto>>();
        builder.Services.AddScoped<Service<Booking, BookingDto>>();

        builder.Services.AddIdentityCore<IdentityUser>()
            .AddEntityFrameworkStores<ApartmentBookingContext>()
            .AddApiEndpoints();
        
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(opt =>
        {
            opt.SwaggerDoc("v1", new OpenApiInfo { Title = "MyAPI", Version = "v1" });
            opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                In = ParameterLocation.Header,
                Description = "Please enter token",
                Name = "Authorization",
                Type = SecuritySchemeType.Http,
                BearerFormat = "Bearer",
                Scheme = "bearer"
            });

            opt.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type=ReferenceType.SecurityScheme,
                            Id="Bearer"
                        }
                    },
                    new string[]{}
                }
            });
        });
        
        builder.Services.AddControllers();

        var app = builder.Build();

        app.MapIdentityApi<IdentityUser>();
        
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        
        app.MapControllers();
        
        app.Run();
    }
}