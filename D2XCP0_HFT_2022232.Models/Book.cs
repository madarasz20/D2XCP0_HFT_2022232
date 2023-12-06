using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace D2XCP0_HFT_2022232.Models
{
    public class Book
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookID { get; set; }
        [Required]
        [StringLength(70)]
        [MinLength(5)]
        public string Title { get; set; }
        public int AuthorID { get; set; }    
        public int GenreID { get; set; }
        public int Price { get; set; }
        public int Rating { get; set; }
        public int Pages { get; set; }


        // Navigation properties to represent the relationships
        public virtual Author Author { get; set; }
        public virtual Genre Genre { get; set; }

        public Book()
        {
                
        }
        public Book(string line)
        {
            string[] split = line.Split('#');
            BookID = int.Parse(split[0]);
            Title = split[1];
            AuthorID = int.Parse(split[2]);
            GenreID = int.Parse(split[3]);
            Price = int.Parse(split[4]);

            Rating = int.Parse(split[5]);
            Pages = int.Parse(split[6]);


        }

        public override bool Equals(object obj)
        {
            Book a = obj as Book;
            if (a == null)
            {
                return false;
            }
            else
            {
                return this.BookID == a.BookID && this.Title == a.Title && this.AuthorID == a.AuthorID
                    && this.GenreID == a.GenreID && this.Price == a.Price && this.Rating == a.Rating
                    && this.Pages == a.Pages;
            }
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(this.BookID, this.Title, this.AuthorID, this.GenreID
                , this.Price, this.Rating);
        }

    }
}
