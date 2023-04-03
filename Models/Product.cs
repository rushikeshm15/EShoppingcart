using System.ComponentModel.DataAnnotations;

namespace eshopping.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public string Productname { get; set; }

        public string Productdescription { get; set; }

        public int? Productprice { get; set; } = 0;

        //[ForeignKey]
        //public int Categoryid { get; set; }


    }
}