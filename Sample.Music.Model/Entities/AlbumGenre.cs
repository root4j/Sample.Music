using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sample.Music.Model.Entities
{
    [Table("AlbumGenre")]
    public class AlbumGenre : Audit
    {
        [Key]
        [Required]
        public int AlbumGenreId { get; set; }

        public int AlbumId { get; set; }

        public int GenreId { get; set; }

        public virtual Album Album { get; set; }

        public virtual Genre Genre { get; set; }
    }
}