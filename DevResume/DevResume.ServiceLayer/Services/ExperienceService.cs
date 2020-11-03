using DevResume.Domain.Entities;
using DevResume.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DevResume.ServiceLayer.Services
{
    public class ExperienceService : IExperienceService
    {
        private readonly IResumeRepository _resumeRepository;
        private readonly IExperienceRepository _experienceRepository;

        public ExperienceService(IExperienceRepository experienceRepository, IResumeRepository resumeRepository)
        {
            _resumeRepository = resumeRepository;
            _experienceRepository = experienceRepository;
        }

        public async Task<List<Experience>> GetAllExperience(int resumeId)
        {
            var experiences = await _experienceRepository.GetExperience(resumeId);

            return await Task.FromResult(experiences);
        }

        public async Task<Experience> GetExperience(int id)
        {
            var experience = await _experienceRepository.FindExperience(id);

            return await Task.FromResult(experience);
        }

        public async Task AddExperience(Experience model, int resumeId)
        {
            var resume = await _resumeRepository.FindResume(resumeId);

            model.Resume = resume;

            if (model.NotFinished)
                model.YearTo = 0;

            await _experienceRepository.AddExperience(model);
        }

        public async Task<bool> UpdateExperience(Experience model)
        {
            if (model.NotFinished)
                model.YearTo = 0;

            await _experienceRepository.UpdateExperience(model);

            return await Task.FromResult(true);
        }

        public async Task DeleteExperience(int id)
        {
            await _experienceRepository.DeleteExperience(id);
        }
    }
}
