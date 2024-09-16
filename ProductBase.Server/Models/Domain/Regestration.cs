using System.ComponentModel.DataAnnotations;

namespace ProductBase.Models.Domain
{
    public class Regestration
    {
        [Key]
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string EmailId { get; set; }
        public string Password { get; set; }
        public string MobileNo { get; set; }
    }
}
