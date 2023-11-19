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
    public class Genre
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int GenreID { get; set; }
        [Required]
        public string GenreName { get; set; }

        public Genre()
        {
            Books = new HashSet<Book>();
        }

        //Navigational property
        [JsonIgnore]
        public virtual ICollection<Book> Books { get; set; }

    }
}
