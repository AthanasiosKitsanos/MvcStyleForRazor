using Microsoft.Extensions.DependencyInjection;
using MvcStyle.Services;
using MvcStyle.Services.IServices;
using MvcStyle.Services.Services;

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