using System.ComponentModel.DataAnnotations;

namespace AddressBook.Models
{
    public class Contact
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [RegularExpression(@"^([a-zA-Z\d\._-]+)@([a-zA-Z\d-]+)\.([a-zA-Z]{2,8})(\.[a-zA-Z]{2,8})?$", ErrorMessage = "Email is invalid")]
        public string Email { get; set; }

        [Required]
        [RegularExpression(@"^(\+91)?(\ )?([\d]{10})$", ErrorMessage = "Mobile is invalid")]
        public string Mobile { get; set; }

        public string? Landline { get; set; }

        public string? Website { get; set; }

        public string? Address { get; set; }
    }
}
