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
    public class GenreLogicTester
    {
        GenreLogic logic;
        Mock<IRepository<Genre>> mockGenreRepo;

        [SetUp]
        public void Init()
        {
            mockGenreRepo = new Mock<IRepository<Genre>>();
            mockGenreRepo.Setup(m => m.ReadAll()).Returns(new List<Genre>()
            {
                new Genre("1#Fiction"),
                new Genre("2#Non-Fiction"),
                new Genre("3#Mistery"),
            }.AsQueryable());
            logic = new GenreLogic(mockGenreRepo.Object);
            //logic = new GenreLogic(new FakeGenreRepo());
        }

        [Test]
        public void NumOfGenresTest()
        {
            int a = logic.NumOfGenres();
            Assert.That(a, Is.EqualTo(3));
        }

        [Test]
        public void CreateTestCorrect()
        {
            var g = new Genre()
            {
                GenreID = 111,
                GenreName = "Test",
            };

            logic.Create(g);
            mockGenreRepo.Verify(x => x.Create(g), Times.Once());

        }
        [Test]
        public void CreateTestINCorrect()
        {
            var g = new Genre()
            {
                GenreID = 111,
                GenreName = "Te",
            };
            try
            {
                logic.Create(g);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
            mockGenreRepo.Verify(x => x.Create(g), Times.Never());

        }
    }
}
