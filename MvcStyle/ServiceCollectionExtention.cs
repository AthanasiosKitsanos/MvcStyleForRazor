using Microsoft.Extensions.DependencyInjection;
using MvcStyle.Services;

namespace MvcStyle.ServiceCollection;

public static class ServicesCollectionExtention
{
    public static IServiceCollection AddMvcStyle(this IServiceCollection services)
    {
        services.AddScoped<IAntiForgeryServices, AntiForgeryServices>();

        services.AddScoped<IControllerServices, ControllerServices>();
        
        services.AddHttpContextAccessor();

        return services;
    }
}