using ConsoleTools;
using D2XCP0_HFT_2022232.Logic;
using D2XCP0_HFT_2022232.Models;
using D2XCP0_HFT_2022232.Repository;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Net;

namespace D2XCP0_HFT_2022232.Client
{
    internal class Program
    {
        static AuthorLogic authorlogic;
        static BookLogic booklogic;
        static GenreLogic genrelogic;

        static void Main(string[] args)
        {
            
            var ctx = new BookDbcontext();

            var bookrepo = new BookRepository(ctx);
            var authorrepo = new AuthorRepository(ctx);
            var genrerepo = new GenreRepository(ctx);

            booklogic = new BookLogic(bookrepo);
            authorlogic = new AuthorLogic(authorrepo);
            genrelogic = new GenreLogic(genrerepo);

            var bookSubSubMenu = new ConsoleMenu(args, level: 2)
               .Add("Show every Book", () => List("Book"))
               .Add("Show Book by ID", () => ListByID("Book"))
               .Add("Best rated Book", () => BestRatedBookInfo())
               .Add("Worst rated Book", () => WorstRatedBookInfo())
               .Add("Longest title Book", ()=> LongestTitleBookInfo())
               .Add("Most expensive Book", ()=> MostExpensiveBookInfo())
               .Add("Most pages Book", ()=> MostPagesInABookInfo())
               .Add("Exit", ConsoleMenu.Close);

            var autSubSubMenu = new ConsoleMenu(args, level: 2)
               .Add("Show every Author", () => List("Author"))
               .Add("Show Author by ID", () => ListByID("Author"))
               .Add("Youngest Author", () => YoungestAuthor())
               .Add("Oldest Author", () => OldestAuthor())
               .Add("Number Of Authors", () => NumOfAuthors())
               .Add("Exit", ConsoleMenu.Close);

            var genSubSubMenu = new ConsoleMenu(args, level: 2)
               .Add("Show every Genre", () => List("Genre"))
               .Add("Show Genre by ID", () => ListByID("Genre"))
               .Add("Number Of Genres", () => NumOfGenres())
               .Add("Exit", ConsoleMenu.Close);



            var bookSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => bookSubSubMenu.Show())
                .Add("Create", () => Create("Book"))
                .Add("Update", () => Update("Book"))
                .Add("Delete", () => Delete("Book"))
                .Add("Exit", ConsoleMenu.Close);

            var authorSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => autSubSubMenu.Show())
                .Add("Create", () => Create("Author"))
                .Add("Update", () => Update("Author"))
                .Add("Delete", () => Delete("Author"))
                .Add("Exit", ConsoleMenu.Close);

