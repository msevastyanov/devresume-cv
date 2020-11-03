using DevResume.Domain.Entities;
using DevResume.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DevResume.ServiceLayer.Services
{
    public class SectionService : ISectionService
    {
        private readonly IResumeRepository _resumeRepository;
        private readonly ISectionRepository _sectionRepository;

        public SectionService(ISectionRepository sectionRepository, IResumeRepository resumeRepository)
        {
            _resumeRepository = resumeRepository;
            _sectionRepository = sectionRepository;
        }

        public async Task<List<Section>> GetSections(int resumeId)
        {
            var sections = await _sectionRepository.GetSections(resumeId);

            return await Task.FromResult(sections);
        }

        public async Task<bool> UpdateSection(Section model)
        {
            await _sectionRepository.UpdateSection(model);

            return await Task.FromResult(true);
        }
    }
}
