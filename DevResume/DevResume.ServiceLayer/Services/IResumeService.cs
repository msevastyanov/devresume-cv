using System.Collections.Generic;
using System.Threading.Tasks;
using DevResume.Domain.Entities;

namespace DevResume.ServiceLayer.Services
{
    public interface IResumeService
    {
        Task<List<Resume>> GetResumesAsync(string userName);
        Task<Resume> GetResume(int resumeId);
        Task<Resume> GetResume(string resumeKey);
        Task<Resume> AddResume(Resume resume, string userName);
        Task<bool> UpdateResume(Resume resume);
    }
}