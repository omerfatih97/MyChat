using MyChat.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MyChat.Repositories
{
    public class GenericRepository<T> where T : class, new()
    {
        MyChatContext c = new MyChatContext();
        public List<T> TList()
        {
            return c.Set<T>().ToList();
        }
        public void TAdd(T p)
        {
            c.Set<T>().Add(p);
            c.SaveChanges();
        }
        public void TDelete(T p)
        {
            c.Set<T>().Remove(p);
            c.SaveChanges();
        }

        public void TUpdate(T p)
        {
            c.Set<T>().Update(p);
            c.SaveChanges();
        }
        public T TGet(Guid id)
        {
            return c.Set<T>().Find(id);
        }
        public T TGet(int id)
        {
            return c.Set<T>().Find(id);
        }

        public List<T> List(Expression<Func<T, bool>> filter)
        {
            return c.Set<T>().Where(filter).ToList();
        }




    }
}
