using System.ComponentModel.DataAnnotations;

namespace Sample.Music.Model.Entities
{
    public class Audit : IAudit
    {
        [Required]
        public DateTime CreateDate { get; set; }

        [Required]
        [StringLength(50)]
        public string CreatedBy { get; set; }

        [Required]
        public DateTime ModifyDate { get; set; }

        [Required]
        [StringLength(50)]
        public string ModifiedBy { get; set; }
    }
}