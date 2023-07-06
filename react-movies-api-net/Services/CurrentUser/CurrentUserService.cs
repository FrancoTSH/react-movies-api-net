using System.Security.Claims;

namespace react_movies_api_net.Services.CurrentUser
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;

            int id = Convert.ToInt32(_httpContextAccessor.HttpContext?.User.Claims.FirstOrDefault(q => q.Type == ClaimTypes.NameIdentifier)?.Value);

            User = new CurrentUser(id);
        }

        public CurrentUser User { get; }
    }
}
