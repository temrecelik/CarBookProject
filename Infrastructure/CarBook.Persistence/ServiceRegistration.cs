using CarBook.Application.Features.CQRS.Handler.AboutHandler;
using CarBook.Application.Interfaces;
using CarBook.Persistence.Context;
using CarBook.Persistence.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistence
{
    public static class ServiceRegistration
    {

        public static void AppPersistenceService(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>) , typeof(Repository<>));
            services.AddScoped<CarBookContext>();
        }
    }
}
