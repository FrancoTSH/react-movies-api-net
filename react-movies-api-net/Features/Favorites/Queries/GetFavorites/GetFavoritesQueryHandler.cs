using AutoMapper;
using MediatR;
using react_movies_api_net.Data;

namespace react_movies_api_net.Features.Favorites.Queries.GetFavorites
{
    public class GetFavoritesQueryHandler : IRequestHandler<GetFavoritesQuery, List<GetFavoritesQueryResponse>>
    {
        private readonly DBContext _context;
        private readonly IMapper _mapper;
        public GetFavoritesQueryHandler(DBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<GetFavoritesQueryResponse>> Handle(GetFavoritesQuery request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.FindAsync(request.UserId, cancellationToken);

            return _mapper.Map<List<GetFavoritesQueryResponse>>(user?.Movies);
        }
    }
}
