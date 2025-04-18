using SunnyBlazor.Data;

namespace SunnyBlazor.Repository.IRepository
{
    public interface IProductRepository
    {
        Task<Product> CreateAsync(Product Product);
        Task<Product> UpdateAsync(Product Product);
        Task<bool> DeleteAsync(int id);
        Task<Product> GetAsync(int id);
        Task<IEnumerable<Product>> GetAllAsync();
    }
}
