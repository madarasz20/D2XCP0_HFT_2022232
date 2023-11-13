using D2XCP0_HFT_2022232.Models;
using D2XCP0_HFT_2022232.Repository;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D2XCP0_HFT_2022232.Logic
{
    public partial class BookLogic : IBookLogic
    {
        IRepository<Book> repo;

        public BookLogic(IRepository<Book> repo)
        {
            this.repo = repo;
        }

        

        public void Create(Book book)
        {
            if (book.Title.Length > 0)
            {
                repo.Create(book);
            }
            else
            {
                throw new ArgumentException("Invalid book name");
            }
        }
        public Book Read(int id)
        {
            return repo.Read(id);
        }
        public void Update(Book item)
        {
            repo.Update(item);
        }
        public IQueryable<Book> ReadAll()
        {
            return repo.ReadAll();
        }

        public void Delete(int id)
        {
            repo.Delete(id);
        }

        //Non-CRUDS
        public IEnumerable<BookInfo> BestRatedBookInfo()
        {
            BookInfo res = repo
                .ReadAll()
                .Select(x => new BookInfo
                {
                    Title = x.Title,
                    AuthorName = x.Author.AuthorName,
                    Genre = x.Genre.GenreName,
                    Rating = x.Rating,
                    Price = x.Price

                })
                .OrderByDescending(g => g.Rating)
                .FirstOrDefault();

            IEnumerable<BookInfo> bf = new List<BookInfo>()
            {
                res
            };
            return bf;
        }

        public IEnumerable<BookInfo> LongestTitleBookInfo()
        {
            BookInfo bf = repo
                .ReadAll()
                .Select(x => new BookInfo
                {
                    Title = x.Title,
                    AuthorName = x.Author.AuthorName,
                    Genre = x.Genre.GenreName,
                    Rating = x.Rating,
                    Price = x.Price

                })
                .OrderByDescending(x => x.Title.Length)
                .FirstOrDefault();

            IEnumerable<BookInfo> rtw = new List<BookInfo>()
            {
                bf
            };
            return rtw;
        }     

        public IEnumerable<BookInfo> MostExpensiveBookInfo()
        {
            BookInfo bf = repo
                .ReadAll()
                .Select(x => new BookInfo
                {
                    Title = x.Title,
                    AuthorName = x.Author.AuthorName,
                    Genre = x.Genre.GenreName,
                    Rating = x.Rating,
                    Price = x.Price

                })
                .OrderByDescending(x => x.Price)
                .FirstOrDefault();

            IEnumerable<BookInfo> rtw = new List<BookInfo>()
            {
                bf
            };
            return rtw;
        }

        public IEnumerable<BookInfo> MostPagesInABookInfo()
        {
            BookInfo bf = repo
                .ReadAll()
                .Select(x => new BookInfo
                {
                    Title = x.Title,
                    AuthorName = x.Author.AuthorName,
                    Genre = x.Genre.GenreName,
                    Rating = x.Rating,
                    Price = x.Price

                })
                .OrderByDescending(x => x.Pages)
                .FirstOrDefault();

            IEnumerable<BookInfo> rtw = new List<BookInfo>()
            {
                bf
            };
            return rtw;
        }
        public IEnumerable<BookInfo> WorstRatedBookInfo()
        {
            BookInfo res = repo
               .ReadAll()
               .Select(x => new BookInfo
               {
                   Title = x.Title,
                   AuthorName = x.Author.AuthorName,
                   Genre = x.Genre.GenreName,
                   Rating = x.Rating,
                   Price = x.Price

               })
               .OrderBy(g => g.Rating)
               .FirstOrDefault();

            IEnumerable<BookInfo> bf = new List<BookInfo>()
            {
                res
            };
            return bf;
        }
    }
}
