using DevResume.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DevResume.Infrastructure.Repositories
{
    public interface ISkillRepository
    {
        Task<List<Skill>> GetSkills(int resumeId);
        Task<Skill> FindSkill(int skillId);
        Task<bool> CheckSkillExist(string username, int skillId);
        Task AddSkill(Skill skill);
        Task UpdateSkill(Skill skill);
        Task DeleteSkill(int skillId);
    }
}
