using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NuGet.Common;
using ProductBase.Server.Repositories;
using ProductBase.Server.RequestDTO;

namespace ProductBase.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginRepo _loginRepo;
        public LoginController( ILoginRepo loginRepo)
        {
             _loginRepo = loginRepo;
        }
        [HttpPost]
        
        public IActionResult Login(LoginDTO loginDTO)
        {
            string result=_loginRepo.LoginDetails(loginDTO);
            return Ok(new { result });
        }

    }
}
