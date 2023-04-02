using System.ComponentModel.DataAnnotations;

namespace eshopping.Models
{
    public class ProductCategory
    {
        [Key]
        public int CategoryId { get; set; }
        public string Type { get; set; }

    }
}