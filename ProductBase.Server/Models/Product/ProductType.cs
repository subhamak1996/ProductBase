using System.ComponentModel.DataAnnotations;

namespace ProductBase.Models.Product
{
    public class ProductType
    {
        [Key]
        public Guid PTId { get; set; }
        public string ProductTypeName { get; set; }
        public string ProductTypeDescription { get; set; }
        

    }
}
