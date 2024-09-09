using Models.Entities;

namespace Services.Implement;

public class ProductService : IProductService
{
    public override Product GetProductById(int prodId)
    {
        try {
            return databaseContext.Products.SingleOrDefault(x => x.ProductId == prodId);
        } catch (Exception e) {
            throw new Exception(e.Message);
        }
    }

    public override List<Product> GetProducts()
    {
        try {
            return databaseContext.Products.ToList();
        } catch (Exception e) {
            throw new Exception(e.Message);
        }
    }

    public override void RemoveProduct(Product p)
    {
        try {
            databaseContext.Products.Remove(p);
            databaseContext.SaveChanges();
        } catch (Exception e) {
            throw new Exception(e.Message);
        }
    }

    public override void SaveProduct(Product p)
    {
        try {
            databaseContext.Products.Add(p);
            databaseContext.SaveChanges();
        } catch (Exception e) {
            throw new Exception(e.Message);
        }
    }

    public override void UpdateProduct(Product p)
    {
        try {
            databaseContext.Entry<Product>(p).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            databaseContext.SaveChanges();
        } catch (Exception e) {
            throw new Exception(e.Message);
        }
    }
}
