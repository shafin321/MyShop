using MyShop.Core.Model;
using MyShop.Core.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Core.Contracts
{
  public  interface IOrderService
    {
        void CreateOrder(Order order, List<BasketItemViewModel> basketItems);

    }
}
