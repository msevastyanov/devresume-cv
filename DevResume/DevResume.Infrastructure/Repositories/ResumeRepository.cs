using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using DevResume.Domain.Entities;
using DevResume.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace DevResume.Infrastructure.Repositories
{
    public class ResumeRepository : IResumeRepository
    {
        private readonly DataContext _db;

        public ResumeRepository(DataContext db)
        {
            _db = db;
        }

        public async Task<List<Resume>> GetUserResumes(string userId)
        {
            using var db = new DataContext();

            return await db.Resume.Include(x => x.Theme).Include(x => x.User)
                .Where(x => x.User.Id == userId && !x.IsRemoved).ToListAsync();
        }

        public async Task<Resume> FindResume(int resumeId)
        {
            return await _db.Resume.SingleOrDefaultAsync(x => x.Id == resumeId);
        }

        public async Task<Resume> FindResume(int resumeId, string userName)
        {
            return await _db.Resume.Include(x => x.User).SingleOrDefaultAsync(x => x.Id == resumeId && x.User.UserName == userName && !x.IsRemoved);
        }

        public async Task<Resume> FindResume(string resumeKey)
        {
            return await _db.Resume.Include(x => x.Sections).SingleOrDefaultAsync(x => x.Key == resumeKey);
        }

        public async Task<bool> CheckResumeExist(string username, int resumeId)
        {
            return await _db.Resume.Include(x => x.User).AnyAsync(x => x.User.UserName == username && x.Id == resumeId);
        }

        public async Task<Resume> AddResume(Resume resume)
        {
            resume.CreatedDate = DateTime.Now;
            resume.ChangedDate = DateTime.Now;

            await _db.Resume.AddAsync(resume);

            await _db.SaveChangesAsync();

            return await Task.FromResult(resume);
        }

        public async Task<Resume> UpdateResume(Resume resume)
        {
            resume.ChangedDate = DateTime.Now;

            _db.Update(resume);

            await _db.SaveChangesAsync();

            return await Task.FromResult(resume);
        }

        public async Task DeleteResume(int resumeId)
        {
            var resume = await _db.Resume.SingleOrDefaultAsync(x => x.Id == resumeId);

            if (resume != null)
                resume.IsRemoved = true;

            await _db.SaveChangesAsync();
        }
    }
}