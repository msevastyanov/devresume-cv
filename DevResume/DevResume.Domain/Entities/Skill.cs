using System.ComponentModel.DataAnnotations;

namespace DevResume.Domain.Entities
{
    public class Skill : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        public string Image { get; set; }
        public string Comment { get; set; }
        public ExperienceLevel Level { get; set; }
        public SkillType Type { get; set; }
        public Resume Resume { get; set; }
    }

    public enum ExperienceLevel : int
    {
        Low = 0, Middle = 1, High = 2
    }

    public enum SkillType
    {
        Language, Framework, DBMS, IDE, Other
    }
}