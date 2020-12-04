using MyShop.Core.Contracts;
using MyShop.Core.Model;
using MyShop.DataAccess.Sql.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyShop.Core.Model;
using Customer = MyShop.Core.Model.Customer;

namespace MyShop.WebUI.Controllers
{
    public class BasketController : Controller
    {
        IBasketService _basketService;
        IOrderService _orderService;
        IRepository<Customer> _customerService;
        

        public BasketController(IBasketService basketService, IOrderService orderService,IRepository<Customer> customer)
        {
            _basketService = basketService;
            _orderService = orderService;
            _customerService = customer;

        }
        // GET: Basket
        public ActionResult Index()
        {
            var model = _basketService.GetBasketItems(this.HttpContext);
            return View(model);
        }

        public ActionResult AddToBasket(string id)
        {
            _basketService.AddToBasket(this.HttpContext, id);
            return RedirectToAction("Index");
        }

        public PartialViewResult BasketSummery()
        {
            var basketSummery = _basketService.GetBasketSummary(this.HttpContext);
            return PartialView(basketSummery);
        }

        [Authorize]
        public ActionResult Checkout()
        {
            //Search User from the Loged in Email and find the user name from that
            //c=>c.Email==User.Identity.Name
            Customer customer = _customerService.GetAll().FirstOrDefault(c => c.Email == User.Identity.Name);// found the logged in user 

            if(customer != null)
            { //create new order for customer
                Order order = new Order
                {FirstName=customer.FirstName,
                LastName=customer.LastName,
                Email=customer.Email,
                
                };
                return View(order);
                
            }
            else { return RedirectToAction("Error");
            }
           
        }

        [HttpPost]
        [Authorize]
        public ActionResult Checkout(Order order)
        {

            var basketItems = _basketService.GetBasketItems(this.HttpContext);
            order.OrderStatus = "Order Created";
            order.Email = User.Identity.Name;

            //process payment

            order.OrderStatus = "Payment Processed";
            _orderService.CreateOrder(order, basketItems);
            _basketService.ClearBasket(this.HttpContext);

            return RedirectToAction("Thankyou", new { OrderId = order.Id });
        }

        public ActionResult ThankYou(string OrderId)
        {
            ViewBag.OrderId = OrderId;
            return View();
        }
    }
}