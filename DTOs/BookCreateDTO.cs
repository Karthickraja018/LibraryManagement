using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace LibraryManagement.DTOs
{
    public class BookCreateDTO : IValidatableObject
    {
        [Required]
        public string ISBN { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Author { get; set; }

        [Required]
        public int PublicationYear { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();
            var normalizedIsbn = Regex.Replace(ISBN ?? "", @"[\s-]", "");

            if (PublicationYear < 2007)
            {
                if (normalizedIsbn.Length != 10)
                {
                    results.Add(new ValidationResult("Books released before 2007 must have a 10-digit ISBN.", new[] { nameof(ISBN) }));
                }
            }
            else
            {
                if (normalizedIsbn.Length != 13 || (!normalizedIsbn.StartsWith("978") && !normalizedIsbn.StartsWith("979")))
                {
                    results.Add(new ValidationResult("Books released from 2007 onwards must have a 13-digit ISBN starting with 978 or 979.", new[] { nameof(ISBN) }));
                }
            }

            return results;
        }
    }
}
