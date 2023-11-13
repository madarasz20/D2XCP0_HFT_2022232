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
                repo.Create(item);
            else
                throw new ArgumentException("Invalid author name");
        }

        public void Delete(int id)
        {
            repo.Delete(id);
        }

        public Author Read(int id)
        {
            return repo.Read(id);
        }

        public IEnumerable<Author> ReadAll()
        {
            return repo.ReadAll();
        }

        public void Update(Author item)
        {
            repo.Update(item);
        }
    }
}
