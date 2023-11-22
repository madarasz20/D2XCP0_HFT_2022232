using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        public string Rating { get; set; }
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
            Rating = split[5];
            Pages = int.Parse(split[6]);


        }


    }
}
