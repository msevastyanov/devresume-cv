using DevResume.Domain.Entities;
using DevResume.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevResume.Infrastructure.Repositories
{
    public class SectionRepository : ISectionRepository
    {
        private readonly DataContext _db;

        public SectionRepository(DataContext db)
        {
            _db = db;
        }

        public async Task<List<Section>> GetSections(int resumeId)
        {
            using var db = new DataContext();

            return await db.Section.Include(x => x.Resume).Where(x => x.Resume.Id == resumeId).OrderBy(x => x.Sort).ToListAsync();
        }

        public async Task<Section> FindSection(int sectionId)
        {
            return await _db.Section.SingleOrDefaultAsync(x => x.Id == sectionId);
        }

        public async Task AddSections(List<Section> sections)
        {
            await _db.Section.AddRangeAsync(sections);

            await _db.SaveChangesAsync();
        }

        public async Task UpdateSection(Section section)
        {
            var existingSection = await _db.Section.SingleOrDefaultAsync(x => x.Id == section.Id);

            _db.Entry(existingSection).CurrentValues.SetValues(section);

            await _db.SaveChangesAsync();
        }

        public async Task DeleteSections(int resumeId)
        {
            var sections = _db.Section.Include(x => x.Resume).Where(x => x.Resume.Id == resumeId);

            _db.RemoveRange(sections);

            await _db.SaveChangesAsync();
        }
    }
}
