
using System.ComponentModel.DataAnnotations;
using SalesMvc.Web.Libraries.Lang;

namespace SalesMvc.Web.Models
{
    public class NewsLetterEmail
    {
        public int Id { get; set; }

        [Required(ErrorMessage = null, ErrorMessageResourceName = "MSG_E001", ErrorMessageResourceType = typeof(Message))]
        [EmailAddress(ErrorMessage = null, ErrorMessageResourceName = "MSG_E004", ErrorMessageResourceType = typeof(Message) )]
        public string Email { get; set; }
    }
}
