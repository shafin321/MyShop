using MyShop.Core.Model;
using System.Collections.Generic;

namespace MyShop.Core.Contracts
{
    public interface IRepository<T> where T : BaseEntity
    {
        void Commit();
        void Delete(string id);
        T Find(string id);
        IEnumerable<T> GetAll();
        void Insert(T t);
        void Update(T t);
    }
}