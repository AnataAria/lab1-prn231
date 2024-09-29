using Models.Entities;
using Repositories;

namespace Services.Implement;

public class ProductService(StoreDBContext dbContext) : IProductService
{
    protected readonly StoreDBContext databaseContext = dbContext;
    
    public Product GetProductById(int prodId)
    {
        try {
            return databaseContext.Products.SingleOrDefault(x => x.ProductId == prodId);
        } catch (Exception e) {
            throw new Exception(e.Message);
        }
    }

    public List<Product> GetProducts()
    {
        try {
            return databaseContext.Products.ToList();
        } catch (Exception e) {
            throw new Exception(e.Message);
        }
    }

    public void RemoveProduct(Product p)
    {
        try {
            databaseContext.Products.Remove(p);
            databaseContext.SaveChanges();
        } catch (Exception e) {
            throw new Exception(e.Message);
        }
    }

    public void SaveProduct(Product p)
    {
        try {
            databaseContext.Products.Add(p);
            databaseContext.SaveChanges();
        } catch (Exception e) {
            throw new Exception(e.Message);
        }
    }

    public void UpdateProduct(Product p)
    {
        try {
            databaseContext.Entry<Product>(p).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            databaseContext.SaveChanges();
        } catch (Exception e) {
            throw new Exception(e.Message);
        }
    }
}
