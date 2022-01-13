using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SalesMvc.Web.Libraries.Lang;

namespace SalesMvc.Web.Models
{
    public class Employee
    {
        [Display(Name = "Código")]
        public int Id { get; set; }

        [Required(ErrorMessageResourceType = typeof(Message), ErrorMessage = "MSG_E001")]
        [MinLength(4, ErrorMessageResourceType = typeof(Message), ErrorMessage = "MSG_E002")]
        public string Name { get; set; }

        [Display(Name = "E-mail")]
        [Required(ErrorMessageResourceType = typeof(Message), ErrorMessage = "MSG_E001")]
        [EmailAddress(ErrorMessageResourceType = typeof(Message), ErrorMessage = "MSG_E004")]
        public string Email { get; set; }

        [Required(ErrorMessage = null, ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "MSG_E001")]
        [MinLength(6, ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "MSG_E002")]
        public string Password { get; set; }

        [NotMapped]
        public string ConfirmationPassword { get; set; }

        [Required]
        public string Type { get; set; }
    }
}
