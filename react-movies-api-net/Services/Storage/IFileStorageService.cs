namespace react_movies_api_net.Services.Storage
{
    public interface IFileStorageService
    {
        public Task<string> Store(IFormFile file);

        public Task<(byte[], string, string)> Load(string path);

        public void Delete(string path);
    }
}
