using DevResume.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DevResume.ServiceLayer.Services
{
    public interface IExperienceService
    {
        Task<List<Experience>> GetAllExperience(int resumeId);
        Task<Experience> GetExperience(int id);
        Task AddExperience(Experience model, int resumeId);
        Task<bool> UpdateExperience(Experience model);
        Task DeleteExperience(int id);
    }
}
