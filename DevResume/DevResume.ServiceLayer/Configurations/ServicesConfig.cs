using DevResume.ServiceLayer.Services;
using DevResume.ServiceLayer.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace DevResume.ServiceLayer.Configurations
{
    public class ServicesConfig
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IResumeService, ResumeService>();
            services.AddTransient<IProjectService, ProjectService>();
            services.AddTransient<IEducationService, EducationService>();
            services.AddTransient<IExperienceService, ExperienceService>();
            services.AddTransient<IFileService, FileService>();
            services.AddTransient<ISkillService, SkillService>();
            services.AddTransient<ISectionService, SectionService>();
            services.AddTransient<IAuthService, AuthService>();
        }
    }
}