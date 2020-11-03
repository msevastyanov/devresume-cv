using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DevResume.Domain.Entities
{
    public class Education : BaseEntity
    {
        [Required]
        public string University { get; set; }
        [Required]
        public string Degree { get; set; }
        public string Program { get; set; }
        [Required]
        public int YearFrom { get; set; }
        [Required]
        public int YearTo { get; set; }
        public Resume Resume { get; set; }
        [NotMapped]
        public bool NotFinished { get; set; }
        [NotMapped]
        public string AdaptYearTo => YearTo != 0 ? YearTo.ToString() : "present";
    }
}