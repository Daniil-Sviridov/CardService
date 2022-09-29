using CardStorageService.Models;

namespace CardService.Models.Response
{
    public class AuthenticationResponse
    {
        public AuthenticationStatus Status { get; set; }

        public SessionInfo SessionInfo { get; set; }

    }
}
