using System.ComponentModel.DataAnnotations;
using SalesMvc.Web.Libraries.Lang;

namespace SalesMvc.Web.Models
{
    public class Contact
    {
        [Required(ErrorMessageResourceType = typeof(Message), ErrorMessage = "MSG_E001")]
        [MinLength(4, ErrorMessageResourceType = typeof(Message), ErrorMessage = "MSG_E002")]
        public string Name { get; set; }

        [Required(ErrorMessageResourceType = typeof(Message), ErrorMessage = "MSG_E001")]
        [EmailAddress(ErrorMessageResourceType = typeof(Message), ErrorMessage = "MSG_E004")]
        public string Email { get; set; }

        [Required(ErrorMessageResourceType = typeof(Message), ErrorMessage = "MSG_E001")]
        [MinLength(100, ErrorMessageResourceType = typeof(Message), ErrorMessage = "MSG_E002")]
        [MaxLength(1000, ErrorMessageResourceType = typeof(Message), ErrorMessage = "MSG_E003")]
        public string Text { get; set; }
    }
}
