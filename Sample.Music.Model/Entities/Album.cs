using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sample.Music.Model.Entities
{
    [Table("Album")]
    public class Album : Audit
    {
        [Key]
        [Required]
        public int AlbumId { get; set; }

        [Required]
        [StringLength(150)]
        public string Title { get; set; }

        public DateTime? LaunchDate { get; set; }

        public int? ArtistaId { get; set; }

        public virtual Artist Artist { get; set; }
    }
}