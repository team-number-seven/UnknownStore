using System.Collections.Generic;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace UnknownStore.BusinessLogic.Extensions
{
    public static class FormFileExtension
    {
        private static readonly IDictionary<string, string> ImageMimeDictionary = new Dictionary<string, string>
        {
            { ".bmp", "image/bmp" },
            { ".dib", "image/bmp" },
            { ".gif", "image/gif" },
            { ".svg", "image/svg+xml" },
            { ".jpe", "image/jpeg" },
            { ".jpeg", "image/jpeg" },
            { ".jpg", "image/jpeg" },
            { ".png", "image/png" },
            { ".pnz", "image/png" }
        };

        public static string FileExtension(this IFormFile file)
        {
            return Path.GetExtension(file.FileName);
        }

        public static bool IsImage(this IFormFile file)
        {
            return ImageMimeDictionary.ContainsKey(file.FileExtension().ToLower());
        }
    }
}