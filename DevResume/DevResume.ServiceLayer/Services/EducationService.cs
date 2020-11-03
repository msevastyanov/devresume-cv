using DevResume.Domain.Entities;
using DevResume.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DevResume.ServiceLayer.Services
{
    public class EducationService : IEducationService
    {
        private readonly IResumeRepository _resumeRepository;
        private readonly IEducationRepository _educationRepository;

        public EducationService(IEducationRepository educationRepository, IResumeRepository resumeRepository)
        {
            _resumeRepository = resumeRepository;
            _educationRepository = educationRepository;
        }

        public async Task<List<Education>> GetEducations(int resumeId)
        {
            var educations = await _educationRepository.GetEducations(resumeId);

            return await Task.FromResult(educations);
        }

        public async Task<Education> GetEducation(int id)
        {
            var education = await _educationRepository.FindEducation(id);

            return await Task.FromResult(education);
        }

        public async Task AddEducation(Education model, int resumeId)
        {
            var resume = await _resumeRepository.FindResume(resumeId);

            model.Resume = resume;

            if (model.NotFinished)
                model.YearTo = 0;

            await _educationRepository.AddEducation(model);
        }

        public async Task<bool> UpdateEducation(Education model)
        {
            if (model.NotFinished)
                model.YearTo = 0;

            await _educationRepository.UpdateEducation(model);

            return await Task.FromResult(true);
        }

        public async Task DeleteEducation(int id)
        {
            await _educationRepository.DeleteEducation(id);
        }
    }
}
