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
        public async Task<IEnumerable<Product>> GetAllProductByIdAsync()
        {
            return await _dbContext.Products.ToListAsync();
        }
       
        public async Task<int> AddProductAsync(Product product)
        {
            try
            {
                await _dbContext.Database.BeginTransactionAsync();
                _dbContext.Products.Add(product);
                await _dbContext.SaveChangesAsync();
                await _dbContext.Database.CommitTransactionAsync();
                return product.Id;
            }
            catch (Exception ex)
            {
                // Rollback the transaction in case of error
                await _dbContext.Database.RollbackTransactionAsync();
                throw new Exception("An error occurred while creating the product.", ex);
            }
        }
        public async Task<bool> UpdateProductAsync(Product product)
        {
            try
            {
                await _dbContext.Database.BeginTransactionAsync();
                _dbContext.Products.Update(product);
                return await _dbContext.SaveChangesAsync() > 0;
                await _dbContext.Database.CommitTransactionAsync();
            }
            catch (Exception ex)
            {
                // Rollback the transaction in case of error
                await _dbContext.Database.RollbackTransactionAsync();
                throw new Exception("An error occurred while creating the product.", ex);
            }
             
        }
        public async Task<bool> DeleteProductAsync(int id)
        {
            try
            {
                await _dbContext.Database.BeginTransactionAsync();
                var product = await GetProductByIdAsync(id);
                if (product == null) return false;
                _dbContext.Products.Remove(product);
                
                return await _dbContext.SaveChangesAsync() > 0;
                await _dbContext.Database.CommitTransactionAsync();
            }
            catch (Exception ex)
            {
                // Rollback the transaction in case of error
                await _dbContext.Database.RollbackTransactionAsync();
                throw new Exception("An error occurred while creating the product.", ex);
            }
            
        }

     
    }
}
