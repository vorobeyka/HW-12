using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DepsWebApp.Models;
using DepsWebApp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DepsWebApp.Controllers
{
    /// <summary>
    /// Authorization controller for register accounts.
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAccountService _accountService;
        public AuthController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        /// <summary>
        /// Register account in memory.
        /// </summary>
        /// <param name="request"></param>
        /// <returns>Base64 string.</returns>
        [HttpPost]
        [AllowAnonymous]
        [Route("reguster")]
        public async Task<ActionResult<string>> Register([FromBody]AuthRequest request)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            
            var baseKey = await _accountService.RegisterAsync(request.Login, request.Password);
            if (string.IsNullOrEmpty(baseKey)) return BadRequest();
            return baseKey;
        }
    }
}
