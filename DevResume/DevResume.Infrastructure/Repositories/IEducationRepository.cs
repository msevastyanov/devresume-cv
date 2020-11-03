using DevResume.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DevResume.Infrastructure.Repositories
{
    public interface IEducationRepository
    {
        Task<List<Education>> GetEducations(int resumeId);
        Task<Education> FindEducation(int educationId);
        Task<bool> CheckEducationExist(string username, int educationId);
        Task AddEducation(Education education);
        Task UpdateEducation(Education education);
        Task DeleteEducation(int educationId);
    }
}