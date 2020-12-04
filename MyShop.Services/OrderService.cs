using MyShop.Core.Contracts;
using MyShop.Core.Model;
using MyShop.Core.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Services
{
  public  class OrderService: IOrderService
    {
        IRepository<Order> _orderContext;

        public OrderService(IRepository<Order> repository)
        {
            _orderContext = repository;
        }

        public void CreateOrder(Order order, List<BasketItemViewModel> basketItems)
        {
              //list of basket item-> basketItems
              foreach(var item in basketItems)
            {

                order.OrderItems.Add(new OrderItem { 
                ProductId=item.Id,
                ProductName=item.ProductName,
                Price=item.Price,
                Image=item.Image,
                Quanity=item.Quantity
                
                
                });
            }

            _orderContext.Insert(order);
            _orderContext.Commit();

            
        }
    }
}
