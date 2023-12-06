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
        [MinLength(3)]
        public string GenreName { get; set; }
        [JsonIgnore]
        public virtual ICollection<Book> Books { get; set; }
        public Genre()
        {

        }
        public Genre(string line)
        {
            string[] split = line.Split('#');
            GenreID = int.Parse(split[0]);
            GenreName = split[1];
        }


    }
}
