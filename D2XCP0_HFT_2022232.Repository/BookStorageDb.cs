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
            // use inmemory database

            if (!optionsBuilder.IsConfigured)
            {
                string conn =
                    @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Book.mdf;Integrated Security=True;MultipleActiveResultSets=true";
                optionsBuilder.UseLazyLoadingProxies().UseSqlServer(conn);

                //optionsBuilder
                //    .UseInMemoryDatabase("BookStorageDb")
                //    .UseLazyLoadingProxies();
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //connection between tables

            modelBuilder.Entity<Book>(book => book
            .HasOne<Author>()
            .WithMany(a => a.Books)
            .HasForeignKey(book => book.AuthorID)
            .OnDelete(DeleteBehavior.Cascade));

            modelBuilder.Entity<Book>(book => book
            .HasOne<Genre>()
            .WithMany(gen => gen.Books)
            .HasForeignKey(book => book.GenreID)
            .OnDelete(DeleteBehavior.Cascade));

            //seed data

            modelBuilder.Entity<Genre>().HasData(new Genre[]
            {
                new Genre(){GenreID=1, GenreName="Fiction"},
                new Genre(){GenreID=2, GenreName="Non-Fiction"},
                new Genre(){GenreID=3, GenreName="Mistery"},
                new Genre(){GenreID=4, GenreName="Romance"},
                new Genre(){GenreID=5, GenreName="Science Fiction"},
                new Genre(){GenreID=6, GenreName="Fantasy"},
                new Genre(){GenreID=7, GenreName="Horror"},
                new Genre(){GenreID=8, GenreName="Thriller"},
                new Genre(){GenreID=9, GenreName="Adventure"},
            });

            modelBuilder.Entity<Author>().HasData(new Author[]
            {
                new Author(){AuthorID=1,AuthorName="J.K. Rowling", BirthDay=new DateTime(1965,07,31)},
                new Author(){AuthorID=2,AuthorName="Jane Austen", BirthDay=new DateTime(1775,12,16)},
                new Author(){AuthorID=3,AuthorName="Mark Twain", BirthDay=new DateTime(1835,11,30)},
                new Author(){AuthorID=4,AuthorName="Stephen King", BirthDay=new DateTime(1947,9,21)},
                new Author(){AuthorID=5,AuthorName="George Orwell", BirthDay=new DateTime(1903,06,25)},
                new Author(){AuthorID=6,AuthorName="Toni Morrison", BirthDay=new DateTime(1931,2,18)},
                new Author(){AuthorID=7,AuthorName="Charles Dickens", BirthDay=new DateTime(1812,2,7)},
                new Author(){AuthorID=8,AuthorName="Ernest Hemingway", BirthDay=new DateTime(1899,7,21)},
                new Author(){AuthorID=9,AuthorName="Franz Kafka", BirthDay=new DateTime(1883,7,3)}
            });

            modelBuilder.Entity<Book>().HasData(new Book[]
            {
                new Book() {BookID=1, Title = "Harry Potter and the Sorcerer's Stone", AuthorID = 1, GenreID = 9,
                    Price = 3300, Rating = 4.8},
                new Book() {BookID=2, Title = "", AuthorID = 1, GenreID = 1, Price = 1000, Rating = 2.5},
                new Book() {BookID=3, Title = "", AuthorID = 1, GenreID = 1, Price = 1000, Rating = 2.5},
                new Book() {BookID=4, Title = "", AuthorID = 1, GenreID = 1, Price = 1000, Rating = 2.5},
                new Book() {BookID=5, Title = "", AuthorID = 1, GenreID = 1, Price = 1000, Rating = 2.5},
                new Book() {BookID=6, Title = "", AuthorID = 1, GenreID = 1, Price = 1000, Rating = 2.5},
                new Book() {BookID=7, Title = "", AuthorID = 1, GenreID = 1, Price = 1000, Rating = 2.5},
                new Book() {BookID=8, Title = "", AuthorID = 1, GenreID = 1, Price = 1000, Rating = 2.5},
                new Book() {BookID=9, Title = "", AuthorID = 1, GenreID = 1, Price = 1000, Rating = 2.5},
                new Book() {BookID=10, Title = "", AuthorID = 1, GenreID = 1, Price = 1000, Rating = 2.5},
                new Book() {BookID=11, Title = "", AuthorID = 1, GenreID = 1, Price = 1000, Rating = 2.5},
                new Book() {BookID=12, Title = "", AuthorID = 1, GenreID = 1, Price = 1000, Rating = 2.5}
            });
        }
    }
}
