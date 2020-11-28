using MyShop.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Data.InMemory
{
  public  class ProductRepository
    {
        ObjectCache cache = MemoryCache.Default;

        List<Product> products = new List<Product>();

        public ProductRepository()
        {
            products = cache["products"] as List<Product>;
            if (products == null)
            {
                products = new List<Product>();
            }
        }

        public void Commit()
        {
            cache["products"] = products;
        }

        public void Insert(Product product)
        {
            products.Add(product);
        }

        public void Update(Product product)
        {
            Product updateProduct = products.Find(p => p.Id == product.Id);
           if(updateProduct != null)
            {
                updateProduct = product;
            }

            else
            {
                throw new Exception("Product not found");
            }
        }

        public Product Find(string id)
        {
            var product = products.Find(p => p.Id == id);

            if(product != null)
            {
                return product;
            }

            else
            {
                throw new Exception("Not found");
            }
        }

        public IEnumerable<Product> GetAll()
        {
            return products;
        }

        public void Delete(string id)
        {
            Product product = products.Find(p => p.Id == id);

            if(product != null)
            {
                products.Remove(product);
            }

            else
            {
                throw new Exception("Not found ");
            }
        }
    }
}
