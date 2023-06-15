using Autofac;
using Autofac.Core;
using Autofac.Extensions.DependencyInjection;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RoomBookings.Common.Application.Helpers;
using RoomBookings.Common.Application.Validation;
using RoomBookings.Rooms.SqlServer;
using Serilog;

namespace RoomBookings.Rooms.Application.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Host.UseSerilog((ctx, lc) => lc
                .WriteTo.Console()
                .WriteTo.File("logs\\log.txt", rollingInterval: RollingInterval.Day));

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory())
                .ConfigureContainer<ContainerBuilder>(builder =>
                {
                    var assemblies = System.Reflection.Assembly.GetExecutingAssembly().GetReferencedAssemblies("RoomBookings").Distinct().ToArray();

                    builder.RegisterAssemblyModules(assemblies);
                });

            var connectionString = builder.Configuration["ConnectionString"] ?? throw new InvalidOperationException("Connection string 'ConnectionString' not found.");

            builder.Services.AddDbContext<RoomsDbContext>(options =>
            {
                options.UseSqlServer(connectionString//,
                                                     //sqlServerOptionsAction: sqlOptions =>
                                                     //{
                                                     //    sqlOptions.MigrationsAssembly(typeof(Startup).GetTypeInfo().Assembly.GetName().Name);
                                                     //    sqlOptions.EnableRetryOnFailure(maxRetryCount: 15, maxRetryDelay: TimeSpan.FromSeconds(30), errorNumbersToAdd: null);
                                                     //}
                );
            }, ServiceLifetime.Scoped);

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

            app.Run();
        }
    }
}