using System.Collections.Generic;
using System.Threading.Tasks;
using DevResume.Domain.Entities;

namespace DevResume.Infrastructure.Repositories
{
    public interface IResumeRepository
    {
        Task<List<Resume>> GetUserResumes(string userId);
        Task<Resume> FindResume(int resumeId);
        Task<Resume> FindResume(int resumeId, string userName);
        Task<Resume> FindResume(string resumeKey);
        Task<bool> CheckResumeExist(string username, int resumeId);
        Task<Resume> AddResume(Resume resume);
        Task<Resume> UpdateResume(Resume resume);
        Task DeleteResume(int resumeId);
    }
}