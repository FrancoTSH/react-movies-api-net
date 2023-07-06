using AutoMapper;
using MediatR;
using react_movies_api_net.Data;
using react_movies_api_net.Exceptions;

namespace react_movies_api_net.Features.Movies.Queries.GetMovie
{
    public class GetMovieQueryHandler : IRequestHandler<GetMovieQuery, GetMovieQueryResponse>
    {
        private readonly DBContext _context;
        private readonly IMapper _mapper;
        public GetMovieQueryHandler(DBContext context, IMapper mapper)
        {

            _context = context;
            _mapper = mapper;
        }

        public async Task<GetMovieQueryResponse> Handle(GetMovieQuery request, CancellationToken cancellationToken)
        {
            var movie = await _context.Movies.FindAsync(request.MovieId);

            if (movie == null)
            {
                throw new EntityNotFoundException();
            }

            return _mapper.Map<GetMovieQueryResponse>(movie);
        }
    }
}
