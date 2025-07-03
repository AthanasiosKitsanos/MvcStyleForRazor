using Microsoft.Extensions.DependencyInjection;

namespace MvcStyleForRazor.ServiceCollection;

public static class ServicesCollectionExtention
{
    public static IServiceCollection AddMvcStyle(this IServiceCollection services)
    {
        services.AddScoped<IAntiForgeryServices, AntiForgeryServices>();

        return services;
    }
}
