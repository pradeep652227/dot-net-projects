using System.ComponentModel.DataAnnotations;

namespace MvCProj_1.Models
{
    public class Movie
    {
        [Required]
        public int Id { get; set; }
        public string? Title { get; set; }

        //with this, the user is not required to send the time part of datetime
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        public string? Genre { get; set; }
        public decimal Price { get; set; }
    }
}
