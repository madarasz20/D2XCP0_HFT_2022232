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
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder

                    .UseLazyLoadingProxies()
                    .UseInMemoryDatabase("BookStorageDb");
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
                new Genre(){GenreID=7, GenreName="Thriller"},
                new Genre(){GenreID=8, GenreName="Novell"},
                new Genre(){GenreID=9, GenreName="Classic"},
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
                    Price = 3300, Rating = 4.8, Pages = 400},
                new Book() {BookID=2, Title = "Pride and Prejudice", AuthorID = 2, GenreID = 1, Price = 4265, Rating = 5.0, Pages = 200},
                new Book() {BookID=3, Title = "The Adventures of Huckleberry Finn", AuthorID = 3, GenreID = 8,
                    Price = 2350, Rating = 4.2, Pages = 256},
                new Book() {BookID=4, Title = "Metamorphosis", AuthorID = 9, GenreID = 6, Price = 1435, Rating = 4.7, Pages = 270},
                new Book() {BookID=5, Title = "The Outsider", AuthorID = 4, GenreID = 7, Price = 3400, Rating = 4.3, Pages = 143},
                new Book() {BookID=6, Title = "The Shining", AuthorID = 4, GenreID = 7, Price = 4300, Rating = 4.5, Pages = 177},
                new Book() {BookID=7, Title = "The Old Man and the Sea", AuthorID = 8, GenreID = 9, Price = 3765, Rating = 4.2, Pages = 300},
                new Book() {BookID=8, Title = "Beloved", AuthorID = 6, GenreID = 4, Price = 4441, Rating = 4.1, Pages = 123},
                new Book() {BookID=9, Title = "Oliver Twist", AuthorID = 7, GenreID = 9, Price = 3800, Rating = 4.6, Pages = 100},
                new Book() {BookID=10, Title = "1984", AuthorID = 5, GenreID = 5, Price = 3790, Rating = 4.0, Pages = 241},
                new Book() {BookID=11, Title = "The Adventures of Tom Sawyer", AuthorID = 3, GenreID = 9, Price = 1045, Rating = 4.0, Pages = 187},
                new Book() {BookID=12, Title = "Letters to Milena", AuthorID = 9, GenreID = 4, Price = 1750, Rating = 4.8, Pages = 234}
            });
        }
    }
}
