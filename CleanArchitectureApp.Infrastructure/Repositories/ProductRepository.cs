using CleanArchitectureApp.Domain.Interfaces;
using CleanArchitectureApp.Domain.Model;
using CleanArchitectureApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;


namespace CleanArchitectureApp.Infrastructure.Repositories
{
    public class ProductRepository: IProductRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public ProductRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _dbContext.Products.FindAsync(id);
        }
        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await _dbContext.Products.ToListAsync();
        }
       
        public async Task<int> AddProductAsync(Product product)
        {
            _dbContext.Products.Add(product);
            await _dbContext.SaveChangesAsync();
            return product.Id;
        }
        public async Task<bool> UpdateProductAsync(Product product)
        {
            _dbContext.Products.Update(product);
            return await _dbContext.SaveChangesAsync() > 0;
             
        }
        public async Task<bool> DeleteProductAsync(int id)
        {
            var product = await GetProductByIdAsync(id);
            if (product == null) return false;
            _dbContext.Products.Remove(product);
            return await _dbContext.SaveChangesAsync() >0;
        }
    }
}