            var genreSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => genSubSubMenu.Show())
                .Add("Create", () => Create("Genre"))
                .Add("Update", () => Update("Genre"))
                .Add("Delete", () => Delete("Genre"))
                .Add("Exit", ConsoleMenu.Close);



            var menu = new ConsoleMenu(args, level: 0)
                .Add("Books", () => bookSubMenu.Show())
                .Add("Authors", () => authorSubMenu.Show())
                .Add("Genre", () => genreSubMenu.Show())
                .Add("Exit", ConsoleMenu.Close);

            menu.Show();


        }
        static void Create(string entity)
        {
            if (entity == "Author")
            {
                Console.WriteLine("Enter Author name:");
                string name = Console.ReadLine();
                Console.WriteLine();
                Console.WriteLine("Enter Author's ID:");
                string id = Console.ReadLine();
                Console.WriteLine();
                Console.WriteLine("Enter Author's birthday [MM/DD/YYYY]:");
                string date = Console.ReadLine();
                Console.WriteLine();
                string line = $"{id}#{name}#{date}";
                authorlogic.Create(new Author(line));
            }
            else if (entity == "Book")
            {
                Console.WriteLine("Enter Book ID [int]: ");
                string id = Console.ReadLine();
                Console.WriteLine("Enter Book Title: ");
                string title = Console.ReadLine();
                Console.WriteLine("Enter Author ID [int]: ");
                string au = Console.ReadLine();
                //if null create author
                Console.WriteLine("Enter Genre ID [int]: ");
                string genre = Console.ReadLine();
                //if null create genre
                Console.WriteLine("Enter Price [int]: ");
                string price = Console.ReadLine();
                Console.WriteLine("Rating [ex.: 4,5]: ");
                string rating = Console.ReadLine();
                Console.WriteLine("Number of pages: ");
                string pages = Console.ReadLine();

                string line  = $"{id}#{title}#{au}#{genre}#{price}#{rating}#{pages}";
                booklogic.Create(new Book(line));
            }
            else if (entity == "Genre")
            {
                Console.WriteLine("Enter genre ID: ");
                string id = Console.ReadLine() ;
                Console.WriteLine("Enter genre name: ");
                string title = Console.ReadLine() ;

                string line = $"{id}#{title}";
                genrelogic.Create(new Genre(line));
            }
            Console.WriteLine();
        }
        static void List(string entity)
        {
            if (entity == "Author")
            {
                //List<Author> authors = rest.Get<Author>("author");
                var authors = authorlogic.ReadAll();
                foreach (var item in authors)
                {
                    Console.WriteLine(item.AuthorID + "     " + item.AuthorName);
                }
            }
            else if (entity == "Book")
            {
                //List<Book> books = rest.Get<Book>("book");
                var books = booklogic.ReadAll();
                foreach (var item in books)
                {
                    Console.WriteLine(item.BookID + "     " + item.Title);
                }
            }
            else if (entity == "Genre")
            {
                //List<Genre> genres = rest.Get<Genre>("genre");
                var genres = genrelogic.ReadAll();
                foreach (var item in genres)
                {
                    Console.WriteLine(item.GenreID + "     " + item.GenreName);
                }
            }
            Console.ReadLine();
        }
        static void ListByID(string entity)
        {
            Console.WriteLine("Enter id: ");
            int id = int.Parse(Console.ReadLine());
            if (entity == "Author")
            {
                //List<Author> authors = rest.Get<Author>("author");
                var item = authorlogic.Read(id);
                Console.WriteLine(item.AuthorID + "     " + item.AuthorName);
                Console.WriteLine();
            }
            else if (entity == "Book")
            {
                //List<Book> books = rest.Get<Book>("book");
                var item = booklogic.Read(id);
                Console.WriteLine(item.BookID + "     " + item.Title);
                Console.WriteLine();

            }
            else if (entity == "Genre")
            {
                //List<Genre> genres = rest.Get<Genre>("genre");
                var item = genrelogic.Read(id);
                Console.WriteLine(item.GenreID + "     " + item.GenreName);
                Console.WriteLine();
            }
            Console.ReadLine();

        }
        static void Update(string entity)
        {
            if (entity == "Author")
            {
                Console.WriteLine("Enter updatable author's ID: ");
                int id = int.Parse(Console.ReadLine());
                var old = authorlogic.Read(id);

                Console.WriteLine($"Enter Author name [old name: {old.AuthorName}]:");
                string name = Console.ReadLine();
                Console.WriteLine($"Enter Author's birthday [MM/DD/YYYY] [old Bday: {old.BirthDay}]:");
                string date = Console.ReadLine();
                

                Console.WriteLine();
                string line = $"{id}#{name}#{date}";
                authorlogic.Update(new Author(line));
            }
            else if (entity == "Book")
            {
                Console.WriteLine("Enter updatable Book's ID : ");
                int id = int.Parse(Console.ReadLine());
                var old = booklogic.Read(id);


                Console.WriteLine($"Enter Book Title [old title: {old.Title}]: ");
                string title = Console.ReadLine();
                Console.WriteLine($"Enter Author ID [old Author ID: {old.AuthorID}]: ");
                string au = Console.ReadLine();
                //if null create author
                Console.WriteLine($"Enter Genre ID [old Genre ID: {old.GenreID}]: ");
                string genre = Console.ReadLine();
                //if null create genre
                Console.WriteLine($"Enter Price [old price: {old.Price}]: ");
                string price = Console.ReadLine();
                Console.WriteLine($"Rating [old rating: {old.Rating}]: ");
                string rating = Console.ReadLine();
                Console.WriteLine($"Number of pages [old pages: {old.Pages}]: ");
                string pages = Console.ReadLine();

                string line = $"{id}#{title}#{au}#{genre}#{price}#{rating}#{pages}";
                booklogic.Update(new Book(line));
            }
            else if (entity == "Genre")
            {
                Console.WriteLine("Enter updatable gende ID: ");
                int id = int.Parse(Console.ReadLine());
                var old = genrelogic.Read(id);

                Console.WriteLine("Enter genre name: ");
                string title = Console.ReadLine();

                string line = $"{id}#{title}";
                genrelogic.Update(new Genre(line));
            }
        }
        static void Delete(string entity)
        {
            if (entity == "Book")
            {
                Console.WriteLine("Enter deletable Book's ID: ");
                int id = int.Parse(Console.ReadLine()) ;
                booklogic.Delete(id);
            }
            else if (entity == "Author")
            {
                Console.WriteLine("Enter deletable Author's ID: ");
                int id = int.Parse(Console.ReadLine());
                authorlogic.Delete(id);
            }
            else if (entity == "Genre")
            {
                Console.WriteLine("Enter deletable Genre's ID: ");
                int id = int.Parse(Console.ReadLine());
                genrelogic.Delete(id);
            }
        }

        //NON-CRUDS

        //Author
        static void YoungestAuthor()
        {
            var youngest = authorlogic.YoungestAuthor();
            Console.WriteLine("Author's ID: " + youngest.AuthorID);
            Console.WriteLine("Author's Name: " + youngest.AuthorName);
            Console.WriteLine("Author's Age Today: " + youngest.Age);
            Console.ReadLine();
            
        }
        static void OldestAuthor()
        {
            var oldest = authorlogic.OldestAuthor();
            Console.WriteLine("Author's ID: " + oldest.AuthorID);
            Console.WriteLine("Author's Name: " + oldest.AuthorName);
            Console.WriteLine("Author's Age Today: " + oldest.Age);
            Console.ReadLine();

        }
        static void NumOfAuthors()
        {
            var rtw = authorlogic.NumOfAuthors();
            Console.WriteLine($"{rtw} authors are registered in the database");
            Console.ReadLine() ;
        }

        //Book
        static void BestRatedBookInfo()
        {
            var item = booklogic.BestRatedBookInfo();
            Console.WriteLine("Title: " + item.Title);
            Console.WriteLine("Rating: " + item.Rating);
            Console.ReadLine();
            
        }
        static void LongestTitleBookInfo()
        {
            var item = booklogic.LongestTitleBookInfo();
            Console.WriteLine("Title: " + item.Title);
            Console.WriteLine("Length of title: " + item.Title.Length);
            Console.ReadLine();
            

        }
        static void MostExpensiveBookInfo()
        {
            var item = booklogic.MostExpensiveBookInfo();
            Console.WriteLine("Title: " + item.Title);
            Console.WriteLine("Price: " + item.Price);
            Console.ReadLine();
            
        }
        static void MostPagesInABookInfo()
        {
            var item = booklogic.MostPagesInABookInfo();
            Console.WriteLine("Title: " + item.Title);
            Console.WriteLine("Number of pages: " + item.Pages);
            Console.ReadLine();
            

        }
        static void WorstRatedBookInfo()
        {
            var item = booklogic.WorstRatedBookInfo();
            Console.WriteLine("Title: " + item.Title);
            Console.WriteLine("Rating: " + item.Rating);
            Console.ReadLine();
           
        }


        //Genre
        static void NumOfGenres()
        {
            var rtw = genrelogic.NumOfGenres();
            Console.WriteLine($"{rtw} genres are registered in the database");
            Console.ReadLine();
        }


    }
}
