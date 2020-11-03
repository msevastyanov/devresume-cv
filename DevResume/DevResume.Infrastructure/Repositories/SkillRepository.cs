using DevResume.Domain.Entities;
using DevResume.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevResume.Infrastructure.Repositories
{
    public class SkillRepository : ISkillRepository
    {
        private readonly DataContext _db;

        public SkillRepository(DataContext db)
        {
            _db = db;
        }

        public async Task<List<Skill>> GetSkills(int resumeId)
        {
            using var db = new DataContext();

            return await db.Skill.Include(x => x.Resume).Where(x => x.Resume.Id == resumeId && !x.IsRemoved).OrderByDescending(x => x.Level).ThenBy(x => x.Type).ToListAsync();
        }

        public async Task<Skill> FindSkill(int skillId)
        {
            return await _db.Skill.SingleOrDefaultAsync(x => x.Id == skillId);
        }

        public async Task<bool> CheckSkillExist(string username, int skillId)
        {
            return await _db.Skill.Include(x => x.Resume).ThenInclude(x => x.User).AnyAsync(x => x.Resume.User.UserName == username && x.Id == skillId);
        }

        public async Task AddSkill(Skill skill)
        {
            skill.CreatedDate = DateTime.Now;
            skill.ChangedDate = DateTime.Now;

            await _db.Skill.AddAsync(skill);

            await _db.SaveChangesAsync();
        }

        public async Task UpdateSkill(Skill skill)
        {
            skill.ChangedDate = DateTime.Now;

            _db.Update(skill);

            await _db.SaveChangesAsync();
        }

        public async Task DeleteSkill(int skillId)
        {
            var skill = await _db.Skill.SingleOrDefaultAsync(x => x.Id == skillId);

            if (skill != null)
                skill.IsRemoved = true;

            await _db.SaveChangesAsync();
        }
    }
}
