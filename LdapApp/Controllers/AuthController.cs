using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace LdapApp.Controllers
{
    [Route("api/[controller]")] // api/auth
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly ILogger<AuthController> _logger;

        public AuthController(ILogger<AuthController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult TestRun()
        {
            return Ok(string.Format("Ldap URL => {0}", Const.LDAP_PATH));
        }
    }
}
