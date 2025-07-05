using System.Net.Http.Json;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Routing;

namespace MvcStyle.Services;

public class ControllerServices : IControllerServices
{
    private readonly IHttpContextAccessor _accessor;
    private readonly IUrlHelperFactory _urlHelper;
    private readonly HttpClient _httpClient;
    private readonly NavigationManager _navigation;

    public ControllerServices(IHttpContextAccessor accessor, IUrlHelperFactory urlHelper, HttpClient httpClient, NavigationManager navigation)
    {
        _accessor = accessor;
        _urlHelper = urlHelper;
        _httpClient = httpClient;
        _navigation = navigation;
    }

    public async Task<TModel> HttpGetJsonAsync<TModel>(string action, string controller, int? id = null) where TModel : class
    {
        string actionUrl = CreateUrl(action, controller, id);

        TModel model = await _httpClient.GetFromJsonAsync<TModel>(CombineUrls(_navigation.BaseUri, actionUrl)) ?? null!;

        return model;
    }

    private string CombineUrls(string baseUri, string relativeUrl)
    {
        if (string.IsNullOrWhiteSpace(baseUri))
        {
            return relativeUrl;
        }

        if (string.IsNullOrWhiteSpace(relativeUrl))
        {
            return baseUri;
        }

        return $"{baseUri.TrimEnd('/')}/{relativeUrl.TrimStart('/')}";
    }

    private string CreateUrl(string action, string controller, int? id)
    {
        Dictionary<string, string>? routeValue = null;

        if (id.HasValue)
        {
            routeValue = new Dictionary<string, string>
            {
                ["id"] = id.Value.ToString()
            };
        }

        string actionUrl = string.Empty;

        HttpContext httpContext = _accessor.HttpContext;

        if (httpContext is not null)
        {
            var actionContext = new ActionContext
            (
                httpContext,
                httpContext.GetRouteData() ?? new Microsoft.AspNetCore.Routing.RouteData(),
                new Microsoft.AspNetCore.Mvc.Abstractions.ActionDescriptor()
            );

            IUrlHelper url = _urlHelper.GetUrlHelper(actionContext);
            actionUrl = url.Action(action, controller, routeValue);
        }

        return actionUrl;
    }
}
