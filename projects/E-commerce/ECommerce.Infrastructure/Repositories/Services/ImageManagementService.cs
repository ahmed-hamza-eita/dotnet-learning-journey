using ECommerce.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;

namespace ECommerce.Infrastructure.Services
{
    public class ImageManagementService : IImageManagementService
    {
        private readonly IWebHostEnvironment _environment;

        public ImageManagementService(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        public async Task<List<string>> AddImageAsync(IFormFileCollection files, string folder)
        {
            var savedFileNames = new List<string>();
            var folderPath = Path.Combine(_environment.WebRootPath, folder);

            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);

            foreach (var file in files)
            {
                if (file.Length <= 0) continue;

                var fileName = $"{Guid.NewGuid()}_{file.FileName}";
                var filePath = Path.Combine(folderPath, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                savedFileNames.Add(fileName);
            }

            return savedFileNames;
        }

        public Task DeleteImageAsync(string src)
        {
            var filePath = Path.Combine(_environment.WebRootPath, src);

            if (File.Exists(filePath))
                File.Delete(filePath);

            return Task.CompletedTask;
        }
    }
}