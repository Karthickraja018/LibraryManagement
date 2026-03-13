using System.ComponentModel.DataAnnotations;
namespace LibraryManagement.DTOs
{
    public class BookCreateDTO
    {
        [Required]
        [StringLength(10)]
        public string ISBN { get; set; }

        [Required]
        public string Title { get; set; }
        [Required]
        public string Author { get; set; }
        public int PublicationYear { get; set; }
    }
}
