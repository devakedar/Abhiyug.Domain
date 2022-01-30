using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Abhiyog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private IJwtAuthenticationManager jwtAuthenticationManager;
        public ValuesController(IJwtAuthenticationManager jwtAuthenticationManager)
        {
            this.jwtAuthenticationManager = jwtAuthenticationManager;
        }
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] UserCred userCred)
        {
            var token  = jwtAuthenticationManager.Authenticate(userCred.Username, userCred.Password);
            if(token == null)
            {
                return Unauthorized();  
            }
            return Ok(token);
        }
    }
}
