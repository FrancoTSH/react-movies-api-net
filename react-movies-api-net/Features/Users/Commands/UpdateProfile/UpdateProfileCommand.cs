using MediatR;
using react_movies_api_net.Features.Users.Queries.GetProfile;
using System.ComponentModel.DataAnnotations;

namespace react_movies_api_net.Features.Users.Commands.UpdateProfile
{
    public class UpdateProfileCommand : IRequest<GetProfileQueryResponse>
    {
        public int Id { get; set; } = default!;

        [Required]
        public string Name { get; set; } = default!;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = default!;
        public string PhotoUrl { get; set; } = default!;
    }
}
