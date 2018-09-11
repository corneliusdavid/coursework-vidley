using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models.DTOs
{
    public class MovieDTO
    {
        public int Id { get; set; }

        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        public int GenreTypeId { get; set; }

        [Required]
        public DateTime ReleaseDate { get; set; }

        [Required]
        [Range(1, 20, ErrorMessage = "There isn't room for any more than 20 copies of the movie in our store.")]
        public int NumberInStock { get; set; }
    }
}