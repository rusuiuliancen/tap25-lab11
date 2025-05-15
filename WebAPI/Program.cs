using Hangfire;
using WebAPI.Contracts;
using WebAPI.Services;

namespace WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Add Hangfire services
            builder.Services.AddHangfire(config =>
            {
                config.UseInMemoryStorage();
            });

            builder.Services.AddHangfireServer();

            builder.Services.AddScoped<IJobService, JobService>();
            builder.Services.AddScoped<IImageService, ImageService>();
            builder.Services.AddScoped<IEmailService, EmailService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            // Optionally, add Hangfire Dashboard (secured as needed)
            app.UseHangfireDashboard();

            app.MapControllers();

            app.Run();
        }
    }
}
