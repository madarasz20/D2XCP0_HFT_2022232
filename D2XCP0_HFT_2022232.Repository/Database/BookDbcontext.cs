using D2XCP0_HFT_2022232.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace D2XCP0_HFT_2022232.Repository
{
    public class BookDbcontext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public BookDbcontext()
        {
            this.Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (!builder.IsConfigured)
            {
                
                builder
                 .UseLazyLoadingProxies()
                 .UseInMemoryDatabase("book");
            }

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //connection between tables

            modelBuilder.Entity<Book>(book => book
            .HasOne(book => book.Author)
            .WithMany(a => a.Books)
            .HasForeignKey(book => book.AuthorID)
            .OnDelete(DeleteBehavior.Cascade));

            modelBuilder.Entity<Book>(book => book
            .HasOne(book => book.Genre)
            .WithMany(gen => gen.Books)
            .HasForeignKey(book => book.GenreID)
            .OnDelete(DeleteBehavior.Cascade));

            //seed data

            modelBuilder.Entity<Genre>().HasData(new Genre[]
            {
                new Genre("1#Fiction"),
                new Genre("2#Non-Fiction"),
                new Genre("3#Mistery"),
                new Genre("4#Romance"),
                new Genre("5#Science Fiction"),
                new Genre("6#Fantasy"),
                new Genre("7#Thriller"),
                new Genre("8#Novell"),
                new Genre("9#Classic"),
            });

            modelBuilder.Entity<Author>().HasData(new Author[]
            {
                new Author("1#J.K. Rowling#07/31/1965"),
                new Author("2#Jane Austen#12/16/1775"),
                new Author("3#Mark Twain#11/30/1835"),
                new Author("4#Stephen King#09/21/1947"),
                new Author("5#George Orwell#06/25/1903"),
                new Author("6#Toni Morrison#02/18/1931"),
                new Author("7#Charles Dickens#02/07/1812"),
                new Author("8#Ernest Hemingway#07/21/1899"),
                new Author("9#Franz Kafka#07/03/1883")
            });

            modelBuilder.Entity<Book>().HasData(new Book[]
            {
                new Book("1#Harry Potter and the Sorcerer's Stone#1#9#3300#93#400"),
                new Book("2#Pride and Prejudice#2#1#4265#100#200"),
                new Book("3#The Adventures of Huckleberry Finn#3#8#2350#85#256"),
                new Book("4#Metamorphosis#9#6#1435#87#270"),
                new Book("5#The Outsider#4#7#3400#81#143"),
                new Book("6#The Shining#4#7#4300#76#177"),
                new Book("7#The Old Man and the Sea#8#9#3765#78#300"),
                new Book("8#Beloved#6#4#4441#77#123"),
                new Book("9#Oliver Twist#7#9#3800#67#100"),
                new Book("10#1984#5#5#3790#80#241"),
                new Book("11#The Adventures of Tom Sawyer#3#9#1045#81#187"),
                new Book("12#Letters to Milena#9#4#1750#90#234"),
                new Book("13#The Running Grave#1#6#3200#85#190")
            });
        }
    }
}
