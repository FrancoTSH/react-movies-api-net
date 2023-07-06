namespace react_movies_api_net.Features.Auth.ResponseModels
{
    public class AuthenticationResponse
    {
        public string AccessToken { get; set; } = default!;
        public string RefreshToken { get; set; } = default!;
    }
}
