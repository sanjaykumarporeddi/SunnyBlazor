using Microsoft.EntityFrameworkCore;
using SunnyBlazor.Data;
using SunnyBlazor.Repository.IRepository;

namespace SunnyBlazor.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _db;
        public CategoryRepository(ApplicationDbContext db)
        {
            this._db = db;
            
        }
        public async Task<Category> CreateAsync(Category category)
        {
           _db.Category.Add(category);
            await _db.SaveChangesAsync();
            return category;
        }

        public async Task<bool> DeleteAsync(int id)
        {
           var obj= await _db.Category.FirstOrDefaultAsync(u =>  u.Id == id);
            if (obj != null)
            {
                _db.Category.Remove(obj);
                return await _db.SaveChangesAsync() > 0;
            }
            return false;
        }

        public async Task<Category> GetAsync(int id)
        {
            var obj = await _db.Category.FirstOrDefaultAsync(u => u.Id == id);
            if (obj != null)
            {
                return obj;
            }
            return new Category();
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await _db.Category.ToListAsync();
        }

        public async Task<Category> UpdateAsync(Category category)
        {
            var objFromDb= await _db.Category.FirstOrDefaultAsync(u => u.Id == category.Id);
            if (objFromDb != null)
            {
                objFromDb.Name = category.Name;
                _db.Update(objFromDb);
                await _db.SaveChangesAsync();
                return objFromDb;
            }
            return category;
        }
    }
}
