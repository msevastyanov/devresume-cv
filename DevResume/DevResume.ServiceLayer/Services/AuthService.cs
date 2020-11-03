using DevResume.Infrastructure.Repositories;
using DevResume.ServiceLayer.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DevResume.ServiceLayer.Services
{
    public class AuthService : IAuthService
    {
        private readonly IResumeRepository _resumeRepository;
        private readonly IProjectRepository _projectRepository;
        private readonly ISkillRepository _skillRepository;
        private readonly IExperienceRepository _experienceRepository;
        private readonly IEducationRepository _educationRepository;

        public AuthService(IResumeRepository resumeRepository, IProjectRepository projectRepository, ISkillRepository skillRepository, IExperienceRepository experienceRepository, IEducationRepository educationRepository)
        {
            _resumeRepository = resumeRepository;
            _projectRepository = projectRepository;
            _skillRepository = skillRepository;
            _experienceRepository = experienceRepository;
            _educationRepository = educationRepository;
        }

        public async Task<bool> AuthorizeResume(string username, int resumeId)
        {
            return await _resumeRepository.CheckResumeExist(username, resumeId);
        }

        public async Task<bool> AuthorizeProject(string username, int projectId)
        {
            return await _projectRepository.CheckProjectExist(username, projectId);
        }

        public async Task<bool> AuthorizeSkill(string username, int skillId)
        {
            return await _skillRepository.CheckSkillExist(username, skillId);
        }

        public async Task<bool> AuthorizeExperience(string username, int experienceId)
        {
            return await _experienceRepository.CheckExperienceExist(username, experienceId);
        }

        public async Task<bool> AuthorizeEducation(string username, int educationId)
        {
            return await _educationRepository.CheckEducationExist(username, educationId);
        }
    }
}
