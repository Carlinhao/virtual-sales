using System.ComponentModel.DataAnnotations;
using SalesMvc.Web.Libraries.Lang;

namespace SalesMvc.Web.Models
{
    public class NewsLetterEmail
    {
        public int Id { get; set; }

        [Required(ErrorMessageResourceType = typeof(Message), ErrorMessage = "MSG_E001")]
        [EmailAddress(ErrorMessageResourceType = typeof(Message), ErrorMessage = "MSG_E004")]
        public string Email { get; set; }
    }
}
