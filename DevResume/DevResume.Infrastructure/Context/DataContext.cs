using DevResume.Domain.Entities;
using DevResume.Infrastructure.Configuration;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DevResume.Infrastructure.Context
{
    public class DataContext : IdentityDbContext<ApplicationUser>
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {

        }

        public DataContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(DbConfig.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Project>()
                .Property(e => e.Id)
                .ValueGeneratedOnAdd();

            builder.Entity<ProjectImage>()
                .Property(e => e.Id)
                .ValueGeneratedOnAdd();

            builder.Entity<Skill>()
                .Property(e => e.Id)
                .ValueGeneratedOnAdd();

            builder.Entity<Education>()
                .Property(e => e.Id)
                .ValueGeneratedOnAdd();

            builder.Entity<Experience>()
                .Property(e => e.Id)
                .ValueGeneratedOnAdd();

            builder.Entity<Resume>()
                .Property(e => e.Id)
                .ValueGeneratedOnAdd();

            builder.Entity<Section>()
                .Property(e => e.Id)
                .ValueGeneratedOnAdd();

            builder.Entity<Theme>()
                .Property(e => e.Id)
                .ValueGeneratedOnAdd();
        }

        public DbSet<Project> Project { get; set; }
        public DbSet<ProjectImage> ProjectImage { get; set; }
        public DbSet<Skill> Skill { get; set; }
        public DbSet<Education> Education { get; set; }
        public DbSet<Experience> Experience { get; set; }
        public DbSet<Resume> Resume { get; set; }
        public DbSet<Section> Section { get; set; }
        public DbSet<Theme> Theme { get; set; }
    }
}