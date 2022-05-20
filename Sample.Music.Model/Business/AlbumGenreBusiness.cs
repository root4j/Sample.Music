using Microsoft.EntityFrameworkCore;
using Sample.Music.Model.Common;
using Sample.Music.Model.Entities;
using Sample.Music.Model.Interfaces;

namespace Sample.Music.Model.Business
{
    public class AlbumGenreBusiness : Repository<int, AlbumGenre>, IAlbumGenreBusiness
    {
        private readonly AppDbContext _Context;

        public AlbumGenreBusiness(AppDbContext context) : base(context)
        {
            _Context = context;
        }

        protected override int GetId(AlbumGenre entity)
        {
            return entity.AlbumGenreId;
        }

        protected override IQueryable<AlbumGenre> GetQuery()
        {
            return _Context.AlbumGenres.Include(x => x.Album).ThenInclude(x => x.Artist).Include(x => x.Genre);
        }
    }
}