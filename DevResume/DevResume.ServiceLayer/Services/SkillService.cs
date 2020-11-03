using DevResume.Domain.Entities;
using DevResume.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DevResume.ServiceLayer.Services
{
    public class SkillService : ISkillService
    {
        private readonly IResumeRepository _resumeRepository;
        private readonly ISkillRepository _skillRepository;

        public SkillService(ISkillRepository skillRepository, IResumeRepository resumeRepository)
        {
            _resumeRepository = resumeRepository;
            _skillRepository = skillRepository;
        }

        public async Task<List<Skill>> GetSkills(int resumeId)
        {
            var skills = await _skillRepository.GetSkills(resumeId);

            return await Task.FromResult(skills);
        }

        public async Task<Skill> GetSkill(int id)
        {
            var skill = await _skillRepository.FindSkill(id);

            return await Task.FromResult(skill);
        }

        public async Task AddSkill(Skill model, int resumeId)
        {
            var resume = await _resumeRepository.FindResume(resumeId);

            model.Resume = resume;

            await _skillRepository.AddSkill(model);
        }

        public async Task<bool> UpdateSkill(Skill model)
        {
            await _skillRepository.UpdateSkill(model);

            return await Task.FromResult(true);
        }

        public async Task DeleteSkill(int id)
        {
            await _skillRepository.DeleteSkill(id);
        }
    }
}
