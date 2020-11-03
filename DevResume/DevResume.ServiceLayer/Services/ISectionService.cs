using DevResume.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DevResume.ServiceLayer.Services
{
    public interface ISectionService
    {
        Task<List<Section>> GetSections(int resumeId);
        Task<bool> UpdateSection(Section model);
    }
}
