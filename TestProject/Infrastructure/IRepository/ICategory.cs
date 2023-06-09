using TestProject.Models;

namespace TestProject.Infrastructure.IRepository
{
    public interface ICategory
    {
        List<CategoryInfo> GetCategoryData();
        CategoryInfo GetCategoryById(int id);
        CategoryInfo AddCategory(CategoryInfo categoryInfo);
        CategoryInfo UpdateCategory(CategoryInfo categoryInfo);
        CategoryInfo DeleteCategory(CategoryInfo infomodel);
    }
}
