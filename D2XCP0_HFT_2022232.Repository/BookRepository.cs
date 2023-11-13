using D2XCP0_HFT_2022232.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D2XCP0_HFT_2022232.Repository
{
    public class BookRepository : AbstractRepo<Book>
    {
        public BookRepository(BookStorageDb db) : base(db)
        {
        }

        public override Book Read(int id)
        {
            return db.Books.FirstOrDefault(b => b.BookID == id);
        }

        public override void Update(Book item)
        {
            
            Book updatable = Read(item.BookID);
            
            typeof(Book)
                .GetProperties()
                .ToList()
                .ForEach(g =>
                {
                    if (g.GetAccessors().FirstOrDefault(v => v.IsVirtual) == null)
                        g.SetValue(updatable, g.GetValue(item));
                });
            
            db.SaveChanges();
        }
    }
}
