using Common.Application.SecurityUtil;
using Microsoft.AspNetCore.Http;

namespace Framework.Application
{
    public static class Uploader
    {
        public static string ImageUploader(IFormFile file, string path, string currentImage)
        {
            if (file is null || !file.IsImage()) return "";

            var directoryPath = $"{Directory.GetCurrentDirectory()}\\wwwroot\\Images\\{path}";

            if (!Directory.Exists(directoryPath))
                Directory.CreateDirectory(directoryPath);

            //If currentImage Exists
            ImageRemover($"{directoryPath}\\" + currentImage);

            var fileName = $"{DateTime.Now.ToFileName()}-{file.FileName}";
            var filePath = $"{directoryPath}\\{fileName}";
            using var output = File.Create(filePath);
            file.CopyTo(output);
            return $"{fileName}";
        }

        public static void ImageRemover(string imageName)
        {
            if (string.IsNullOrWhiteSpace(imageName)) return;
            if (File.Exists(imageName)) File.Delete(imageName);
        }

        public static void DirectoryRemover(string directory)
        {
            if (string.IsNullOrWhiteSpace(directory)) return;
            var directoryPath = $"{Directory.GetCurrentDirectory()}\\wwwroot\\Images\\{directory}";
            if (Directory.Exists(directoryPath)) Directory.Delete(directoryPath,true);
        }
    }
}
