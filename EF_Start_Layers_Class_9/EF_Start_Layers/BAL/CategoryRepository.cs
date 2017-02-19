using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.Models;
namespace BAL
{
    public class CategoryRepository : ICategoryRepository
    {
        DatabaseContext db = new DatabaseContext();
        public IEnumerable<CategoryViewModel> GetCategories()
        {
            //List<Category> data = db.Categories.ToList(); 
            //or
            List<Category> data = db.Categories.Select(c => c).ToList();
            List<CategoryViewModel> modelList = new List<CategoryViewModel>();

            foreach (var item in data)
            {
                CategoryViewModel obj = new CategoryViewModel();
                obj.CategoryId = item.CategoryId;
                obj.Name = item.Name;

                modelList.Add(obj);
            }
            return modelList;
        }

        public CategoryViewModel GetCategory(int CategoryId)
        {
            throw new NotImplementedException();
        }

        public bool AddCategory(CategoryViewModel model)
        {
            throw new NotImplementedException();
        }

        public bool UpdateCategory(CategoryViewModel model)
        {
            throw new NotImplementedException();
        }

        public bool DeleteCategory(int CategoryId)
        {
            throw new NotImplementedException();
        }
    }
}
