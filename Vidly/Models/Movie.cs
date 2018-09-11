using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The movie must have some sort of name, right?")]
        [StringLength(255)]
        public string Name { get; set; }

        public int Year { get; set; }

        public GenreType GenreType { get; set; }

        [Required]
        public int GenreTypeId { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; } 
        
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Date Added")]
        public DateTime DateAdded { get; set; } 

        [Required]
        [Display(Name = "Number in Stock")]
        [Range(1, 20, ErrorMessage = "There isn't room for any more than 20 copies of the movie in our store.")]
        public int NumberInStock { get; set; }   
    }
}