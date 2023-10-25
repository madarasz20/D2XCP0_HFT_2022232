using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public int AuthorID { get; set; }
        public int GenreID { get; set; }

        public int Price { get; set; }
        public double Rating { get; set; }
        public int NumberOfReviews { get; set; }

    }
}
