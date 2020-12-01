using MyShop.Core.Contracts;
using MyShop.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyShop.WebUI.Controllers
{
    public class HomeController : Controller
    {
        IRepository<Product> _contextProduct;
        IRepository<ProductCategory> _contextCategory;

        public HomeController(IRepository<Product> context, IRepository<ProductCategory> contextCategory)
        {
            _contextProduct = context;
            _contextCategory = contextCategory;
        }
        public ActionResult Index()
        {
            IEnumerable<Product> products = _contextProduct.GetAll();
            return View(products);
        }

        public ActionResult Details(string id)
        {
            Product product = _contextProduct.Find(id);
           
            
                return View(product);
            

         
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}