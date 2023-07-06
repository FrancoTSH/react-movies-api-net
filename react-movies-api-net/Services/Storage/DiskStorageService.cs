using Microsoft.AspNetCore.StaticFiles;
using react_movies_api_net.Exceptions;

namespace react_movies_api_net.Services.Storage
{
    public class DiskStorageService : IFileStorageService
    {
        private readonly string _rootDir;

        public DiskStorageService(IWebHostEnvironment enviroment, IConfiguration config)
        {
            _rootDir = Path.Combine(enviroment.ContentRootPath, config.GetValue<string>("Storage:destination"));
        }

        public async Task<string> Store(IFormFile file)
        {
            try
            {
                if (file.Length == 0)
                {
                    throw new StorageException("Failed to store empty file");
                }

                var fileName = GenerateFileName(file.FileName);
                var destinationPath = Path.Combine(_rootDir, fileName);

                using (var fileStream = new FileStream(destinationPath, FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }

                return fileName;
            }
            catch (IOException ex)
            {
                throw new StorageException("Failed to store file:" + ex.Message);
            }
        }

        public async Task<(byte[], string, string)> Load(string path)
        {
            var filePath = Path.Combine(_rootDir, path);

            if (!File.Exists(filePath))
            {
                throw new StorageException("Could not read the file!");
            }

            var bytes = await File.ReadAllBytesAsync(filePath);

            return (bytes, filePath, GetContentType(filePath));
        }

        public void Delete(string path)
        {
            var filePath = Path.Combine(_rootDir, path);

            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }

        }

        private string GenerateFileName(String originalName)
        {
            return Guid.NewGuid().ToString() + "_" + originalName;
        }

        private string GetContentType(string path)
        {
            var provider = new FileExtensionContentTypeProvider();
            if (!provider.TryGetContentType(path, out string? contentType))
            {
                contentType = "application/octet-stream";
            }

            return contentType;
        }
    }
}
