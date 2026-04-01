using System.ComponentModel.DataAnnotations;

namespace LibraryManagement.Models
{
    public class Book
    {
        [Key]
        public string ISBN { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Author { get; set; }
        [Range(1000,2100)]
        public int PublicationYear { get; set; }
    }
}
