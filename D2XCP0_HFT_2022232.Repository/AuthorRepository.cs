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
            return db.Authors.First(a => a.AuthorID == id);
        }

        public override void Update(Author item)
        {
            Author updatable = Read(item.AuthorID);

            var old = Read(item.AuthorID);
            foreach (var prop in old.GetType().GetProperties())
            {
                prop.SetValue(old, prop.GetValue(item));
            }
            db.SaveChanges();


        }
    }
}
