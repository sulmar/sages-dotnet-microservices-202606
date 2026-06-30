namespace BlazorApp.Services;

public interface IProductService
{
    Task<List<Model.Product>?> GetAllAsync();
}
