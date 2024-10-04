using System.ComponentModel.DataAnnotations;

namespace ProductCode.Models.CreditDetails
{
    public class CreditAccountDetails
    {
        [Key]
        public int FId { get; set; }
        public string financingType { get; set; }
        public string accountNumber { get; set; }
        public string fourDigitKey { get; set; }
        public string mobileNumber { get; set; }        
        public int amount { get; set; }


    }
}
