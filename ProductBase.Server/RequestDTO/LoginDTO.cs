using Azure.Identity;

namespace ProductBase.Server.RequestDTO
{
    public class LoginDTO
    {
        public string Username{get;set;}
        public string Password { get;set;}
    }
}
