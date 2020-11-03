using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevResume.Domain.Entities;
using DevResume.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace DevResume.Infrastructure.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly DataContext _db;

        public ProjectRepository(DataContext db)
        {
            _db = db;
        }

        public async Task<List<Project>> GetProjects(int resumeId)
        {
            return await _db.Project.Include(x => x.Images).Include(x => x.Resume)
                .Where(x => x.Resume.Id == resumeId && !x.IsRemoved).ToListAsync();
        }

        public async Task<Project> FindProject(int projectId)
        {
            return await _db.Project.SingleOrDefaultAsync(x => x.Id == projectId);
        }

        public async Task<bool> CheckProjectExist(string username, int projectId)
        {
            return await _db.Project.Include(x => x.Resume).ThenInclude(x => x.User).AnyAsync(x => x.Resume.User.UserName == username && x.Id == projectId);
        }

        public async Task AddProject(Project project)
        {
            project.CreatedDate = DateTime.Now;
            project.ChangedDate = DateTime.Now;

            await _db.Project.AddAsync(project);

            await _db.SaveChangesAsync();
        }

        public async Task UpdateProject(Project project)
        {
            project.ChangedDate = DateTime.Now;

            _db.Update(project);

            await _db.SaveChangesAsync();
        }

        public async Task DeleteProject(int projectId)
        {
            var project = await _db.Project.SingleOrDefaultAsync(x => x.Id == projectId);

            if (project != null)
                project.IsRemoved = true;

            await _db.SaveChangesAsync();
        }
    }
}