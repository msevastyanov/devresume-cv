using DevResume.Domain.Entities;
using DevResume.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevResume.Infrastructure.Repositories
{
    public class EducationRepository : IEducationRepository
    {
        private readonly DataContext _db;

        public EducationRepository(DataContext db)
        {
            _db = db;
        }

        public async Task<List<Education>> GetEducations(int resumeId)
        {
            using var db = new DataContext();

            return await db.Education.Include(x => x.Resume).Where(x => x.Resume.Id == resumeId && !x.IsRemoved).OrderBy(x => x.YearFrom).ToListAsync();
        }

        public async Task<Education> FindEducation(int educationId)
        {
            return await _db.Education.SingleOrDefaultAsync(x => x.Id == educationId);
        }

        public async Task<bool> CheckEducationExist(string username, int educationId)
        {
            return await _db.Education.Include(x => x.Resume).ThenInclude(x => x.User).AnyAsync(x => x.Resume.User.UserName == username && x.Id == educationId);
        }

        public async Task AddEducation(Education education)
        {
            education.CreatedDate = DateTime.Now;
            education.ChangedDate = DateTime.Now;

            await _db.Education.AddAsync(education);

            await _db.SaveChangesAsync();
        }

        public async Task UpdateEducation(Education education)
        {
            education.ChangedDate = DateTime.Now;

            _db.Update(education);

            await _db.SaveChangesAsync();
        }

        public async Task DeleteEducation(int educationId)
        {
            var education = await _db.Education.SingleOrDefaultAsync(x => x.Id == educationId);

            if (education != null)
                education.IsRemoved = true;

            await _db.SaveChangesAsync();
        }
    }
}