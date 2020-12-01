using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyShop.Core.Contracts;
using MyShop.Core.Model;
using MyShop.Core.ViewModel;
using MyShop.Data.InMemory;

namespace MyShop.WebUI.Controllers
{
    public class ProductManagerController : Controller
    {
        //    ProductRepository _context;
        //    ProductCategoryRepsoitory context;
        //InMemoryRepository<Product> _context;
        //InMemoryRepository<ProductCategory> context;

        IRepository<Product> _context;
        IRepository<ProductCategory> context;


        public ProductManagerController( IRepository<Product> contextProduct, IRepository<ProductCategory> contextProductCateogory)
        {
            //_context = new ProductRepository();
            //context = new ProductCategoryRepsoitory();

            //_context = new InMemoryRepository<Product>();
            //context = new InMemoryRepository<ProductCategory>();

            _context = contextProduct;
            context = contextProductCateogory;

            //_context = new ProductRepository();
        }
        // GET: ProductManager
        public ActionResult Index()
        {
            List<Product> products = _context.GetAll().ToList();
            return View(products);
        }

      public ActionResult Create()
        {

            Product product = new Product();
            ProductManagerViewModel viewModel = new ProductManagerViewModel
            {
                Product = product,
                ProductCategories = context.GetAll(),
            };


            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Create(Product product,HttpPostedFileBase file)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }
            else
            {
                if(file != null)
                {
                    product.Image = product.Id + Path.GetExtension(file.FileName);
                    file.SaveAs(Server.MapPath("//Content//images//") + product.Image);
                    
                }
                
                _context.Insert(product);
                _context.Commit();

                return RedirectToAction("Index");
            }

        }

        public ActionResult Edit(string id)
        {
            Product product = _context.Find(id);

            if (product == null)
            {
                return HttpNotFound();
            }

            else
            {
                ProductManagerViewModel viewModel = new ProductManagerViewModel
                {
                    Product = product,
                    ProductCategories = context.GetAll(),
                };
                return View(viewModel);
            }
        }

        [HttpPost]
        public ActionResult Edit(Product product, string id) {

            var productEdit = _context.Find(id);

            if (productEdit == null)
            {
                return HttpNotFound();
            }

            else
            {
                if (!ModelState.IsValid)
                {
                    return View(product);
                }
            }
            //updateing the product -eidting
            productEdit.Category = product.Category;
            productEdit.Description = product.Description;
            productEdit.Name = product.Name;
            productEdit.Image = product.Image;
            productEdit.Price = product.Price;

            _context.Commit();

            return RedirectToAction("Index");


        }

        public ActionResult Delete(string id)
        {
            var product = _context.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }

            else
            {
                return View(product);
            }
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirDelete(string id) {

            var deleteProduct = _context.Find(id);

            if (deleteProduct == null)
            {
                return HttpNotFound();
            }

            else
            {
                _context.Delete(id);
                _context.Commit();

                return RedirectToAction("Index");
            }
        
        }
    }
}