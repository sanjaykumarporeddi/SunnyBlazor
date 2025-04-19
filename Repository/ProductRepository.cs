using Microsoft.EntityFrameworkCore;
using SunnyBlazor.Data;
using SunnyBlazor.Repository.IRepository;

namespace SunnyBlazor.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _db;
        public ProductRepository(ApplicationDbContext db)
        {
            this._db = db;
            
        }
        public async Task<Product> CreateAsync(Product Product)
        {
           _db.Product.Add(Product);
            await _db.SaveChangesAsync();
            return Product;
        }

        public async Task<bool> DeleteAsync(int id)
        {
           var obj= await _db.Product.FirstOrDefaultAsync(u =>  u.Id == id);
            if (obj != null)
            {
                _db.Product.Remove(obj);
                return await _db.SaveChangesAsync() > 0;
            }
            return false;
        }

        public async Task<Product> GetAsync(int id)
        {
            var obj = await _db.Product.FirstOrDefaultAsync(u => u.Id == id);
            if (obj != null)
            {
                return obj;
            }
            return new Product();
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _db.Product.Include(u => u.Category).ToListAsync();
        }

        public async Task<Product> UpdateAsync(Product Product)
        {
            var objFromDb= await _db.Product.FirstOrDefaultAsync(u => u.Id == Product.Id);
            if (objFromDb != null)
            {
                objFromDb.Name = Product.Name;
                _db.Update(objFromDb);
                await _db.SaveChangesAsync();
                return objFromDb;
            }
            return Product;
        }
    }
}
