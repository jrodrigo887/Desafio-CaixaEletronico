using CaixaEletronico.Domain;
using CaixaEletronico.Domain.Interfaces;
using CaixaEletronico.Domain.Interfaces.Repository;
using CaixaEletronico.Infra.Data.Repositories;
using CaixaEletronico.Services.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaixaEletronico.Application.Setup
{
    public static class DependecyInjection
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            // Repositories
            //services.AddScoped<IBaseRepository<User>, IBaseRepository<User>>();
            services.AddScoped<IBaseRepository<User>, UserRepository>();
            services.AddScoped<IContaRepository, ContaRepository>();

            // Services
            //services.AddScoped<IBaseService<User>, BaseService<User>>();
            services.AddScoped<UserService>();
            services.AddScoped<ContaService>();

        }

        private static NewtonsoftJsonPatchInputFormatter GetJsonPatchInputFormatter()
        {
            var builder = new ServiceCollection()
                .AddLogging()
                .AddMvc()
                .AddNewtonsoftJson()
                .Services.BuildServiceProvider();

            return builder
                .GetRequiredService<IOptions<MvcOptions>>()
                .Value
                .InputFormatters
                .OfType<NewtonsoftJsonPatchInputFormatter>()
                .First();
        }
    }
}
