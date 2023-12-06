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
    public class AuthorLogicTester
    {
        Mock<IRepository<Author>> authorMockRepo;

        AuthorLogic logic;

        [SetUp]
        public void Init()
        {
            authorMockRepo = new Mock<IRepository<Author>>();
            authorMockRepo.Setup(x => x.ReadAll()).Returns(new List<Author>()
            {
                new Author("1#J.K. Rowling#07/31/1965"),
                        new Author("2#Jane Austen#12/16/1775"),
                        new Author("3#Mark Twain#11/30/1835"),
            }.AsQueryable());
            logic = new AuthorLogic(authorMockRepo.Object);
        }



        [Test]
        public void NumOfActorsTest()
        {
            int value = logic.NumOfAuthors();

            Assert.That(value, Is.EqualTo(3));
        }

        [Test]
        public void YoungestTest()
        {
            var aa = logic.YoungestAuthor();
            int rtw = aa.Age;

            Assert.That(rtw, Is.EqualTo(58));
        }

        [Test]
        public void OldestTest()
        {
            var aa = logic.OldestAuthor();
            int wau = aa.Age;

            Assert.That(wau, Is.EqualTo(248));
        }
        
    }
}
