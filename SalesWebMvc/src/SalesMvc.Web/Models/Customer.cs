using System;
using System.ComponentModel.DataAnnotations;
using SalesMvc.Web.Libraries.Lang;

namespace SalesMvc.Web.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required(ErrorMessage = null, ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "MSG_E001")]
        [MinLength(4, ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "MSG_E002")]
        public string Name { get; set; }

        [Required(ErrorMessage = null, ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "MSG_E001")]
        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage = null, ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "MSG_E001")]
        public string Gender { get; set; }

        [Required(ErrorMessage = null, ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "MSG_E001")]
        public string CPF { get; set; }

        [Required(ErrorMessage = null, ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "MSG_E001")]
        public string Tel { get; set; }

        [Required(ErrorMessage = null, ErrorMessageResourceName = "MSG_E001", ErrorMessageResourceType = typeof(Message))]
        [EmailAddress(ErrorMessage = null, ErrorMessageResourceName = "MSG_E004", ErrorMessageResourceType = typeof(Message))]
        public string Email { get; set; }

        [Required(ErrorMessage = null, ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "MSG_E001")]
        [MinLength(6, ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "MSG_E002")]
        public string Password { get; set; }

        [NotMapped]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = null, ErrorMessageResourceName = "MSG_E005", ErrorMessageResourceType = typeof(Message))]
        public string ConfirmationPassword { get; set; }

        [Display(Name = "Situation")]
        public string Situation { get; set; }
    }
}
