using Clockwork.Application.TimeInquiries;
using Clockwork.Domain.Repositories;
using Clockwork.Domain.Services;
using Clockwork.Infrastructure.EFCore.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Clockwork.API
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection SetupDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<ITimeInquiryRepository, TimeInquiryRepository>();
            services.AddScoped<ITimeInquiryService, TimeInquiryService>();

            return services;
        }
    }
}
