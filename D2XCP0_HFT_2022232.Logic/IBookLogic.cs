using D2XCP0_HFT_2022232.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D2XCP0_HFT_2022232.Logic
{
    public interface IBookLogic
    {
        void Create(Book game);
        Book Read(int id);
        void Update(Book item);
        void Delete(int id);
        IQueryable<Book> ReadAll();
        
        IEnumerable<BookInfo> LongestTitleBookInfo();
        IEnumerable<BookInfo> BestRatedBookInfo();
        IEnumerable<BookInfo> WorstRatedBookInfo();
        IEnumerable<BookInfo> MostExpensiveBookInfo();
        IEnumerable<BookInfo> MostPagesInABookInfo();
        
    }
}
