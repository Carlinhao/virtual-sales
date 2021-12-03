using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SalesMvc.Web.Libraries.Lang;

namespace SalesMvc.Web.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required(ErrorMessage = null, ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "MSG_E001")]
        [MinLength(4, ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "MSG_E002")]
        // TODO - Create validation Name is unic
        public string Name { get; set; }

        [Required(ErrorMessage = null, ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "MSG_E001")]
        [MinLength(4, ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "MSG_E002")]
        public string Slug {  get; set; }
        public int? CategoryFatherId { get; set; }

        [ForeignKey("CategoryFatherId")]
        public virtual Category CategoryFather { get; set; }
    }
}
