using D2XCP0_HFT_2022232.Models;
using D2XCP0_HFT_2022232.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
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
            if (item.AuthorName.Length > 0)
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
    }
}
