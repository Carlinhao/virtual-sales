using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SalesMvc.Web.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Value { get; set; }
        public int ProductQuantity { get; set; }

        // Delivery
        public double Peso { get; set; }
        public double Hight { get; set; }
        public double Large { get; set; }
        public double Length { get; set; }

        // Relationship Entity        
        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }

        public virtual ICollection<Image> Imagens { get; set; }
    }
}
