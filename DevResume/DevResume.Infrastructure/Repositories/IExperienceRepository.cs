using DevResume.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace DevResume.Infrastructure.Repositories
{
    public interface IExperienceRepository
    {
        Task<List<Experience>> GetExperience(int resumeId);
        Task<Experience> FindExperience(int experienceId);
        Task<bool> CheckExperienceExist(string username, int experienceId);
        Task AddExperience(Experience experience);
        Task UpdateExperience(Experience experience);
        Task DeleteExperience(int experienceId);
    }
}