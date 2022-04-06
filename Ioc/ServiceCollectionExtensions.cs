using Infrastructure.Dapper;
using Infrastructure.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Repository.Interfaces;
using Repository.Repositories;
using Repository.UnitOfWork;
using System.IO;

namespace Ioc
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            var builder = new ConfigurationBuilder()
                 .SetBasePath(Directory.GetCurrentDirectory())
                 .AddJsonFile("appsettings.json");

            var configuration = builder.Build();
            services.AddMemoryCache();
            services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("Default")), ServiceLifetime.Transient);
            services.AddSingleton<IDapper, DapperRepository>();

            services.AddSingleton<IBaseRepository, BaseRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork<AppDbContext>>();

            //Repositories

            //Services

            return services;
        }
    }
}