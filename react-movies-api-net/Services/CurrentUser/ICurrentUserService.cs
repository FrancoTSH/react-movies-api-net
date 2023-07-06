namespace react_movies_api_net.Services.CurrentUser
{
    public interface ICurrentUserService
    {
        CurrentUser User { get; }

    }

    public record CurrentUser(int Id);
}
