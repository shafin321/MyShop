using MyShop.Core.Contracts;
using MyShop.Core.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.DataAccess.Sql
{
    public class SqlRepository<T> : IRepository<T> where T : BaseEntity
    {
        private DataContext _context;
        private DbSet<T> dbset;
        public SqlRepository(DataContext context)
        {
            _context = context;
            this.dbset = _context.Set<T>();
        }
        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Delete(string id)
        {
            var t = dbset.Find(id);
            if (_context.Entry(t).State == EntityState.Detached) ;
            dbset.Attach(t);
            dbset.Remove(t);
        }

        public T Find(string id)
        {
            return dbset.Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            return dbset;
        }

        public void Insert(T t)
        {
            dbset.Add(t);
        }

        public void Update(T t)
        {
            dbset.Attach(t);
            _context.Entry(t).State = EntityState.Modified;
            
        }
    }
}
