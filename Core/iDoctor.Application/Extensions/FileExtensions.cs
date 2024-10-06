using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iDoctor.Application.Extensions
{
    public static class FileExtensions
    {
        public static string ToBase64(this IFormFile file)
        {
            using (var memoryStream=new MemoryStream())
            {
                file.CopyTo(memoryStream);
                var imageBytes= memoryStream.ToArray();
                return Convert.ToBase64String(imageBytes);
            }
        }
    }
}
