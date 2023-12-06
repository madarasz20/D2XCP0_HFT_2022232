using D2XCP0_HFT_2022232.Models;
using System.Collections.Generic;
using System.Linq;

namespace D2XCP0_HFT_2022232.Logic
{
    public interface IBookLogic
    {
        Book BestRatedBookInfo();
        void Create(Book item);
        void Delete(int id);
        Book LongestTitleBookInfo();
        Book MostExpensiveBookInfo();
        Book MostPagesInABookInfo();
        Book Read(int id);
        IQueryable<Book> ReadAll();
        void Update(Book item);
        Book WorstRatedBookInfo();
        int HighestRate();

        NameAndCount MostFreqGenre();
        public IEnumerable<Book> BooksInGenre(int genreid);
        public IEnumerable<Book> BooksbyAuthor(int authorid);
    }
}