using D2XCP0_HFT_2022232.Logic;
using D2XCP0_HFT_2022232.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace D2XCP0_HFT_2022232.Endpoint.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class StatController : ControllerBase
    {
        IBookLogic booklogic;
        IAuthorLogic authorlogic;
        IGenreLogic genrelogic;

        public StatController(IBookLogic booklogic, IAuthorLogic authorlogic, IGenreLogic genrelogic)
        {
            this.booklogic = booklogic;
            this.authorlogic = authorlogic;
            this.genrelogic = genrelogic;
        }
        //Genre
        [HttpGet]
        public int NumOfGenres()
        {
            return this.genrelogic.NumOfGenres();
        }
        [HttpGet]
        public string MostFreqGenre()
        {
            NameAndCount nameandcount = this.booklogic.MostFreqGenre();
            List<Genre> genres = this.genrelogic.ReadAll().ToList();
            Genre rtw = new Genre();
            foreach (Genre genre in genres)
            {
                if (genre.GenreID == nameandcount.Id)
                {
                    rtw = genre;
                }
            }
            return rtw.GenreName + "#" + nameandcount.Count.ToString();
        }


        //Author
        [HttpGet]
        public Author YoungestAuthor()
        {
            return this.authorlogic.YoungestAuthor();
        }
        [HttpGet]
        public Author OldestAuthor()
        {
            return this.authorlogic.OldestAuthor();
        }
        [HttpGet]
        public int NumOfAuthors()
        {
            return this.authorlogic.NumOfAuthors();
        }


        //Book
        [HttpGet]
        public Book BestRatedBookinfo()
        {
            return this.booklogic.BestRatedBookInfo();
        }
        [HttpGet]
        public Book WorstRatedBookinfo()
        {
            return this.booklogic.WorstRatedBookInfo();
        }
        [HttpGet]
        public int HighestRated()
        {
            return this.booklogic.HighestRate();
        }
        [HttpGet]
        public Book LongestTitleBookinfo()
        {
            return this.booklogic.LongestTitleBookInfo();
        }
        [HttpGet]
        public Book MostExpensiveBookinfo()
        {
            return this.booklogic.WorstRatedBookInfo();
        }
        [HttpGet]
        public Book MostPagesInABookinfo()
        {
            return this.booklogic.MostPagesInABookInfo();
        }
        [HttpGet]
        public IEnumerable<Book> BooksInGenre(int genreid)
        {
            return this.booklogic.BooksInGenre(genreid);
        }
        [HttpGet]
        public IEnumerable<Book> BooksbyAuthor(int authorid)
        {
            return this.booklogic.BooksbyAuthor(authorid);
        }
        [HttpGet]
        public IEnumerable<Book> BooksWithAuthor()
        {
            return this.booklogic.BooksWithAuthors();
        }
        
        
    }
}
