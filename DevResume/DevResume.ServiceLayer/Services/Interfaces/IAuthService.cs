using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DevResume.ServiceLayer.Services.Interfaces
{
    public interface IAuthService
    {
        Task<bool> AuthorizeResume(string username, int resumeId);
        Task<bool> AuthorizeProject(string username, int projectId);
        Task<bool> AuthorizeSkill(string username, int skillId);
        Task<bool> AuthorizeExperience(string username, int experienceId);
        Task<bool> AuthorizeEducation(string username, int educationId);
    }
}
