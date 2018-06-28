using System;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        //[Display(Name="Genre")]
        //[Required]
        //public int Genre_Id { get; set; }

        [Required]
        public Genre Genre { get; set; }

        [Display(Name="Release Date")]
        public DateTime ReleaseDate { get; set; }

        public DateTime DateAdded { get; set; }

        [Display(Name="Number in Stock")]
        public int NumberInStock { get; set; }
    }

}
