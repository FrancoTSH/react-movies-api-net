using MediatR;
using react_movies_api_net.Features.Users.Queries.GetProfile;

namespace react_movies_api_net.Features.Users.Commands.UpdateProfile
{
    public class UpdateProfileCommand : IRequest<GetProfileQueryResponse>
    {
        public int Id { get; set; } = default!;
        public string Name { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string PhotoUrl { get; set; } = default!;
    }
}
