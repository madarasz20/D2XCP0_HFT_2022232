using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D2XCP0_HFT_2022232.Models
{
    public class Book
    {
        [Key] 
        public int BookID { get; set; }
        [Required]
        [StringLength(70)]
        public string Title { get; set; }


        [ForeignKey("AuthorID")]
        public int AuthorID { get; set; }
        [ForeignKey("GenreID")]
        public int GenreID { get; set; }


        public int Price { get; set; }
        public double Rating { get; set; }

        public int Pages { get; set; }
        public Book()
        {
                
        }

        // Navigation properties to represent the relationships

        public virtual Author Author { get; set; }
        public virtual Genre Genre { get; set; }

    }
}
