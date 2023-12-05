using D2XCP0_HFT_2022232.Models;
using System.Collections.Generic;
using System.Linq;

namespace D2XCP0_HFT_2022232.Logic
{
    public interface IGenreLogic
    {
        void Create(Genre item);
        void Delete(int id);
        int NumOfGenres();
        Genre Read(int id);
        IQueryable<Genre> ReadAll();
        void Update(Genre item);
    }
}