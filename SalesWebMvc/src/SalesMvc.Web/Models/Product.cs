using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SalesMvc.Web.Libraries.Lang;

namespace SalesMvc.Web.Models
{
    public class Product
    {
        public int Id { get; set; }

		[Required(ErrorMessage = null, ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "MSG_E001")]
		public string Name { get; set; }

		[Required(ErrorMessage = null, ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "MSG_E001")]
		public string Description { get; set; }

		[Required(ErrorMessage = null, ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "MSG_E001")]
        [Column(TypeName = "decimal(18,2)")]
		[Display(Name = "Price")]
		public decimal Value { get; set; }

		[Required(ErrorMessage = null, ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "MSG_E001")]
		[Range(0,10000, ErrorMessage = null, ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "MSG_E006")]
		[Display(Name = "Quantity")]
        public int ProductQuantity { get; set; }

		// Delivery
		[Required(ErrorMessage = null, ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "MSG_E001")]
		[Range(0.01, 30, ErrorMessage = null, ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "MSG_E006")]
		public double Peso { get; set; }

		[Required(ErrorMessage = null, ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "MSG_E001")]
		[Range(11, 105, ErrorMessage = null, ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "MSG_E006")]
		public double Hight { get; set; }

		[Required(ErrorMessage = null, ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "MSG_E001")]
		[Range(2, 105, ErrorMessage = null, ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "MSG_E006")]
		public double Large { get; set; }

		[Required(ErrorMessage = null, ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "MSG_E001")]
		[Range(16, 105, ErrorMessage = null, ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "MSG_E006")]
		public double Length { get; set; }

		// Relationship Entity
		[Required(ErrorMessage = null, ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "MSG_E001")]
		[Display(Name = "Category")]
		public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }

        public virtual ICollection<Image> Imagens { get; set; }
    }
}
