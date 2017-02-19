using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;
namespace BAL
{
    public class CategoryRepository : ICategoryRepository
    {
        DatabaseContext db = new DatabaseContext();
        public IEnumerable<CategoryViewModel> GetCategories()
        {
            List<Category> data = db.Categories.ToList();
            List<CategoryViewModel> model = new List<CategoryViewModel>();

            foreach (var item in data)
            {
                CategoryViewModel obj = new CategoryViewModel();
                obj.CategoryId = item.CategoryId;
                obj.Name = item.Name;

                model.Add(obj);
            }
            return model;
        }

        public CategoryViewModel GetCategory(int id)
        {
            Category obj = db.Categories.Find(id);
            CategoryViewModel cat = new CategoryViewModel();

            cat.CategoryId = obj.CategoryId;
            cat.Name = obj.Name;
            return cat;
        }

        public bool AddCategory(CategoryViewModel model)
        {
            try
            {
                Category obj = new Category();

                obj.Name = model.Name;
                obj.CreatedDate = DateTime.Now;
                db.Categories.Add(obj);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool UpdateCategory(CategoryViewModel model)
        {
            try
            {
                Category obj = new Category();
                obj.CategoryId = model.CategoryId;
                obj.Name = model.Name;

                db.Entry(obj).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
