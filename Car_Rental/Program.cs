
using Car_Rental.Data;
using Car_Rental.IRepositories;
using Car_Rental.IServices;
using Car_Rental.Repositories;
using Car_Rental.Services;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

namespace Car_Rental
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            // builder.Services.AddControllers();
            builder.Services.AddControllers()
             .AddJsonOptions(options =>
             {
                 options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
             });
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<CarRentalContext>(opt => 
            opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
            builder.Services.AddScoped<IAccountRepository, AccountRepository>();
            builder.Services.AddScoped<IAccountService, AccountService>();
            builder.Services.AddScoped<ICarRepository, CarRepository>();
            builder.Services.AddScoped<ICarService, CarService>();
            builder.Services.AddScoped<IRentalRepository,RentalRepository>();
            builder.Services.AddScoped<IRentalService, RentalService>();
            builder.Services.AddScoped<IReviewRepository,ReviewRepository>();
            builder.Services.AddScoped<IReviewService,ReviewService>();



            builder.Services.AddCors(opt =>
            {
                opt.AddPolicy(
                   name: "CORSPolicy",
                   builder =>
                   {
                       builder.WithOrigins("*").AllowAnyHeader().AllowAnyMethod();

                   }
                   );
            });


            var app = builder.Build();
            app.UseCors("CORSPolicy");
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
        }
    }
}
