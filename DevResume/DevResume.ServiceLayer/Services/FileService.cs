using DevResume.Domain.Models;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace DevResume.ServiceLayer.Services
{
    public class FileService : IFileService
    {
        private readonly IHostingEnvironment _hostingEnvironment;

        public FileService(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        public async Task<List<string>> UploadFiles(List<FileDataModel> files)
        {
            var fileNames = new List<string>();

            const string dirname = "uploads";
            var contentRootPath = _hostingEnvironment.ContentRootPath;
            var dirPath = Path.Combine(contentRootPath, "wwwroot", dirname);

            if (!Directory.Exists(dirPath))
                Directory.CreateDirectory(dirPath);

            foreach (var file in files)
            {
                var fileName = Path.Combine(Path.GetRandomFileName() + Path.GetExtension(file.Name));
                var path = Path.Combine(dirPath, fileName);
                await file.Data.CopyToAsync(new FileStream(path, FileMode.Create));

                fileNames.Add(fileName);
            }

            return fileNames;
        }
    }
}
