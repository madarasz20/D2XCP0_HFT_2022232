using System.Linq;
using D2XCP0_HFT_2022232.Models;

namespace D2XCP0_HFT_2022232.Repository
{
    public class GenreRepository : AbstractRepo<Genre>, IRepository<Genre>
    {
        public GenreRepository(BookStorageDb db) : base(db)
        {
        }

        public override Genre Read(int id)
        {

            return db.Genres.FirstOrDefault(b => b.GenreID == id);
        }

        public override void Update(Genre item)
        {

            Genre updatable = Read(item.GenreID);

            typeof(Genre)
                .GetProperties()
                .ToList()
                .ForEach(g =>
                {
                    if (g.GetAccessors().FirstOrDefault(v => v.IsVirtual) == null)
                        g.SetValue(updatable, g.GetValue(item));
                });

            db.SaveChanges();
        }
    }
}
