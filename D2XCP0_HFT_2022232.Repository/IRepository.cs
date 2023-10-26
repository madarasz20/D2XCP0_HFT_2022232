using D2XCP0_HFT_2022232.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D2XCP0_HFT_2022232.Repository
{
    public interface IRepository<T> where T : class
    {
        void Create(Book book);
        Book Read(int id);
        IQueryable<Book> ReadAll();
        void Update(Book book);
        void Delete(int id);
    }
}
