using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sample.Music.Model.Entities
{
    [Table("Genre")]
    public class Genre : Audit
    {
        [Key]
        [Required]
        public int GenreId { get; set; }

        [Required]
        [StringLength(150)]
        public string Name { get; set; }
    }
}