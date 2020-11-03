using DevResume.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DevResume.ServiceLayer.Services
{
    public interface ISkillService
    {
        Task<List<Skill>> GetSkills(int resumeId);
        Task<Skill> GetSkill(int id);
        Task AddSkill(Skill model, int resumeId);
        Task<bool> UpdateSkill(Skill model);
        Task DeleteSkill(int id);
    }
}
