using Microsoft.EntityFrameworkCore;
using Sample.Music.Model.Common;
using Sample.Music.Model.Entities;
using Sample.Music.Model.Interfaces;

namespace Sample.Music.Model.Business
{
    public class AlbumSongBusiness : Repository<int, AlbumSong>, IAlbumSongBusiness
    {
        private readonly AppDbContext _Context;

        public AlbumSongBusiness(AppDbContext context) : base(context)
        {
            _Context = context;
        }

        protected override int GetId(AlbumSong entity)
        {
            return entity.AlbumSongId;
        }

        protected override IQueryable<AlbumSong> GetQuery()
        {
            return _Context.AlbumSongs.Include(x => x.Album).ThenInclude(x => x.Artist).Include(x => x.Song);
        }
    }
}