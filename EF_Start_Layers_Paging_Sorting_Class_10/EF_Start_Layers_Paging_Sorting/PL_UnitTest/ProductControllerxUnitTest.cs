using System;
using ViewModels.Models;
using PL_UnitTest.FakeObjects;
using System.Collections.Generic;
using EF_Start.Controllers;
using System.Web.Mvc;
using Xunit;

namespace PL_UnitTest
{
    public class ProductControllerXUnitTest
    {
        ProductViewModel p1;
        ProductViewModel p2;
        ProductViewModel p3;
        ProductViewModel p4;

        List<ProductViewModel> list_prod;
        FakeProductRepository repo_product;

        CategoryViewModel c1;
        CategoryViewModel c2;

        List<CategoryViewModel> list_cat;
        FakeCategoryRepository repo_cat;

        ProductController ctrl;
        public ProductControllerXUnitTest()
        {
            //A - Arrangement
            //A - Action
            //A - Assert

            p1 = new ProductViewModel { ProductId = 1, Name = "MVC Book", UnitPrice = 120M, CategoryId = 1 };
            p2 = new ProductViewModel { ProductId = 2, Name = "Node.js Book", UnitPrice = 120M, CategoryId = 1 };
            p3 = new ProductViewModel { ProductId = 3, Name = "parker", UnitPrice = 20M, CategoryId = 2 };

            list_prod = new List<ProductViewModel>();
            list_prod.Add(p1);
            list_prod.Add(p2);
            list_prod.Add(p3);

            repo_product = new FakeProductRepository(list_prod);

            c1 = new CategoryViewModel { CategoryId = 1, Name = "Books" };
            c2 = new CategoryViewModel { CategoryId = 2, Name = "Pens" };

            list_cat = new List<CategoryViewModel>();
            list_cat.Add(c1); list_cat.Add(c2);

            repo_cat = new FakeCategoryRepository(list_cat);

            ctrl = new ProductController(repo_product, repo_cat);
        }

        [Fact]
        public void Index()
        {
            //action
            var result = ctrl.Index() as ViewResult;

            //actual result
            List<ProductViewModel> listModel = result.Model as List<ProductViewModel>;

            //expecting
            Assert.Contains(p1, listModel);
            Assert.Contains(p2, listModel);
            Assert.Contains(p3, listModel);
        }

        [Fact]
        public void Create()
        {
            p4 = new ProductViewModel { ProductId = 4, Name = "Ionic Book", UnitPrice = 180M, CategoryId = 1 };

            ctrl.Create(p4);

            //action
            var result = ctrl.Index() as ViewResult;

            //actual result
            List<ProductViewModel> listModel = result.Model as List<ProductViewModel>;

            //expecting
            Assert.Contains(p4, listModel);
        }

        [Fact]
        public void Edit()
        {
            int id = 1;
            //action
            var result = ctrl.Edit(id) as ViewResult;

            //actual result
            ProductViewModel model = result.Model as ProductViewModel;

            //expecting
            Assert.Equal(p1, model);
        }

        [Fact]
        public void Update()
        {
            p1.Name = "ASP.NET MVC Book";
            ctrl.Edit(p1);

            //action
            var result = ctrl.Edit(p1.ProductId) as ViewResult;

            //actual result
            ProductViewModel model = result.Model as ProductViewModel;

            //expecting
            Assert.Equal(p1, model);
        }

        [Fact]
        public void Delete()
        {
            int id = 1; //for p1 object
            //action
            ctrl.Delete(id);

            //action
            var result = ctrl.Index() as ViewResult;

            //actual result
            List<ProductViewModel> listModel = result.Model as List<ProductViewModel>;

            //expecting
            Assert.DoesNotContain(p1, listModel);

            //fails
            //Assert.Contains(p1, listModel);
        }
    }
}
