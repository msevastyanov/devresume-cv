using DevResume.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DevResume.Infrastructure.Repositories
{
    public interface ISectionRepository
    {
        Task<List<Section>> GetSections(int resumeId);
        Task<Section> FindSection(int sectionId);
        Task AddSections(List<Section> sections);
        Task UpdateSection(Section section);
        Task DeleteSections(int resumeId);
    }
}
