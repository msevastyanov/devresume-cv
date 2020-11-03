namespace DevResume.Domain.Entities
{
    public class Section
    {
        public int Id { get; set; }
        public int Sort { get; set; }
        public bool IsActive { get; set; }
        public SectionType Type { get; set; }
        public Resume Resume { get; set; }
    }

    public enum SectionType : int
    {
        Main = 0, Info = 1, Projects = 2, Skills = 3, Experience = 4, Education = 5
    }
}