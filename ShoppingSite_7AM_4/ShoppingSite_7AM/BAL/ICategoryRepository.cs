using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;

namespace BAL
{
    public interface ICategoryRepository
    {
        IEnumerable<CategoryViewModel> GetCategories();
        CategoryViewModel GetCategory(int id);
        bool AddCategory(CategoryViewModel model);
        bool UpdateCategory(CategoryViewModel model);    
    }
}
