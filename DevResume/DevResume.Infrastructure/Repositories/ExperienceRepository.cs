using DevResume.Domain.Entities;
using DevResume.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevResume.Infrastructure.Repositories
{
    public class ExperienceRepository : IExperienceRepository
    {
        private readonly DataContext _db;

        public ExperienceRepository(DataContext db)
        {
            _db = db;
        }

        public async Task<List<Experience>> GetExperience(int resumeId)
        {
            using var db = new DataContext();

            return await db.Experience.Include(x => x.Resume).Where(x => x.Resume.Id == resumeId && !x.IsRemoved).OrderByDescending(x => x.YearFrom).ToListAsync();
        }

        public async Task<Experience> FindExperience(int experienceId)
        {
            return await _db.Experience.SingleOrDefaultAsync(x => x.Id == experienceId);
        }

        public async Task<bool> CheckExperienceExist(string username, int experienceId)
        {
            return await _db.Experience.Include(x => x.Resume).ThenInclude(x => x.User).AnyAsync(x => x.Resume.User.UserName == username && x.Id == experienceId);
        }

        public async Task AddExperience(Experience experience)
        {
            experience.CreatedDate = DateTime.Now;
            experience.ChangedDate = DateTime.Now;

            await _db.Experience.AddAsync(experience);

            await _db.SaveChangesAsync();
        }

        public async Task UpdateExperience(Experience experience)
        {
            experience.ChangedDate = DateTime.Now;

            _db.Update(experience);

            await _db.SaveChangesAsync();
        }

        public async Task DeleteExperience(int experienceId)
        {
            var experience = await _db.Experience.SingleOrDefaultAsync(x => x.Id == experienceId);

            if (experience != null)
                experience.IsRemoved = true;

            await _db.SaveChangesAsync();
        }
    }
}