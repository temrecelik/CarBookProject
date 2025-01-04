using CarBook.Application.Features.CQRS.Handler.AboutHandler;
using CarBook.Application.Features.CQRS.Handler.BannerHandler;
using CarBook.Application.Features.CQRS.Handler.BrandHandler;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application
{
    public static class ServiceRegistration
    {
        /*
         Başka bir classta service kodlarını yazarak program.cs'de direkt olarak bu service ayağa kaldırırsak 
         kodlarımızı daha düzenli ve daha okunabilir bir hale getirmiş oluruz.
         */
        public static void AppApplicationService(this IServiceCollection services)
        {
            services.AddScoped<GetAboutByIdQueryHandler>();
            services.AddScoped<GetAboutQueryHandler>();
            services.AddScoped<CreateAboutCommandHandler>();
            services.AddScoped<UpdateAboutCommandHandler>();
            services.AddScoped<RemoveAboutCommandHandler>();

            services.AddScoped<GetBannerByIdQueryHandler>();
            services.AddScoped<GetBannerQueryHandler>();
            services.AddScoped<CreateBannerCommandHandler>();
            services.AddScoped<UpdateBannerCommandHandler>();
            services.AddScoped<RemoveBannerCommandHandler>();

            services.AddScoped<GetBrandByIdQueryHandler>();
            services.AddScoped<GetBrandQueryHandler>();
            services.AddScoped<CreateBrandCommandHandler>();
            services.AddScoped<UpdateBrandCommandHandler>();
            services.AddScoped<RemoveBrandCommandHandler>();
        }
    }
}
