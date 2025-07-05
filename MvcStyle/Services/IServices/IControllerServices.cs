namespace MvcStyle.Services.IServices;

public interface IControllerServices
{
    Task<TModel> HttpGetJsonAsync<TModel>(string action, string controller, int? id) where TModel: class;
}
