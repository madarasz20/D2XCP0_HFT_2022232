using ConsoleTools;
using System;
using System.Collections.Generic;
using D2XCP0_HFT_2022232.Models;
using System.Reflection;

namespace D2XCP0_HFT_2022232.Client
{
    internal class Program
    {

        static RestService rest;

        static void Create(string entity)
        {
            if (entity == "Author")
            {
                Console.WriteLine("Enter Author name:");
                string name = Console.ReadLine();
                Console.WriteLine();
                Console.WriteLine("Enter Author's ID:");
                int id = int.Parse(Console.ReadLine());
                Console.WriteLine();
                Console.WriteLine("Enter Author's birthday [MM/DD/YYYY]:");
                DateTime date = DateTime.Parse(Console.ReadLine());
                Console.WriteLine();
                Author a = new Author() { AuthorName = name , AuthorID = id, BirthDay = date};
                rest.Post<Author>(a, "author");
            }
            Console.ReadLine();

        }
        static void List(string entity)
        {
            if (entity == "Author")
            {
                List<Author> authors = rest.Get<Author>("author");
                foreach (var item in authors)
                {
                    Console.WriteLine(item.AuthorName);
                }
            }
            else if(entity == "Book")
            {
                List<Book> books = rest.Get<Book>("book");
                foreach (var item in books)
                {
                    Console.WriteLine(item.Title);
                }
            }
            else if (entity == "Genre")
            {
                List<Genre> genres = rest.Get<Genre>("genre");
                foreach (var item in genres)
                {
                    Console.WriteLine(item.GenreName);
                }
            }
            Console.ReadLine();
        }
        static void Update(string entity)
        {
            if (entity == "Author")
            {
                Console.WriteLine("Enter author's id to update:");
                int id = int.Parse(Console.ReadLine());
                Author one = rest.Get<Author>(id, "author");
                Console.WriteLine($"Enter new name [old name: {one.AuthorName} ]: ");
                string name = Console.ReadLine();
                one.AuthorName = name;
                rest.Put<Author>(one, "author");
            }
            Console.ReadLine();
        }
        static void Delete(string entity)
        {
            if (entity == "Author")
            {
                Console.WriteLine("Enter author's id to delete: ");
                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "author");
            }
            else if (entity == "Book")
            {
                Console.WriteLine("Enter book's id to delete: ");
                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "book");
            }
            else if (entity == "Genre")
            {
                Console.WriteLine("Enter genre's id to delete: ");
                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "genre");
            }
            Console.ReadLine();
        }
        static void Main(string[] args)
        {
            rest = new RestService("http://localhost:55033/", "book");


            var bookSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Book"))
                .Add("Create", () => Create("Book"))
                .Add("Update", () => Update("Book"))
                .Add("Delete", () => Delete("Book"))
                .Add("Exit", ConsoleMenu.Close);

            var authorSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Author"))
                .Add("Create", () => Create("Author"))
                .Add("Update", () => Update("Author"))
                .Add("Delete", () => Delete("Author"))
                .Add("Exit", ConsoleMenu.Close);

            var genreSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Genre"))
                .Add("Create", () => Create("Genre"))
                .Add("Update", () => Update("Genre"))
                .Add("Delete", () => Delete("Genre"))
                .Add("Exit", ConsoleMenu.Close);


            var menu = new ConsoleMenu(args, level: 0)
                .Add("Books", () => bookSubMenu.Show())
                .Add("Authors", () => 
                authorSubMenu.Show())
                .Add("Genre", () => genreSubMenu.Show())
                .Add("Exit", ConsoleMenu.Close);

            
            
            menu.Show();
        }
    }
}
