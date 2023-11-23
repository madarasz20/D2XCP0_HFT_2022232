using D2XCP0_HFT_2022232.Logic;
using D2XCP0_HFT_2022232.Models;
using D2XCP0_HFT_2022232.Repository;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D2XCP0_HFT_2022232.Test
{
    public class FakeAuthorRepo : IRepository<Author>
    {
        public void Create(Author item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Author Read(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Author> ReadAll()
        {
            return new List<Author>()
            {
                new Author("1#J.K. Rowling#07/31/1965"),
                new Author("2#Jane Austen#12/16/1775"),
                new Author("3#Mark Twain#11/30/1835"),
            }.AsQueryable();
        }

        public void Update(Author item)
        {
            throw new NotImplementedException();
        }
    }


    [TestFixture]
    public class AuthorLogicTester
    {
        AuthorLogic logic;

        [SetUp]
        public void Init()
        {
            logic = new AuthorLogic(new FakeAuthorRepo());
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
