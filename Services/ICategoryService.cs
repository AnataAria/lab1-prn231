using System.Reflection;
using Models.Entities;
using Repositories;

namespace Services;

public interface ICategoryService
{
    public List<Category> GetCategories();
    public abstract Category GetCategoryById (int categoryId);
}