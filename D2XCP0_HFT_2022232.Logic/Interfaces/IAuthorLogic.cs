using D2XCP0_HFT_2022232.Models;
using System.Linq;

namespace D2XCP0_HFT_2022232.Logic
{
    public interface IAuthorLogic
    {
        void Create(Author item);
        void Delete(int id);
        int NumOfAuthors();
        Author OldestAuthor();
        Author Read(int id);
        IQueryable<Author> ReadAll();
        void Update(Author item);
        Author YoungestAuthor();
    }
}