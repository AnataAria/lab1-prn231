using System.Reflection;
using Models.Entities;
using Repositories;

namespace Services.Implement;

public class CategoryService(StoreDBContext dBContext) : ICategoryService
{
    protected readonly StoreDBContext databaseContext = dBContext;

    public List<Category> GetCategories()
    {
        try {
            return databaseContext.Categories.ToList();
        } catch (Exception e) {
            throw new Exception(e.Message);
        }
    }

    public Category GetCategoryById(int categoryId)
    {
        try {
            return databaseContext.Categories.SingleOrDefault(x => x.CategoryId == categoryId);
        } catch (Exception e) {
            throw new Exception(e.Message);
        }
    }
}
