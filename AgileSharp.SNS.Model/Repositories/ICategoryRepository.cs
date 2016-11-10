using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AgileSharp.SNS.Model.Entities;

namespace AgileSharp.SNS.Model.Repositories
{
    public interface ICategoryRepository
    {
        bool Save(Category category);
        bool Delete(int categoryId);

        List<Category> GetAllCategories();
        Category GetCategoryById(int categoryId);
        Category GetCategoryByName(string categoryName);
    }
}
