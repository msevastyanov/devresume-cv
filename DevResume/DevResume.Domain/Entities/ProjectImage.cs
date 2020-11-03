namespace DevResume.Domain.Entities
{
    public class ProjectImage : BaseEntity
    {
        public int Sort { get; set; }
        public string Path { get; set; }
        public Project Project { get; set; }
        public Resume Resume { get; set; }
    }
}