using AutoMapper;
using MediatR;
using react_movies_api_net.Data;

namespace react_movies_api_net.Features.Users.Queries.GetProfile
{
    public class GetProfileQueryHandler : IRequestHandler<GetProfileQuery, GetProfileQueryResponse>
    {
        private readonly DBContext _context;
        private readonly IMapper _mapper;

        public GetProfileQueryHandler(DBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<GetProfileQueryResponse> Handle(GetProfileQuery request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.FindAsync(request.UserId);

            return _mapper.Map<GetProfileQueryResponse>(user);
        }
    }
}
