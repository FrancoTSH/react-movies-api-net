using MediatR;

namespace react_movies_api_net.Features.Users.Queries.GetProfile
{
    public record GetProfileQuery(int UserId) : IRequest<GetProfileQueryResponse>;
}
