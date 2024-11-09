using E_CommerceApi.Repository.IRepository;
using Laptopy.Data;
using Laptopy.Models;
using Laptopy.Repository;
using Laptopy.Repository.IRepository;

namespace E_CommerceApi.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly ApplicationDbContext dbContext;

        public ProductRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }
    }
}
