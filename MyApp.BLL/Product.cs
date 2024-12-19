using MyApp.DAL.Entities;
using MyApp.DAL.Repositories;

namespace MyApp.BLL;

public interface IProductService
{
    Task<IEnumerable<Product>> GetAllProductsAsync();
    Task<Product> GetProductByIdAsync(string id);
    Task AddProductAsync(Product product);
    Task UpdateProductAsync(string id, Product product);
    Task DeleteProductAsync(string id);
}

public class ProductService : IProductService
{
    private readonly IRepository<Product> _repository;

    public ProductService(IRepository<Product> repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Product>> GetAllProductsAsync() => await _repository.GetAllAsync();

    public async Task<Product> GetProductByIdAsync(string id) => await _repository.GetByIdAsync(id);

    public async Task AddProductAsync(Product product) => await _repository.CreateAsync(product);

    public async Task UpdateProductAsync(string id, Product product) => await _repository.UpdateAsync(id, product);

    public async Task DeleteProductAsync(string id) => await _repository.DeleteAsync(id);
}


