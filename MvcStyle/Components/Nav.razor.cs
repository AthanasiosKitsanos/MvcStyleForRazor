using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Routing;


namespace MvcStyle.Components;

public class NavComponent : ComponentBase
{
    [Inject] private IHttpContextAccessor Accessor { get; set; } = default!;
    [Inject] private IUrlHelperFactory UrlHelper { get; set; } = default!;

    [Parameter] public int? routeId { get; set; }
    [Parameter] public string action { get; set; } = default!;
    [Parameter] public string controller { get; set; } = default!;
    [Parameter] public RenderFragment? ChildContent { get; set; }

    protected string ActionUrl { get; set; } = string.Empty;

    protected override Task OnInitializedAsync()
    {
        Dictionary<string, string>? RouteValue = null;

        if (routeId.HasValue)
        {
            RouteValue = new Dictionary<string, string>
            {
                ["id"] = routeId.Value.ToString()
            };
        }

        HttpContext httpContext = Accessor.HttpContext;

        if (httpContext is not null)
        {
            var actionContext = new ActionContext
            (
                httpContext,
                httpContext.GetRouteData() ?? new Microsoft.AspNetCore.Routing.RouteData(),
                new Microsoft.AspNetCore.Mvc.Abstractions.ActionDescriptor()
            );

            IUrlHelper url = UrlHelper.GetUrlHelper(actionContext);
            ActionUrl = url.Action(action, controller, RouteValue);
        }

        return Task.CompletedTask;
    }
}
