using ConsoleTools;
using D2XCP0_HFT_2022232.Logic;
using D2XCP0_HFT_2022232.Models;
using D2XCP0_HFT_2022232.Repository;
using System;
using System.Linq;

namespace D2XCP0_HFT_2022232.Client
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var ctx = new BookDbcontext();

            var bookrepo = new BookRepository(ctx);
            var authorrepo = new AuthorRepository(ctx);
            var genrerepo = new GenreRepository(ctx);

            var booklogic = new BookLogic(bookrepo);
            var authorlogic = new AuthorLogic(authorrepo);
            var genrelogic = new GenreLogic(genrerepo);

            var autSubSubMenu = new ConsoleMenu(args, level: 2)
               .Add("Show every Author", () => List("Author"))
               .Add("Show Author by ID", () => ListByID("Author"))
               .Add("Exit", ConsoleMenu.Close);

            var bookSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Book"))
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
                .Add("List", () => List("Genre"))
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
            Console.WriteLine(entity + "create");
            Console.WriteLine();
        }
        static void List(string entity)
        {
            Console.WriteLine(entity + "list");
            Console.WriteLine();
        }
        static void ListByID(string entity)
        {
            Console.WriteLine(entity + "listed");
            Console.WriteLine();
        }
        static void Update(string entity)
        {
            Console.WriteLine(entity + "update");
            Console.WriteLine();
        }
        static void Delete(string entity)
        {
            Console.WriteLine(entity + "delete");
            Console.WriteLine();
        }
    }
}
