using D2XCP0_HFT_2022232.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D2XCP0_HFT_2022232.Repository
{
    public class BookRepository : Repository<Book>, IRepository<Book>
    {
        public BookRepository(BookDBcontext ctx) : base(ctx)
        {
        }

        public override Book Read(int id)
        {
            return ctx.Books.FirstOrDefault(t => t.BookID == id);
        }

        public override void Update(Book item)
        {
        
            var oldBook = Read(item.BookID);
            oldBook.Title = item.Title;
            oldBook.AuthorID = item.AuthorID;
            oldBook.GenreID = item.GenreID;
            oldBook.Price = item.Price;
            oldBook.Rating = item.Rating;
            oldBook.Pages = item.Pages;
            this.ctx.SaveChanges();
        }
    }
}
