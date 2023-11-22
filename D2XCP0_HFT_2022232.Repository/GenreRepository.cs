using D2XCP0_HFT_2022232.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D2XCP0_HFT_2022232.Repository
{
    public class GenreRepository : Repository<Genre>, IRepository<Genre>
    {
        public GenreRepository(BookDbcontext ctx) : base(ctx)
        {
        }

        public override Genre Read(int id)
        {
            return ctx.Genres.FirstOrDefault(t => t.GenreID == id);
        }

        public override void Update(Genre item)
        {
            var oldGenre = Read(item.GenreID);
            oldGenre.GenreName = item.GenreName;
            this.ctx.SaveChanges();
        }
    }
}
