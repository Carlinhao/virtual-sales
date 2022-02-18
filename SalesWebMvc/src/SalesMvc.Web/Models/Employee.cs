using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SalesMvc.Web.Libraries.Lang;
using SalesMvc.Web.Libraries.Validation;

namespace SalesMvc.Web.Models
{
    public class Employee
    {
        [Display(Name = "Código")]
        public int Id { get; set; }

        [Required(ErrorMessage = null, ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "MSG_E001")]
        [MinLength(4, ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "MSG_E002")]
        public string Name { get; set; }

        [Display(Name = "E-mail")]
        [Required(ErrorMessage = null, ErrorMessageResourceName = "MSG_E001", ErrorMessageResourceType = typeof(Message))]
        [EmailAddress(ErrorMessage = null, ErrorMessageResourceName = "MSG_E004", ErrorMessageResourceType = typeof(Message))]
        [UnicEmployeeEmail]
        public string Email { get; set; }

        [Required(ErrorMessage = null, ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "MSG_E001")]
        [MinLength(6, ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "MSG_E002")]
        public string Password { get; set; }

        [NotMapped]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = null, ErrorMessageResourceName = "MSG_E005", ErrorMessageResourceType = typeof(Message))]
        public string ConfirmationPassword { get; set; }

        [Required]
        public string Type { get; set; }
    }
}
