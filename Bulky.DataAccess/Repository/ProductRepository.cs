#pragma warning disable CS8602
using Bulky.DataAccess.Data;
using Bulky.DataAccess.Repository.IRepository;
using Bulky.Models;

namespace Bulky.DataAccess.Repository
{
    public class ProductRepository(ApplicationDbContext db)
        : Repository<Product>(db),
            IProductRepository
    {
        private readonly ApplicationDbContext _db = db;

        public void Update(Product obj)
        {
            _ = _db.Products.Update(obj);
        }
    }
}
