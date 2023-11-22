using System;
using System.Collections.Generic;
using System.Linq;
using D2XCP0_HFT_2022232.Models;
using D2XCP0_HFT_2022232.Repository;

namespace D2XCP0_HFT_2022232.Logic
{
    public class BookLogic : IBookLogic
    {
        IRepository<Book> repo;

        public BookLogic(IRepository<Book> repo)
        {
            this.repo = repo;
        }

        public void Create(Book item)
        {
            if (item.Title.Length <= 5)
            {
                throw new ArgumentException("Title too short..");
            }
            this.repo.Create(item);
        }

        public void Delete(int id)
        {
            this.repo.Delete(id);
        }

        public Book Read(int id)
        {
            var book = this.repo.Read(id);
            if (book == null) { throw new ArgumentException("Book not exists"); }
            return this.repo.Read(id);
        }

        public IQueryable<Book> ReadAll()
        {
            return this.repo.ReadAll();
        }

        public void Update(Book item)
        {
            this.repo.Update(item);
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
    public class BookInfo
    {
        public string Title { get; set; }
        public string AuthorName { get; set; }
        public string Genre { get; set; }
        public string Rating { get; set; }
        public int Price { get; set; }
        public int Pages { get; set; }

        //public override bool Equals(object obj)
        //{
        //    BookInfo b = obj as BookInfo;
        //    if (b == null)
        //    {
        //        return false;
        //    }
        //    else
        //    {
        //        return this.Title == b.Title
        //            && this.AuthorName == b.AuthorName
        //            && this.Genre == b.Genre
        //            && this.Rating == b.Rating
        //            && this.Price == b.Price
        //            && this.Pages == b.Pages;
        //    }
        //}

        //public override int GetHashCode()
        //{
        //    return HashCode.Combine(this.Title, this.AuthorName, this.Genre);
        //}
    }
}
