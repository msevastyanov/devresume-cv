using System.Collections.Generic;
using System.Threading.Tasks;
using DevResume.Domain.Entities;

namespace DevResume.Infrastructure.Repositories
{
    public interface IProjectRepository
    {
        Task<List<Project>> GetProjects(int resumeId);
        Task<Project> FindProject(int projectId);
        Task<bool> CheckProjectExist(string username, int projectId);
        Task AddProject(Project project);
        Task UpdateProject(Project project);
        Task DeleteProject(int projectId);
    }
}