using Microsoft.Extensions.DependencyInjection;

namespace MvcStyle.ServiceCollection;

public static class ServicesCollectionExtention
{
    public static IServiceCollection AddMvcStyle(this IServiceCollection services)
    {
        services.AddScoped<IAntiForgeryServices, AntiForgeryServices>();

        return services;
    }
}
