using Example.Api.Common.Errors;
using Example.Api.Common.Mapping;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace Example.Api
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPresentation(this IServiceCollection services)
        {
            services.AddControllers();
            services.AddMappings();
            services.AddSingleton<ProblemDetailsFactory, CustomProblemDetailsFactory>();

            return services;
        }
    }
}
