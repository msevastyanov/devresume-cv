using System.Collections.Generic;
using System.Threading.Tasks;
using DevResume.Domain.Entities;
using DevResume.Infrastructure.Repositories;
using Microsoft.AspNetCore.Identity;

namespace DevResume.ServiceLayer.Services
{
    public class ResumeService : IResumeService
    {
        private readonly IResumeRepository _resumeRepository;
        private readonly ISectionRepository _sectionRepository;
        private readonly UserManager<ApplicationUser> _userManager;

        public ResumeService(IResumeRepository resumeRepository, ISectionRepository sectionRepository, UserManager<ApplicationUser> userManager)
        {
            _resumeRepository = resumeRepository;
            _sectionRepository = sectionRepository;
            _userManager = userManager;
        }

        public async Task<List<Resume>> GetResumesAsync(string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);

            var resumes = await _resumeRepository.GetUserResumes(user?.Id);

            return await Task.FromResult(resumes);
        }

        public async Task<Resume> GetResume(int resumeId)
        {
            var resume = await _resumeRepository.FindResume(resumeId);

            return await Task.FromResult(resume);
        }

        public async Task<Resume> GetResume(string resumeKey)
        {
            var resume = await _resumeRepository.FindResume(resumeKey);

            return await Task.FromResult(resume);
        }

        public async Task<Resume> AddResume(Resume model, string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);

            model.User = user;

            var resume = await _resumeRepository.AddResume(model);

            var sections = new List<Section>();

            for (var i = 0; i < 6; i++)
            {
                sections.Add(new Section
                {
                    Sort = i + 1,
                    IsActive = true,
                    Type = (SectionType)i,
                    Resume = resume
                });
            }

            await _sectionRepository.AddSections(sections);

            return await Task.FromResult(resume);
        }

        public async Task<bool> UpdateResume(Resume model)
        {
            var resume = await _resumeRepository.UpdateResume(model);

            return await Task.FromResult(true);
        }
    }
}