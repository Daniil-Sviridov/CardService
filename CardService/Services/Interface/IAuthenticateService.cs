using CardService.Models.Requests;
using CardService.Models.Response;
using CardStorageService.Models;

namespace CardService.Services
{
    public interface IAuthenticateService
    {
        AuthenticationResponse Login(AuthenticationRequest authenticationRequest);

        public SessionInfo GetSessionInfo(string sessionToken);
    }
}
