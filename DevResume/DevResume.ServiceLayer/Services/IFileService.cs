using DevResume.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DevResume.ServiceLayer.Services
{
    public interface IFileService
    {
        Task<List<string>> UploadFiles(List<FileDataModel> files);
    }
}
