
using Microsoft.EntityFrameworkCore;
using real_estate.Models;
using real_estate.Models.ApplicationContext;
using real_estate.Service;

namespace real_estate
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Active Model State
            builder.Services.AddControllers().ConfigureApiBehaviorOptions(
                options => options.SuppressModelStateInvalidFilter = true
            );

            builder.Services.AddDbContext<RealEstateDbContext>(opt =>
                opt.UseSqlServer(builder.Configuration.GetConnectionString("ProdCS"))
            );

            builder.Services.AddScoped<IImageUploadService, CloudinaryImageUploadService>();
            builder.Services.AddAutoMapper(typeof(Program));


            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("MyPolicy", policy =>
                {
                    // Allow Any Request and any origin in MyPloicy Profile to request my endpoints 
                    policy.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod();
                });
            });



            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment()||app.Environment.IsProduction())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors("MyPolicy");

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
