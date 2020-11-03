using DevResume.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DevResume.ServiceLayer.Services
{
    public interface IEducationService
    {
        Task<List<Education>> GetEducations(int resumeId);
        Task<Education> GetEducation(int id);
        Task AddEducation(Education model, int resumeId);
        Task<bool> UpdateEducation(Education model);
        Task DeleteEducation(int id);
    }
}
