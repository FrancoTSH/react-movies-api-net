using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using react_movies_api_net.Data;
using react_movies_api_net.Features.Movies.Queries.GetMovie;

namespace react_movies_api_net.Features.Movies.Queries.GetRandomMovie
{
    public class GetRandomMovieQueryHandler : IRequestHandler<GetRandomMovieQuery, GetMovieQueryResponse>
    {
        private readonly DBContext _context;
        private readonly IMapper _mapper;

        public GetRandomMovieQueryHandler(DBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<GetMovieQueryResponse> Handle(GetRandomMovieQuery request, CancellationToken cancellationToken)
        {
            var movie = await _context.Movies.OrderBy(movie => Guid.NewGuid()).FirstAsync();

            return _mapper.Map<GetMovieQueryResponse>(movie);
        }
    }
}
