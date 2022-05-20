using Microsoft.EntityFrameworkCore;
using Sample.Music.Model.Entities;

namespace Sample.Music.Model
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        #region DbSets
        public virtual DbSet<Artist> Artists { get; set; }
        public virtual DbSet<Genre> Genres { get; set; }
        public virtual DbSet<Album> Albumes { get; set; }
        public virtual DbSet<Song> Songs { get; set; }
        public virtual DbSet<AlbumSong> AlbumSongs { get; set; }
        public virtual DbSet<AlbumGenre> AlbumGenres { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Foreign Keys
            modelBuilder.Entity<Album>()
                        .HasOne(e => e.Artist)
                        .WithMany()
                        .HasForeignKey(e => e.ArtistaId);

            modelBuilder.Entity<AlbumSong>()
                        .HasOne(e => e.Album)
                        .WithMany()
                        .HasForeignKey(e => e.AlbumId);

            modelBuilder.Entity<AlbumSong>()
                        .HasOne(e => e.Song)
                        .WithMany()
                        .HasForeignKey(e => e.SongId);

            modelBuilder.Entity<AlbumGenre>()
                        .HasOne(e => e.Album)
                        .WithMany()
                        .HasForeignKey(e => e.AlbumId);

            modelBuilder.Entity<AlbumGenre>()
                        .HasOne(e => e.Genre)
                        .WithMany()
                        .HasForeignKey(e => e.GenreId);
            #endregion
        }
    }
}