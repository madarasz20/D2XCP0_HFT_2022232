using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D2XCP0_HFT_2022232.Models
{
    public class Genre
    {
        [Key]
        public int GenreID { get; set; }
        [Required]
        public string GenreName { get; set; }

        //Navigational property
        public virtual ICollection<Book> Books { get; set; }
    }
}
