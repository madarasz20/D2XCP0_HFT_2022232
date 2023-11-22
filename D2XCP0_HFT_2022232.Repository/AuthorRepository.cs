using D2XCP0_HFT_2022232.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D2XCP0_HFT_2022232.Repository
{
    public class AuthorRepository : Repository<Author>, IRepository<Author>
    {
        public AuthorRepository(BookDbcontext ctx) : base(ctx)
        {
        }

        public override Author Read(int id)
        {
            return ctx.Authors.FirstOrDefault(t => t.AuthorID == id);
        }

        public override void Update(Author item)
        {
            var oldAuthor = Read(item.AuthorID);
            oldAuthor.AuthorName = item.AuthorName;
            oldAuthor.BirthDay = item.BirthDay;
            this.ctx.SaveChanges();
        }
    }
}
