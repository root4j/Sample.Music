using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sample.Music.Model.Entities
{
    [Table("Song")]
    public class Song : Audit
    {
        [Key]
        [Required]
        public int SongId { get; set; }

        [Required]
        [StringLength(150)]
        public string Title { get; set; }
    }
}