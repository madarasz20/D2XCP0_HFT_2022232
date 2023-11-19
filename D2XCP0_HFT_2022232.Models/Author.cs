using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D2XCP0_HFT_2022232.Models
{
    public class Author
    {
        [Key]
        public int AuthorID { get; set; }
        [Required]
        [StringLength(80)]
        public string AuthorName { get; set; }
        public DateTime BirthDay { get; set; }

        //Navigational property
        public ICollection<Book> Books { get; set; }

        public Author()
        {

        }
    }
}
