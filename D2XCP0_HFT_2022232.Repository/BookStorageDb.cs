using D2XCP0_HFT_2022232.Models;
using System;
using Microsoft.EntityFrameworkCore;

namespace D2XCP0_HFT_2022232.Repository
{
    public class BookStorageDb : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Genre> Genres { get; set; }

        public BookStorageDb()
        {
            this.Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}
