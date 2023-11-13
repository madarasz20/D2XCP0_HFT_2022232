using D2XCP0_HFT_2022232.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace D2XCP0_HFT_2022232.Logic
{
    public interface IAuthorLogic
    {
        void Create(Author item);
        void Delete(int id);
        Author Read(int id);
        IEnumerable<Author> ReadAll();
        void Update(Author item);
    }
}
