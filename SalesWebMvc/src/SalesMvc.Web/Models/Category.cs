using System.ComponentModel.DataAnnotations.Schema;

namespace SalesMvc.Web.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Slug {  get; set; }
        public int? CategoryFatherId { get; set; }

        [ForeignKey("CategoryFatherId")]
        public virtual Category CategoryFather { get; set; }
    }
}
