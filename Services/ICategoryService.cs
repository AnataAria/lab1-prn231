using System.Reflection;
using Models.Entities;

namespace Services;

public abstract class ICategoryService: IBaseService
{
    public abstract List<Category> GetCategories ();
}
