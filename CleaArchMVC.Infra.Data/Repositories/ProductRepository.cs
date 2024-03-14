using CleaArchMVC.Domain.Entities;
using CleaArchMVC.Domain.Interfaces;
using CleaArchMVC.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace CleaArchMVC.Infra.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        ApplicationDbContext _productContext;
        public ProductRepository(ApplicationDbContext context)
        {
            _productContext = context;
        }
        public async Task<Product> CreateAsync(Product product)
        {
            _productContext.Add(product);
            _productContext.SaveChangesAsync();
            return product;
        }

        public async Task<Product> GetByIdAsync(int? id)
        {
            return await _productContext.Products.FindAsync(id);
        }

        public async Task<IEnumerable<Product>> GetProductAsync()
        {
            return await _productContext.Products.ToListAsync();
        }

        public async Task<Product> GetProductCategoryAsync(int? id)
        {
            return await _productContext.Products.Include(c => c.Category)
                .SingleOrDefaultAsync(p => p.ID == id);
        }

        public async Task<Product> RemoveAsync(Product product)
        {
            _productContext.Remove(product);
            await _productContext.SaveChangesAsync();
            return product;
        }

        public async Task<Product> UpdateAsync(Product product)
        {
            _productContext.Update(product);
            await _productContext.SaveChangesAsync();
            return product;
        }
    }
}
