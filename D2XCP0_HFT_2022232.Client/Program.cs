using D2XCP0_HFT_2022232.Models;
using D2XCP0_HFT_2022232.Repository;
using System;
using System.Linq;

namespace D2XCP0_HFT_2022232.Client
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IRepository<Author> repo = new AuthorRepository(new BookDbcontext());

            var items = repo.ReadAll().ToArray();

            ;
            
            
        }
    }
}
