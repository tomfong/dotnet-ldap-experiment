using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

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
            return Ok(String.Format("Ldap URL => LDAP://{0}:{1}", Const.LDAP_SERVER_ADDRESS, Const.LDAP_SERVER_PORT));
        }
    }
}
