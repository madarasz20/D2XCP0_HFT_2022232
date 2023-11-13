using D2XCP0_HFT_2022232.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D2XCP0_HFT_2022232.Logic
{
    public interface IGenreLogic
    {
        void Create(Genre item);
        void Delete(int id);
        Genre Read(int id);
        IEnumerable<Genre> ReadAll();
        void Update(Genre item);
    }
}
