using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D2XCP0_HFT_2022232.Repository
{
    public abstract class AbstractRepo<T> : IRepository<T> where T : class
    {
        protected BookStorageDb db;

        public AbstractRepo(BookStorageDb db)
        {
            this.db = db;
        }

        public void Create(T item)
        {
            db.Set<T>().Add(item);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            db.Set<T>().Remove(Read(id));
            db.SaveChanges();
        }

        public IQueryable<T> ReadAll()
        {
            return db.Set<T>();
        }

        public abstract void Update(T item);
        public abstract T Read(int id);
    }
}
