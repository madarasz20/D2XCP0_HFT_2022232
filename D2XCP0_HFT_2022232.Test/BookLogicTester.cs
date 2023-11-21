using D2XCP0_HFT_2022232.Logic;
using D2XCP0_HFT_2022232.Models;
using D2XCP0_HFT_2022232.Repository;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace D2XCP0_HFT_2022232.Test
{
    public class FakeBookRepository : IRepository<Book>
    {
        public void Create(Book item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Book Read(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Book> ReadAll()
        {
            return new List<Book>()
            {
                new Book() {BookID=9, Title = "Oliver Twist", AuthorID = 7, GenreID = 9, Price = 3800, Rating = 4.6, Pages = 100},
                new Book() {BookID=10, Title = "1984", AuthorID = 5, GenreID = 5, Price = 3790, Rating = 4.0, Pages = 241},
                new Book() {BookID=11, Title = "The Adventures of Tom Sawyer", AuthorID = 3, GenreID = 9, Price = 1045, Rating = 4.0, Pages = 187},
                new Book() {BookID=12, Title = "Letters to Milena", AuthorID = 9, GenreID = 4, Price = 1750, Rating = 4.8, Pages = 234}

            }.AsQueryable();

        }

        public void Update(Book item)
        {
            throw new NotImplementedException();
        }
    }
    [TestFixture]
    public class BookLogicTester
    {
        BookLogic logic;

        [SetUp]
        public void Init()
        {
            logic = new BookLogic(new FakeBookRepository());
        }
        [Test]
        public void LongestTitleBookInfoTest()
        {
            IEnumerable <BookInfo> longest = logic.LongestTitleBookInfo();
            Assert.That(longest.FirstOrDefault().Title, Is.EqualTo("The Adventures of Tom Sawyer"));
        }
    }
}
