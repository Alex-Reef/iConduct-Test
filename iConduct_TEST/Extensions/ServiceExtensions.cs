using iConduct.Infrastructure.Repositories;
using iConduct.Application.Services;
using iConduct_TEST.Filters;

namespace iConduct_TEST.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<ValidationFilter>();

            return services;
        }
    }
}
