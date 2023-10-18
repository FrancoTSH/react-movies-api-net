using AutoMapper;
using MediatR;
using react_movies_api_net.Data;
using react_movies_api_net.Exceptions;
using react_movies_api_net.Features.Users.Queries.GetProfile;

namespace react_movies_api_net.Features.Users.Commands.UpdateProfile
{
    public class UpdateProfileCommandHandler : IRequestHandler<UpdateProfileCommand, GetProfileQueryResponse>
    {
        private readonly DBContext _context;
        private readonly IMapper _mapper;

        public UpdateProfileCommandHandler(DBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<GetProfileQueryResponse> Handle(UpdateProfileCommand request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.FindAsync(request.Id) ?? throw new EntityNotFoundException();
            user.Name = request.Name;
            user.Email = request.Email;
            user.PhotoUrl = request.PhotoUrl;

            await _context.SaveChangesAsync();

            return _mapper.Map<GetProfileQueryResponse>(request);
        }
    }
}
