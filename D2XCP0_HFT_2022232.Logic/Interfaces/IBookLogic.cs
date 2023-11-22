using D2XCP0_HFT_2022232.Models;
using System.Collections.Generic;
using System.Linq;

namespace D2XCP0_HFT_2022232.Logic
{
    public interface IBookLogic
    {
        IEnumerable<BookInfo> BestRatedBookInfo();
        void Create(Book item);
        void Delete(int id);
        IEnumerable<BookInfo> LongestTitleBookInfo();
        IEnumerable<BookInfo> MostExpensiveBookInfo();
        IEnumerable<BookInfo> MostPagesInABookInfo();
        Book Read(int id);
        IQueryable<Book> ReadAll();
        void Update(Book item);
        IEnumerable<BookInfo> WorstRatedBookInfo();
    }
}