using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.Models;

namespace BAL
{
    public interface ICategoryRepository
    {
        IEnumerable<CategoryViewModel> GetCategories();
        CategoryViewModel GetCategory(int CategoryId);
        bool AddCategory(CategoryViewModel model);
        bool UpdateCategory(CategoryViewModel model);
        bool DeleteCategory(int CategoryId); 
    }
}
