using System.ComponentModel.DataAnnotations;

namespace ProductBase.Models.Product
{
    public class ProductDetails
    {
        [Key]
        public Guid PDId { get; set; }
        public string PTId { get; set; }
        public string ProductNameName { get; set; }
        public string ProductDescription { get; set; }


    }
}
