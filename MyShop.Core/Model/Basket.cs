using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Core.Model
{
   public class Basket:BaseEntity
    {
        //Basket have list of basketItems
        public virtual List<BasketItem> BasketItems { get; set; }

        //List of basket items cannot be null 

        public Basket()
        {
             BasketItems  = new List<BasketItem>();
        }



    }
}
