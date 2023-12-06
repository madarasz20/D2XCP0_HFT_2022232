using System;
using System.Collections.Generic;
using System.Linq;
using D2XCP0_HFT_2022232.Models;
using D2XCP0_HFT_2022232.Repository;
using Microsoft.EntityFrameworkCore;

namespace D2XCP0_HFT_2022232.Logic
{
    public class BookLogic : IBookLogic
    {
        IRepository<Book> repo;
        IRepository<Author> authorRepo;

        public BookLogic(IRepository<Book> repo, IRepository<Author> au)
        {
            this.repo = repo;
            this.authorRepo = au;
        }

        public void Create(Book item)
        {
            if (item.Title.Length <= 2)
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
        public Book BestRatedBookInfo()
        {
            Book a = this.repo
                .ReadAll()
                .OrderByDescending(t => t.Rating)
                .FirstOrDefault();

            return a;

        }
        public int HighestRate()
        {
            return this.repo.ReadAll().OrderByDescending(t => t.Rating).First().Rating;
        }
        public Book LongestTitleBookInfo()
        {
            Book bf = repo
                .ReadAll()
                .OrderByDescending(x => x.Title.Length)
                .FirstOrDefault();

            

            return bf;
        }
        public Book MostExpensiveBookInfo()
        {
            Book bf = repo
                .ReadAll()
                .OrderByDescending(x => x.Price)
                .FirstOrDefault();

            
            return bf;
        }
        public Book MostPagesInABookInfo()
        {
            Book bf = repo
                .ReadAll()
                .OrderByDescending(x => x.Pages)
                .FirstOrDefault();

            return bf;
        }
        public Book WorstRatedBookInfo()
        {
            Book res = repo
               .ReadAll()
               
               .OrderBy(g => g.Rating)
               .FirstOrDefault();

           
            return res;
        }
        public NameAndCount MostFreqGenre()
        {
            var a = this.repo.ReadAll()
                .GroupBy(t => t.GenreID)
                .Select(g => new NameAndCount()
                {
                    Id = g.Key,
                    Count = g.Count()
                })
                .OrderByDescending(t => t.Count)
                .FirstOrDefault();

            return a;

        }
        public IEnumerable<Book> BooksInGenre(int genreid)
        {
            var rtw = repo.ReadAll().Where(t => t.GenreID == genreid).ToList();
            return rtw;
        }
        public IEnumerable<Book> BooksbyAuthor(int authorid)
        {
            var rtw = repo.ReadAll().Where(t => t.AuthorID == authorid).ToList();
            return rtw;
        }
        public IEnumerable<Book> BooksWithAuthors()
        {
            var booksWithAuthors = this.repo.ReadAll().Include(b => b.Author).ToList();
           
            return booksWithAuthors;
        }
        
        public IEnumerable<Book> bga()
        {
            var booksWithAuthorsAndGenres = this.repo.ReadAll().Include(b => b.Author).Include(b => b.Genre).ToList();
            return booksWithAuthorsAndGenres;
        }
        public IEnumerable<Book> BooksandAuthorsFilteredByGenre(int desiredGenreId)
        {
            var booksWithAuthorsFilteredByGenre = this.repo.ReadAll()
                .Include(b => b.Author)
                .Where(b => b.GenreID == desiredGenreId).ToList();

            return booksWithAuthorsFilteredByGenre;
        }


    }
    public class BookInfo
    {
        public BookInfo()
        {
                
        }
        public int BookID { get; set; }
        public string Title { get; set; }
        public int AuthorID { get; set; }
        public int GenreID { get; set; }
        public int Rating { get; set; }
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
        //    return HashCode.Combine(this.Title, this.AuthorName, this.Genre, this.Rating, 
        //        this.Price, this.Pages);
        //}
    }
    public class NameAndCount
    {
        public NameAndCount()
        {
            
        }
        public int Id { get; set; }
        public int Count { get; set; }

        public override bool Equals(object obj)
        {
            NameAndCount b = obj as NameAndCount;
            if (b == null)
            {
                return false;
            }
            else
            {
                return this.Id == b.Id 
                    && this.Count == b.Count;
            }
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(this.Id, this.Count);
        }
    }
}
