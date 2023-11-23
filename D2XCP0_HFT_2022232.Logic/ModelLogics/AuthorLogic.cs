using D2XCP0_HFT_2022232.Models;
using D2XCP0_HFT_2022232.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D2XCP0_HFT_2022232.Logic
{
    public class AuthorLogic : IAuthorLogic
    {
        IRepository<Author> repo;

        public AuthorLogic(IRepository<Author> repo)
        {
            this.repo = repo;
        }

        public void Create(Author item)
        {
            if (item.AuthorName.Length > 2)
            {
                this.repo.Create(item);
            }
            else
            {
                throw new ArgumentException("Invalid author name");
            }
            Console.ReadLine();
        }

        public void Delete(int id)
        {
            this.repo.Delete(id);
        }

        public Author Read(int id)
        {
            return this.repo.Read(id);
        }

        public IQueryable<Author> ReadAll()
        {
            return this.repo.ReadAll();
        }

        public void Update(Author item)
        {
            this.repo.Update(item);
        }

        //Non-Cruds

        public AuthorInfo YoungestAuthor()
        {
            AuthorInfo res = repo
              .ReadAll()
              .Select(x => new AuthorInfo
              {
                  AuthorID = x.AuthorID,
                  AuthorName = x.AuthorName,
                  Birthday = x.BirthDay,

              })
              .OrderBy(g => g.Age)
              .FirstOrDefault();


            return res;
        }
        public AuthorInfo OldestAuthor()
        {
            AuthorInfo res = repo
              .ReadAll()
              .Select(x => new AuthorInfo
              {
                  AuthorID = x.AuthorID,
                  AuthorName = x.AuthorName,
                  Birthday = x.BirthDay,

              })
              .OrderByDescending(g => g.Age)
              .FirstOrDefault();


            return res;
        }
        public int NumOfAuthors()
        {
            int num = repo.ReadAll().Count();
            return num;
        }

    }
    public class AuthorInfo
    {
        public int AuthorID { get; set; }
        public string AuthorName { get; set; }
        public DateTime Birthday { get; set; }
        public int Age 
        { 
            get
            {
                DateTime today = DateTime.Today;
                int age = today.Year - this.Birthday.Year;
                return age;
            }
        }
    }
}
