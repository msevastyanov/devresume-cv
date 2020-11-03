using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DevResume.Domain.Entities
{
    public class Project : BaseEntity
    {
        [Required]
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public string Description { get; set; }
        public string Cover { get; set; }
        public int Year { get; set; }
        public string Website { get; set; }
        public string AppStore { get; set; }
        public string PlayStore { get; set; }
        public string Source { get; set; }
        public string Technologies { get; set; }
        public string Languages { get; set; }
        public bool IsWebApp { get; set; }
        public bool IsMobileApp { get; set; }
        public bool IsDesktopApp { get; set; }
        public bool IsLibrary { get; set; }
        public List<ProjectImage> Images { get; set; }
        public Resume Resume { get; set; }
    }
}