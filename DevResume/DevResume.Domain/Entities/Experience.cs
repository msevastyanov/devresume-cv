using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DevResume.Domain.Entities
{
    public class Experience : BaseEntity
    {
        [Required]
        public string Company { get; set; }
        public string Website { get; set; }
        [Required]
        public int YearFrom { get; set; }
        [Required]
        public int YearTo { get; set; }
        [Required]
        public string Position { get; set; }
        public string Languages { get; set; }
        public string Technologies { get; set; }
        public string Area { get; set; }
        public string Logo { get; set; }
        public Resume Resume { get; set; }
        [NotMapped]
        public bool NotFinished { get; set; }
        [NotMapped]
        public string AdaptYearTo => YearTo != 0 ? YearTo.ToString() : "present";
    }
}