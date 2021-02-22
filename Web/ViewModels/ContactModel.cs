using System.ComponentModel.DataAnnotations;

namespace Web.ViewModels
{
    public class ContactModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string EMail { get; set; }

        [Required]
        public string Subject { get; set; }

        [Required]
        public string Message { get; set; }
    }
}