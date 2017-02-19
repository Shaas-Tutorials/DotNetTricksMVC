using BAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.Models;

namespace PL_UnitTest.FakeObjects
{
    public class FakeCategoryRepository : ICategoryRepository
    {
        List<CategoryViewModel> db;
        public FakeCategoryRepository(List<CategoryViewModel> _db)
        {
            db = _db;
        }
        public IEnumerable<CategoryViewModel> GetCategories()
        {
            return db;
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
