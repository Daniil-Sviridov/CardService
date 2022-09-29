using CardService.Models.Requests;
using CardService.Models.Response;
using CardService.Services;
using CardStorageService.Models;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using System.Net.Http.Headers;

namespace CardService.Controllers
{
    [Authorize]
    [Route("api/auth")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {


        private readonly IAuthenticateService _authenticateService;
        private readonly ILogger<AuthenticateService> _logger;
        private readonly IValidator<AuthenticationRequest> _validator;

        public AuthenticateController(IAuthenticateService authenticateService, ILogger<AuthenticateService> logger, IValidator<AuthenticationRequest> validator)
        {
            _authenticateService = authenticateService;
            _logger = logger;
            _validator = validator;
        }


        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult Login([FromBody] AuthenticationRequest authenticationRequest)
        {
            _logger.Log(LogLevel.Information, "api/auth");

            ValidationResult validationResult = _validator.Validate(authenticationRequest);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.ToDictionary());


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

