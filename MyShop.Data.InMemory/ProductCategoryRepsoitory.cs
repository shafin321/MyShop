using MyShop.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;


namespace MyShop.Data.InMemory
{
  public class ProductCategoryRepsoitory
    {
        ObjectCache cache = MemoryCache.Default;
        List<ProductCategory> categories;

        public ProductCategoryRepsoitory()
        {
            categories=cache["categories"] as List<ProductCategory>;
            if (categories == null)
            {
                categories = new List<ProductCategory>();
            }
        }

        public void Commit()
        {
            cache["categories"] = categories;
        }
        
        public void Insert(ProductCategory productCategory)
        {
            categories.Add(productCategory);
        }

        public void Update(ProductCategory productCategory)
        {
            ProductCategory productCategoryUpdate = categories.Find(c => c.Id == productCategory.Id);
           
            if(productCategoryUpdate != null)
            {
                productCategoryUpdate = productCategory;
            }

            else
            {
                throw new Exception("Not Found");
            }
        }

        public ProductCategory Find(string id)
        {
            var category = categories.Find(c => c.Id == id);

            if (category !=null)
            {
                return category;
            }

            else
            {
                throw new Exception("Product Not Found");
            }
        }

        public IEnumerable<ProductCategory> GetAll()
        {
            return categories;
        }

        public void Delete(string id)
        {
            var categorydelete = categories.Find(c => c.Id == id);

            if (categorydelete != null)
            {
                categories.Remove(categorydelete);
            }
            else
            {
                throw new Exception("Not found");
            }
        }
    }
}
