using DevResume.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace DevResume.Infrastructure.Configuration
{
    public class RepositoriesConfig
    {
        public static void ConfigureRepositories(IServiceCollection services)
        {
            services.AddTransient<IResumeRepository, ResumeRepository>();
            services.AddTransient<IProjectRepository, ProjectRepository>();
            services.AddTransient<IEducationRepository, EducationRepository>();
            services.AddTransient<IExperienceRepository, ExperienceRepository>();
            services.AddTransient<ISkillRepository, SkillRepository>();
            services.AddTransient<ISectionRepository, SectionRepository>();
        }
    }
}