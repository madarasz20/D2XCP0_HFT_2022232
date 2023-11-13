using D2XCP0_HFT_2022232.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D2XCP0_HFT_2022232.Repository
{
    public class AuthorRepository : AbstractRepo<Author>
    {
        public AuthorRepository(BookStorageDb db) : base(db)
        {
        }

        public override Author Read(int id)
        {
            return db.Authors.FirstOrDefault(a => a.AuthorID == id);
        }

        public override void Update(Author item)
        {
            Author updatable = Read(item.AuthorID);

            typeof(Author)
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
