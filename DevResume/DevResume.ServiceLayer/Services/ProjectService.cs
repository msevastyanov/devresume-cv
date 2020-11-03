using DevResume.Domain.Entities;
using DevResume.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DevResume.ServiceLayer.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IResumeRepository _resumeRepository;
        private readonly IProjectRepository _projectRepository;

        public ProjectService(IProjectRepository projectRepository, IResumeRepository resumeRepository)
        {
            _resumeRepository = resumeRepository;
            _projectRepository = projectRepository;
        }

        public async Task<List<Project>> GetProjects(int resumeId)
        {
            var projects = await _projectRepository.GetProjects(resumeId);

            return await Task.FromResult(projects);
        }

        public async Task<Project> GetProject(int id)
        {
            var project = await _projectRepository.FindProject(id);

            return await Task.FromResult(project);
        }

        public async Task AddProject(Project model, int resumeId)
        {
            var resume = await _resumeRepository.FindResume(resumeId);

            model.Resume = resume;

            await _projectRepository.AddProject(model);
        }

        public async Task<bool> UpdateProject(Project model)
        {
            await _projectRepository.UpdateProject(model);

            return await Task.FromResult(true);
        }

        public async Task DeleteProject(int id)
        {
            await _projectRepository.DeleteProject(id);
        }
    }
}
