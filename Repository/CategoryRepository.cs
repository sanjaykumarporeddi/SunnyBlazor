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
        public Category Create(Category category)
        {
           _db.Category.Add(category);
            _db.SaveChanges();
            return category;
        }

        public bool Delete(int id)
        {
           var obj= _db.Category.FirstOrDefault(u =>  u.Id == id);
            if (obj != null)
            {
                _db.Remove(id);
                return _db.SaveChanges() > 0;
            }
            return false;
        }

        public Category Get(int id)
        {
            var obj = _db.Category.FirstOrDefault(u => u.Id == id);
            if (obj != null)
            {
                return obj;
            }
            return new Category();
        }

        public IEnumerable<Category> GetAll()
        {
            return _db.Category.ToList();
        }

        public Category Update(Category category)
        {
            var objFromDb= _db.Category.FirstOrDefault(u => u.Id == category.Id);
            if (objFromDb != null)
            {
                objFromDb.Name = category.Name;
                _db.Update(objFromDb);
                _db.SaveChanges();
                return objFromDb;
            }
            return category;
        }
    }
}
