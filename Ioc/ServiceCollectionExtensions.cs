using Application.Mappers;
using AutoMapper;
using Infrastructure.Dapper;
using Infrastructure.EF;
using Microsoft.Extensions.DependencyInjection;
using Repository.Interfaces;
using Repository.Repositories;
using Repository.UnitOfWork;

namespace Ioc
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddSingleton<IDapper, DapperRepository>();

            services.AddTransient<IBaseRepository, BaseRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork<AppDbContext>>();

            //Repositories

            //Services

            return services;
        }
    }
}