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
    public class Author
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AuthorID { get; set; }
        [Required]
        [StringLength(80)]
        [MinLength(5)]
        public string AuthorName { get; set; }
        public DateTime BirthDay { get; set; }

        public int Age
        {
            get
            {
                DateTime today = DateTime.Today;
                int age = today.Year - this.BirthDay.Year;
                return age;
            }
        }
        //Navigational property
        [JsonIgnore]
        public virtual ICollection<Book> Books { get; set; }

        public Author()
        {

        }
        public Author(string line)
        {
            string[] split = line.Split('#');
            AuthorID = int.Parse(split[0]);
            AuthorName = split[1];

            string format = "MM/dd/yyyy";
            BirthDay = DateTime.ParseExact(split[2], format, System.Globalization.CultureInfo.InvariantCulture);
        }
        public override bool Equals(object obj)
        {
            Author a = obj as Author;
            if (a == null)
            {
                return false;
            }
            else
            {
                return this.AuthorID == a.AuthorID && this.AuthorName == a.AuthorName &&
                    this.BirthDay == a.BirthDay && this.Age ==a.Age;
            }
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(this.AuthorID, this.AuthorName, this.BirthDay, this.Age);
        }
    }
}
