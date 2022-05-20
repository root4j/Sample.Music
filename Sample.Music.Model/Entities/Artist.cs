using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sample.Music.Model.Entities
{
    [Table("Artist")]
    public class Artist : Audit
    {
        [Key]
        [Required]
        public int ArtistId { get; set; }

        [Required]
        [StringLength(150)]
        public string Name { get; set; }
    }
}