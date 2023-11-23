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
    public class FakeGenreRepo : IRepository<Genre>
    {
        

        public void Create(Genre item)
        {
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Genre Read(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Genre> ReadAll()
        {
            return new List<Genre>()
            {
                new Genre("1#Fiction"),
                new Genre("2#Non-Fiction"),
                new Genre("3#Mistery"),
            }.AsQueryable();
        }

        public void Update(Genre item)
        {
            throw new NotImplementedException();
        }
    }

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
        public void CreateTest()
        {
            //var movie = new Movie() { Title = "Vukk" };

            ////ACT
            //logic.Create(movie);

            ////ASSERT
            //mockMovieRepo.Verify(r => r.Create(movie), Times.Once);

            var genre = new Genre() { GenreName = "test" , GenreID = 77};
            logic.Create(genre);
            //Assert.That(logic.Read(77).GenreName, Is.EqualTo("test"));
            mockGenreRepo.Verify(r => r.Create(genre), Times.Once);

        }
    }
}
