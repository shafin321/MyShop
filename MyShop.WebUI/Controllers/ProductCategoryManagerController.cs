using MyShop.Core.Model;
using MyShop.Data.InMemory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyShop.WebUI.Controllers
{
    public class ProductCategoryManagerController : Controller
    {

        private ProductCategoryRepsoitory context;

        public ProductCategoryManagerController()
        {
            context = new ProductCategoryRepsoitory();
        }
        // GET: ProductCategoryManager
        public ActionResult Index()
        {
            IEnumerable<ProductCategory> categories = context.GetAll();
            return View(categories);
        }
        public ActionResult Create()
        {
            ProductCategory categoryProduct = new ProductCategory();
            return View(categoryProduct);
        }

        [HttpPost]
        public ActionResult Create(ProductCategory productCategory)
        {
            if (!ModelState.IsValid)
            {
                return View(productCategory);
            }
            else
            {
                context.Insert(productCategory);
                context.Commit();

                return RedirectToAction("Index");
            }

        }

            public ActionResult Edit(string id)
        {
            var productEdit = context.Find(id);

            if (productEdit == null)
            {
                return HttpNotFound();
            }

            else
            {
                return View(productEdit);
            }
        }

        public ActionResult Edit(ProductCategory category,string id)
        {
            var editCateogry = context.Find(id);

            if (editCateogry == null)
            {
                return HttpNotFound();
            }

            else
            {
                if (!ModelState.IsValid)
                {
                    return View(category);
                }

                editCateogry.Category = category.Category;

                context.Commit();
                return RedirectToAction("Index");
            }
                        
        }

        public ActionResult Delete(string Id)
        {
            ProductCategory productCategoryToDelete = context.Find(Id);

            if (productCategoryToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(productCategoryToDelete);
            }
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(string Id)
        {
            ProductCategory productCategoryToDelete = context.Find(Id);

            if (productCategoryToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                context.Delete(Id);
                context.Commit();
                return RedirectToAction("Index");
            }
        }
    }
}