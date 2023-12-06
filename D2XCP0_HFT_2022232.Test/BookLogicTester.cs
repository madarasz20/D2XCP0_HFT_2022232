using D2XCP0_HFT_2022232.Logic;
using D2XCP0_HFT_2022232.Models;
using D2XCP0_HFT_2022232.Repository;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D2XCP0_HFT_2022232.Test
{



    [TestFixture]
    public class BookLogicTester
    {

        BookLogic logic;
        Mock<IRepository<Book>> MockBookRepo;

        [SetUp]
        public void Init()
        {
            MockBookRepo = new Mock<IRepository<Book>>();
            MockBookRepo.Setup(x => x.ReadAll()).Returns(new List<Book>()
            {
                new Book("1#Harry Potter and the Sorcerer's Stone#1#9#3300#93#400"),
                new Book("2#Pride and Prejudice#2#1#4265#100#200"),
                new Book("3#The Adventures of Huckleberry Finn#3#8#2350#85#256"),
                new Book("4#Metamorphosis#9#6#1435#87#270"),
                new Book("13#The Running Grave#1#6#3200#85#190")
            }.AsQueryable());

            logic = new BookLogic(MockBookRepo.Object);
        }
        [Test]
        public void CreateBookTestCorrect()
        {
            var book = new Book()
            {
                BookID = 10,
                Title = "WAUWAU",
                AuthorID = 1,
                GenreID = 1,
                Price = 1000,
                Rating = 12,
                Pages = 400
            };
            logic.Create(book);
            MockBookRepo.Verify(t => t.Create(book), Times.Once());
        }
        [Test]
        public void CreateBookTestINCorrect()
        {
            var book = new Book()
            {
                BookID = 10,
                Title = "1",
                AuthorID = 1,
                GenreID = 1,
                Price = 1000,
                Rating = 12,
                Pages = 400
            };
            try
            {
                logic.Create(book);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
            

            MockBookRepo.Verify(t => t.Create(book), Times.Never());
        }

        [Test]
        public void BestRatedBookTest()
        {
            Book item = logic.BestRatedBookInfo();
            string aa = item.Title;

            Assert.That(aa, Is.EqualTo("Pride and Prejudice"));
        }
        [Test]
        public void LongestTitleTest()
        {
            var aa = logic.LongestTitleBookInfo();
            int id = aa.BookID;

            Assert.That(id, Is.EqualTo(1));
        }

        [Test]
        public void HighestRatingTest()
        {
            int a = logic.HighestRate();
            Assert.That(a, Is.EqualTo(100));
        }
        [Test]
        public void MostExpensive()
        {
            Book a = logic.MostExpensiveBookInfo();
            Assert.That(a.Title, Is.EqualTo("Pride and Prejudice"));
        }
        [Test]
        public void MostPages()
        {
            Book a = logic.MostPagesInABookInfo();
            Assert.That(a.Title, Is.EqualTo("Harry Potter and the Sorcerer's Stone"));
        }
        [Test]
        public void WorstRated()
        {
            Book a = logic.WorstRatedBookInfo();
            Assert.That(a.Title, Is.EqualTo("The Adventures of Huckleberry Finn"));

        }
        [Test]
        public void GenreNamesAndCount()
        {
            var result = logic.MostFreqGenre();
            var expected = new NameAndCount()
            {
                Id = 6,
                Count = 2
            };


            Assert.AreEqual(expected, result);
        }
        [Test]
        public void BooksInGenreTest()
        {
            var result = logic.BooksInGenre(1);
            var expected = new List<Book>()
            {
                new Book("2#Pride and Prejudice#2#1#4265#100#200")

            };
            Assert.AreEqual(expected, result);
        }
        [Test]
        public void BooksbyAuthorTest()
        {
            var result = logic.BooksbyAuthor(1);
            var expected = new List<Book>()
            {
                new Book("1#Harry Potter and the Sorcerer's Stone#1#9#3300#93#400"),
                new Book("13#The Running Grave#1#6#3200#85#190")
            };
            Assert.AreEqual(expected, result);
        }


    }
}
