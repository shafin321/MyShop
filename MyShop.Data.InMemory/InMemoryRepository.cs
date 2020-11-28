using MyShop.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Data.InMemory
{
    //Using Generics
  public  class InMemoryRepository<T> where T:BaseEntity
    {
        ObjectCache cache = MemoryCache.Default;
        List<T> items;
        string className;

        public InMemoryRepository()
        {
            className = typeof(T).Name;
            items = cache[className] as List<T>;
            if (items == null)
            {
                items = new List<T>();
            }
        }

        public void Commit()
        {
            cache[className] = items;
        }

        public void Insert(T t)
        {
            items.Add(t);
        }

        public void Update(T t)
        {
            T updateT = items.Find(i => i.Id == t.Id);

            if(updateT != null)
            {
                updateT = t;
            }

            else
            {
                throw new Exception("Not found");
            }
        }

        public T Find(string id)
        {
            T t = items.Find(c => c.Id == id);

            if (t != null)
            {
                return t;
            }

            else
            {
                throw new Exception("Not found");
            }
        }

        public IEnumerable<T> GetAll()
        {
            return items;
        }

        public void Delete(string id)
        {
            T toDelete = items.Find(d => d.Id == id);
            if(toDelete != null)
            {
                items.Remove(toDelete);
            }
            else
            {
                throw new Exception("Not found"); 
            }
        }
    }
}
