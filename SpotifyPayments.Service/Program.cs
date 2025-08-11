
using Hangfire;
using Hangfire.Storage.SQLite;
using Microsoft.EntityFrameworkCore;
using SpotifyPayment.Domain;
using SpotifyPayment.Domain.Repository;
using SpotifyPayment.Domain.Repository.Repositories;
using SpotifyPayment.Domain.Seeders;
using SpotifyPayments.Application;
using SpotifyPayments.Application.Services;
using SpotifyPayments.Service.Middleware;

namespace SpotifyPayments.Service
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<DataContext>(options =>
            options.UseSqlite("Data Source=app.db"));

            builder.Services.AddHangfire(config =>
                config.UseSQLiteStorage("Data Source=hangfire.db"));

            builder.Services.AddHangfireServer();

            builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ApplicationAssemblyReference).Assembly));

            builder.Services.AddAutoMapper(cfg => { }, typeof(DomainAssemblyReference));

            // Repositories
            builder.Services.AddScoped<IClientRepository, ClientRepository>();
            builder.Services.AddScoped<IPaymentRepository, PaymentRepository>();
            builder.Services.AddScoped<IBalanceRepository, BalanceRepository>();

            // Services
            builder.Services.AddScoped<IBalanceService, BalanceService>();
            builder.Services.AddScoped<IEmailService, EmailService>();

            //builder.Services.AddScoped<IClientSeeder, ClientSeeder>();

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowLocalhost", policy =>
                {
                    policy.AllowAnyOrigin()
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                });
            });

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

            app.UseMiddleware<GlobalExceptionHandlingMiddleware>();

            var scope = app.Services.CreateScope();
            var recurringJob = scope.ServiceProvider.GetRequiredService<IRecurringJobManager>();
            recurringJob.AddOrUpdate<IEmailService>(
                "monthly-reminder",
                service => service.SendEmailAsync("s.pagacz123@gmail.com", "Sebi", "Dupa?"),
                "*/1 * * * *");

            app.UseCors("AllowLocalhost");

            app.UseHangfireDashboard("/hangfire");

            app.Run();
        }
    }
}
