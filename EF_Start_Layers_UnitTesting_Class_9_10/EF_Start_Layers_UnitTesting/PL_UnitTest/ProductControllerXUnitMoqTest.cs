﻿using System;
using ViewModels.Models;
using System.Collections.Generic;
using EF_Start.Controllers;
using System.Web.Mvc;
using Xunit;
using Moq;
using BAL;

namespace PL_UnitTest
{
    public class ProductControllerXUnitMoqTest
    {
        ProductViewModel p1;
        ProductViewModel p2;
        ProductViewModel p3;
        ProductViewModel p4;

        List<ProductViewModel> list_prod;
        Mock<IProductRepository> repo_product;

        CategoryViewModel c1;
        CategoryViewModel c2;

        List<CategoryViewModel> list_cat;
        Mock<ICategoryRepository> repo_cat;

        ProductController ctrl;
        public ProductControllerXUnitMoqTest()
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

            repo_product = new Mock<IProductRepository>();

            c1 = new CategoryViewModel { CategoryId = 1, Name = "Books" };
            c2 = new CategoryViewModel { CategoryId = 2, Name = "Pens" };

            list_cat = new List<CategoryViewModel>();
            list_cat.Add(c1); list_cat.Add(c2);

            repo_cat = new Mock<ICategoryRepository>();

            ctrl = new ProductController(repo_product.Object, repo_cat.Object);
        }

        [Fact]
        public void Index()
        {
            //setup
            repo_product.Setup(p => p.GetProducts()).Returns(list_prod);

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
            
            //setup
            repo_product.Setup(p => p.AddProduct(p4)).Callback((ProductViewModel obj) =>
            {
                list_prod.Add(obj);
            });

            ctrl.Create(p4);


            //setup
            repo_product.Setup(p => p.GetProducts()).Returns(list_prod);
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
            repo_product.Setup(p => p.GetProduct(id)).Returns(p1);

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
            //setup
            repo_product.Setup(p => p.UpdateProduct(p4)).Callback((ProductViewModel model) =>
            {
                for (int i = 0; i < list_prod.Count; i++)
                {
                    if (list_prod[i].ProductId == model.ProductId)
                    {
                        list_prod[i].Name = model.Name;
                        list_prod[i].UnitPrice = model.UnitPrice;
                    }
                }
            });

            ctrl.Edit(p1);

            //setup
            repo_product.Setup(p => p.GetProduct(p1.ProductId)).Returns(p1);
            //action
            var result = ctrl.Edit(p1.ProductId) as ViewResult;

            //actual result
            ProductViewModel obj = result.Model as ProductViewModel;

            //expecting
            Assert.Equal(p1, obj);
        }

        [Fact]
        public void Delete()
        {
            int id = 1; //for p1 object
            repo_product.Setup(p => p.DeleteProduct(id)).Callback((int ProductId) =>
            {
                ProductViewModel model = list_prod.Find(p => p.ProductId == ProductId);
                if (model != null)
                {
                    list_prod.Remove(model);
                }
            });

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
