using CardService.Models.Requests;
using CardService.Models.Response;
using CardService.Services;
using CardStorageService.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using System.Net.Http.Headers;

namespace CardService.Controllers
{
    public class AuthenticationController : Controller
    {
        [Authorize]
        [Route("api/auth")]
        [ApiController]
        public class AuthenticateController : ControllerBase
        {
         

            private readonly IAuthenticateService _authenticateService;

         
            public AuthenticateController(IAuthenticateService authenticateService)
            {
                _authenticateService = authenticateService;
            }


            [AllowAnonymous]
            [HttpPost("login")]
            public IActionResult Login([FromBody] AuthenticationRequest authenticationRequest)
            {
                AuthenticationResponse authenticationResponse = _authenticateService.Login(authenticationRequest);
                if (authenticationResponse.Status == Models.AuthenticationStatus.Success)
                {
                    Response.Headers.Add("X-Session-Token", authenticationResponse.SessionInfo.SessionToken);
                }
                return Ok(authenticationResponse);
            }

            [HttpGet("session")]
            public IActionResult GetSessionInfo()
            {
                // Authorization : Bearer XXXXXXXXXXXXXXXXXXXXXXXX

                var authorization = Request.Headers[HeaderNames.Authorization];

                if (AuthenticationHeaderValue.TryParse(authorization, out var headerValue))
                {
                    var scheme = headerValue.Scheme; // "Bearer"
                    var sessionToken = headerValue.Parameter; // Token
                    if (string.IsNullOrEmpty(sessionToken))
                        return Unauthorized();

                    SessionInfo sessionInfo = _authenticateService.GetSessionInfo(sessionToken);
                    if (sessionInfo == null)
                        return Unauthorized();

                    return Ok(sessionInfo);
                }
                return Unauthorized();

            }


        }
    }
}
