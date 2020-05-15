using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Application.Interfaces;
using Application.ViewModels;
using Domain.Models;
using PagedList;

namespace MVC.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;

        public CategoryController(IProductService productService, ICategoryService categoryService)
        {
            this._productService = productService;
            this._categoryService = categoryService;
        }

        // GET: Category
        [HttpGet]
        public ActionResult Index(int? page)
        {
            if ( ModelState.IsValid )
            {
                var categoryList = _categoryService.GetCategories( ).ToPagedList( page ?? 1, 5 );
                return View( categoryList );
            }
            return View( HttpStatusCode.BadRequest );
        }

        // GET: Category/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View( );
        }

        // POST: Category/Create
        [HttpPost]
        public ActionResult Create(Category category)
        {
            if ( category != null )
            {
                _categoryService.AddCategory( category );
                return RedirectToAction( "Index" );
            }
            return Json( new JsonResult { Data = "Not found" } );
        }

        // GET: Category/Edit/5
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if ( id > 0 )
            {
                var result = _categoryService.GetCategoryById( id );
                return View( result );
            }
            return View( HttpStatusCode.BadRequest );
        }

        // POST: Category/Edit/5
        [HttpPost]
        public ActionResult Edit(Category category)
        {
            if ( category != null )
            {
                _categoryService.EditCategory( category );
            }
            return RedirectToAction( "Index", HttpStatusCode.OK );
        }

        // GET: Category/Delete/5
        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if ( id > 0 )
            {
                var result = _categoryService.GetCategoryById( id );
                return View( result );
            }
            return View( HttpStatusCode.NotFound );
        }

        // POST: Category/Delete/5
        [HttpPost]
        [ActionName( "Delete" )]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? id)
        {
            if ( ModelState.IsValid )
            {
                _categoryService.DeleteCategory( id );
                return RedirectToAction( "Index", HttpStatusCode.OK );
            }
            return View( HttpStatusCode.BadRequest );
        }

        /// <summary>
        /// Product Category-List
        /// </summary>
        /// <returns></returns>

        //GET: Product/List
        //[HttpGet]
        //public ActionResult Home(int? page)
        //{
        //    if ( ModelState.IsValid )
        //    {
        //        var model = _productService.GetProductCategory( ).ToPagedList( page ?? 1, 5 );
        //        return View( model );
        //    }
        //    return View( HttpStatusCode.BadRequest );
        //}

        //// GET: Product/Create
        //[HttpGet]
        //public ActionResult CreateProduct()
        //{
        //    ProductCategoryViewModel viewModel = new ProductCategoryViewModel
        //    {
        //        ProductCategory = _dbContext.Categories.ToList( )
        //    };
        //    return View( viewModel );
        //}

        //// POST: Product/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult CreateProduct(ProductCategoryViewModel viewModel)
        //{
        //    if ( ModelState.IsValid )
        //    {
        //        Product product = new Product
        //        {
        //            ProductName = viewModel.ProductName,
        //            ProductCategory = _dbContext.Categories.Where( c => c.CategoryId == viewModel.CategoryId ).FirstOrDefault( )
        //        };
        //        _dbContext.Products.Add( product );
        //        _dbContext.SaveChanges( );
        //        return RedirectToAction( "Home", HttpStatusCode.Created );
        //    }
        //    return new HttpStatusCodeResult( HttpStatusCode.BadRequest );
        //}

        //// GET: Product/Edit/5
        //[HttpGet]
        //public ActionResult EditProduct(int? id)
        //{
        //    ProductCategoryViewModel viewModel = new ProductCategoryViewModel
        //    {
        //        ProductId = (int)id,
        //        ProductName = _dbContext.Products.FirstOrDefault( p => p.ProductId == id ).ProductName,
        //        ProductCategory = _dbContext.Categories.ToList( )
        //    };
        //    viewModel.CategoryId = _dbContext.Products.Where( _ => _.ProductId == viewModel.ProductId ).First( ).ProductCategory.CategoryId;

        //    return View( viewModel );
        //}

        //// POST: Product/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult EditProduct(int? id, ProductCategoryViewModel viewModel)
        //{
        //    if ( ModelState.IsValid )
        //    {
        //        viewModel.ProductId = _dbContext.Products.FirstOrDefault( p => p.ProductId == id ).ProductId;
        //        viewModel.ProductCategory = _dbContext.Categories.ToList( );
        //        viewModel.CategoryId = _dbContext.Products.Where( c => c.ProductId == id ).FirstOrDefault( ).ProductCategory.CategoryId;
        //        Product product = _dbContext.Products.FirstOrDefault( p => p.ProductId == id );
        //        if ( product != null )
        //        {
        //            product.ProductId = viewModel.ProductId;
        //            product.ProductName = viewModel.ProductName;
        //            product.ProductCategory = _dbContext.Products.Where( _ => _.ProductId == viewModel.CategoryId ).FirstOrDefault( ).ProductCategory;
        //        }
        //        //_dbContext.Entry( product.ProductCategory ).State = EntityState.Modified;
        //        _dbContext.SaveChanges( );
        //        return RedirectToAction( "Home", HttpStatusCode.OK );
        //    }
        //    return new HttpStatusCodeResult( HttpStatusCode.BadRequest );
        //}

        //// GET: Product/Delete/5
        //[HttpGet]
        //public ActionResult DeleteProduct(int? id)
        //{
        //    ProductCategoryViewModel viewModel = new ProductCategoryViewModel
        //    {
        //        ProductId = (int)id,
        //        ProductName = _dbContext.Products.FirstOrDefault( p => p.ProductId == id ).ProductName,
        //        ProductCategory = _dbContext.Categories.ToList( )
        //    };
        //    return View( "Home", viewModel );
        //}

        //// POST: Product/Delete/5
        //[HttpPost]
        //[ActionName( "DeleteProduct" )]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteProductConfirmed(ProductCategoryViewModel viewModel)
        //{
        //    if ( ModelState.IsValid )
        //    {
        //        Product product = _dbContext.Products.Where( p => p.ProductId == viewModel.ProductId ).FirstOrDefault( );
        //        product.ProductCategory.CategoryId = _dbContext.Categories.FirstOrDefault( c => c.CategoryId == viewModel.CategoryId ).CategoryId;

        //        _dbContext.Products.Remove( product );
        //        _dbContext.SaveChanges( );
        //    }
        //    return RedirectToAction( "Index" );
        //}
    }
}
