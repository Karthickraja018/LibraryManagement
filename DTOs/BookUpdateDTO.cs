using System.ComponentModel.DataAnnotations;
namespace LibraryManagement.DTOs
{
    public class BookUpdateDTO
    {
        [Required]
        [MinLength(2)]
        public string Title { get; set; }
        [Required]
        [MinLength(2)]
        public string Author { get; set; }
        public int PublicationYear { get; set; }
    }
}
