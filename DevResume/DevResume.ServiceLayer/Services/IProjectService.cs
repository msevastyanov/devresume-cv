using DevResume.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DevResume.ServiceLayer.Services
{
    public interface IProjectService
    {
        Task<List<Project>> GetProjects(int resumeId);
        Task<Project> GetProject(int id);
        Task AddProject(Project model, int resumeId);
        Task<bool> UpdateProject(Project model);
        Task DeleteProject(int id);
    }
}
