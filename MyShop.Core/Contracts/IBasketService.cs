using MyShop.Core.ViewModel;
using System.Collections.Generic;
using System.Web;

namespace MyShop.Core.Contracts
{
    public interface IBasketService
    {
        //void AddToBasket(HttpContextBase httpContext, string productId);
        //IEnumerable<BasketItemViewModel> GetBasketItems(HttpContextBase httpContext);
        //BasketSummeryViewModel GetBasketSummery(HttpContextBase httpContext);
        //void RemoveFromBasket(HttpContextBase httpContext, string itemId);

        void AddToBasket(HttpContextBase httpContext, string productId);
        void RemoveFromBasket(HttpContextBase httpContext, string itemId);
        List<BasketItemViewModel> GetBasketItems(HttpContextBase httpContext);
        BasketSummeryViewModel GetBasketSummary(HttpContextBase httpContext);
        void ClearBasket(HttpContextBase httpContext);
    }
}