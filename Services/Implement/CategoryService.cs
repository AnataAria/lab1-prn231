using System.Reflection;
using Models.Entities;

namespace Services.Implement;

public class CategoryService : ICategoryService
{
    public override List<Category> GetCategories()
    {
        try {
            return databaseContext.Categories.ToList();
        } catch (Exception e) {
            throw new Exception(e.Message);
        }
    }
}
