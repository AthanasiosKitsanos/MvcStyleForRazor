namespace MvcStyle.Services;

public interface IControllerServices
{
    Task<TModel> HttpGetJsonAsync<TModel>(string action, string controller, int? id = null) where TModel: class;
}
