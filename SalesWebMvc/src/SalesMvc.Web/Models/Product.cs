using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SalesMvc.Web.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
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
        public Category Category { get; set; }

        public ICollection<Image> Imagens { get; set; }
    }
}
