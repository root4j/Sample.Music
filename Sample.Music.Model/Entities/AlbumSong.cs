using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sample.Music.Model.Entities
{
    [Table("AlbumSong")]
    public class AlbumSong : Audit
    {
        [Key]
        [Required]
        public int AlbumSongId { get; set; }

        public int AlbumId { get; set; }

        public int SongId { get; set; }

        public virtual Album Album { get; set; }

        public virtual Song Song { get; set; }
    }
}