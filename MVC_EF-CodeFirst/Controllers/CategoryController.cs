using AutoMapper;
using MVC_EF_CodeFirst.Models;
using MVC_EF_CodeFirst.Models.Context;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MVC_EF_CodeFirst.Controllers
{
    public class CategoryController : Controller
    {
        private readonly EfDbContext _dbContext;

        public CategoryController()
        {
            _dbContext = new EfDbContext();
        }
        // GET: Category
        public ActionResult Index(int? page)
        {
            var categoryList = _dbContext.Categories.ToList().ToPagedList(page ?? 1, 5);
            return View(categoryList);
        }

        // GET: Category/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Category/Create
        [HttpPost]
        public ActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Categories.Add(category);
                _dbContext.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        // GET: Category/Edit/5
        public ActionResult Edit(int? id)
        {

            Category category = _dbContext.Categories.Find(id);
            return View(category);
        }

        // POST: Category/Edit/5
        [HttpPost]
        public ActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                Category model = _dbContext.Categories.Find(category.CategoryId);

                if (model != null)
                {
                    model.CategoryName = category.CategoryName;
                    _dbContext.SaveChanges();
                }
            }
            return RedirectToAction("Index", HttpStatusCode.OK);
        }

        // GET: Category/Delete/5
        public ActionResult Delete(int? id)
        {
            Category category = _dbContext.Categories.Find(id);
            return View(category);
        }

        // POST: Category/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? id)
        {
            if (ModelState.IsValid)
            {
                var model = _dbContext.Categories.Find(id);

                _dbContext.Categories.Remove(model);
                _dbContext.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        /// <summary>
        /// Product Category-List
        /// </summary>
        /// <returns></returns>

        // GET: Product/List
        public ActionResult Home(int? page)
        {
            var model = _dbContext.Products.Include(c => c.ProductCategory).ToList().ToPagedList(page ?? 1, 5);
            return View(model);
        }

        // GET: Product/Create
        public ActionResult CreateProduct()
        {
            ProductCategoryViewModel viewModel = new ProductCategoryViewModel
            {
                ProductCategory = _dbContext.Categories.ToList()
            };
            return View(viewModel);
        }

        // POST: Product/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateProduct(ProductCategoryViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Product product = new Product
                {
                    ProductName = viewModel.ProductName,
                    ProductCategory = _dbContext.Categories.Where(c => c.CategoryId == viewModel.CategoryId).FirstOrDefault()
                };
                _dbContext.Products.Add(product);
                _dbContext.SaveChanges();
                return RedirectToAction("Home", HttpStatusCode.Created);
            }
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }

        // GET: Product/Edit/5
        public ActionResult EditProduct(int? id)
        {
            ProductCategoryViewModel viewModel = new ProductCategoryViewModel
            {
                ProductId = (int)id,
                ProductName = _dbContext.Products.FirstOrDefault(p => p.ProductId == id).ProductName,
                ProductCategory = _dbContext.Categories.ToList()
            };

            return View(viewModel);
        }

        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult EditProduct(ProductCategoryViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Product product = new Product
                {
                    ProductId = viewModel.ProductId,
                    ProductName = viewModel.ProductName,
                    ProductCategory = _dbContext.Categories.FirstOrDefault(p => p.CategoryId == viewModel.CategoryId)
                };
                product.ProductName = _dbContext.Products.FirstOrDefault(p => p.ProductName == viewModel.ProductName).ProductName;
                product.ProductCategory.CategoryName = _dbContext.Categories.FirstOrDefault(c => c.CategoryId == viewModel.CategoryId).CategoryName;
                _dbContext.SaveChanges();
                return RedirectToAction("Home", HttpStatusCode.OK);
            }
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }

        // GET: Product/Delete/5
        public ActionResult DeleteProduct(int? id)
        {
            ProductCategoryViewModel viewModel = new ProductCategoryViewModel
            {
                ProductId = (int)id,
            };
            return View(viewModel);
        }

        // POST: Product/Delete/5
        [HttpPost]
        [ActionName("DeleteProduct")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteProductConfirmed(int? id)
        {
            if (ModelState.IsValid)
            {
                var model = _dbContext.Products.Find(id);

                _dbContext.Products.Remove(model);
                _dbContext.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
