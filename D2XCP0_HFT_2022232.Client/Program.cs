using ConsoleTools;
using System;
using System.Collections.Generic;
using D2XCP0_HFT_2022232.Models;
using D2XCP0_HFT_2022232.Repository;
using D2XCP0_HFT_2022232.Logic;

namespace D2XCP0_HFT_2022232.Client
{
    internal class Program
    {

        static RestService rest;
        static void Create(string entity)
        {
            Console.WriteLine(entity + "create");
            Console.ReadLine();
        }
        static void List(string entity)
        {
            Console.WriteLine(entity + "list");
            Console.ReadLine();
        }
        static void Update(string entity)
        {
            Console.WriteLine(entity + "update");
            Console.ReadLine();
        }
        static void Delete(string entity)
        {
            Console.WriteLine(entity + "delete");
            Console.ReadLine();
        }
        static void Main(string[] args)
        {
            //rest = new RestService("http://localhost:55033/", "book");
            var ctx = new BookStorageDb();

            var bookrepo = new BookRepository(ctx);
            var authorrepo = new AuthorRepository(ctx);
            var genrerepo = new GenreRepository(ctx);

            var booklogic = new BookLogic(bookrepo);
            var authorlogic = new AuthorLogic(authorrepo);
            var genrelogic = new GenreLogic(genrerepo);

            var bookSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Book"))
                .Add("Create", () => Create("Book"))
                .Add("Update", () => Update("Book"))
                .Add("Delete", () => Delete("Book"));

            var authorSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Author"))
                .Add("Create", () => Create("Author"))
                .Add("Update", () => Update("Author"))
                .Add("Delete", () => Delete("Author"));

            var genreSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Genre"))
                .Add("Create", () => Create("Genre"))
                .Add("Update", () => Update("Genre"))
                .Add("Delete", () => Delete("Genre"));
                

            var menu = new ConsoleMenu(args, level: 0)
                .Add("Books", () => bookSubMenu.Show())
                .Add("Authors", () => authorSubMenu.Show())
                .Add("Genre", () => genreSubMenu.Show());
            
            menu.Show();
        }
    }
}
