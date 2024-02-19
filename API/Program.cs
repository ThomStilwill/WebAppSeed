using Application;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Foundation.Helpers;
using Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Text.Json;
using Domain.Weather;

namespace API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);




            builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

            builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
            {
                containerBuilder.RegisterModule(new APIModule());
                containerBuilder.RegisterModule(new ApplicationModule());
                containerBuilder.RegisterModule(new InfrastructureModule());
            });

            // Add modules
            builder.Services.AddApplication();
            builder.Services.AddInfrastructure();

            // Add services to the container.
            builder.Services.AddControllers();

            builder.Services.ConfigureHttpJsonOptions(options =>
                {
                    RegisterConverters(options.SerializerOptions);
                });

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();
            
            app.UseDefaultFiles();
            app.UseStaticFiles();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();

            app.MapControllers();
            app.MapFallbackToFile("/index.html");

            app.Run();
        }

        public static void RegisterConverters(JsonSerializerOptions serializerOptions)
        {
            serializerOptions.Converters.Add(new EnumerationJsonConverter<WeatherSummary, string>());
        }
    }
}
