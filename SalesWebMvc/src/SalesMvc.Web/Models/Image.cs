using System.ComponentModel.DataAnnotations.Schema;

namespace SalesMvc.Web.Models
{
    public class Image
    {
        public int Id { get; set; }
        public string Path { get; set; }

        public int ProductId { get; set; }

        [ForeignKey("ProductId")]
        public Product Product { get; set; }
    }
}