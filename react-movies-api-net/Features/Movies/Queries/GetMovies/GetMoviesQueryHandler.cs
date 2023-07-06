using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using react_movies_api_net.Data;
using react_movies_api_net.Data.Entities;

namespace react_movies_api_net.Features.Movies.Queries.GetMovies
{
    public class GetMoviesQueryHandler : IRequestHandler<GetMoviesQuery, List<GetMoviesQueryResponse>>
    {
        private readonly DBContext _context;
        private readonly IMapper _mapper;

        public GetMoviesQueryHandler(DBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<GetMoviesQueryResponse>> Handle(GetMoviesQuery request, CancellationToken cancellationToken)
        {
            IQueryable<Movie> query = _context.Movies.Where(movie => movie.Type == "movie");

            if (!string.IsNullOrWhiteSpace(request.Title))
            {
                query = query.Where(movie => movie.Title.Contains(request.Title));
            }

            if (!string.IsNullOrWhiteSpace(request.Genre))
            {
                query = query.Where(movie => movie.Genre == request.Genre);

            }

            if (!string.IsNullOrWhiteSpace(request.OrderBy) && !string.IsNullOrWhiteSpace(request.SortBy))
            {
                if (request.OrderBy.ToLower() == "desc")
                {
                    query = query.OrderByDescending(movie => EF.Property<object>(movie, request.SortBy));
                }
                else
                {
                    query = query.OrderBy(movie => EF.Property<object>(movie, request.SortBy));
                }
            }
            var movies = await query.ProjectTo<GetMoviesQueryResponse>(_mapper.ConfigurationProvider).ToListAsync();
            return movies;
        }
    }
}
