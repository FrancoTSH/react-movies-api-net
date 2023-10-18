using MediatR;
using react_movies_api_net.Features.Auth.ResponseModels;
using System.ComponentModel.DataAnnotations;

namespace react_movies_api_net.Features.Auth.Commands.Register
{
    public class RegisterCommand : IRequest<AuthenticationResponse>
    {
        [Required]
        public string Name { get; set; } = default!;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = default!;

        [Required]
        [MinLength(6)]
        public string Password { get; set; } = default!;
    }
}
