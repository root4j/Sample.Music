using Microsoft.EntityFrameworkCore;
using Sample.Music.Model.Common;
using Sample.Music.Model.Entities;
using Sample.Music.Model.Interfaces;

namespace Sample.Music.Model.Business
{
    public class AlbumBusiness : Repository<int, Album>, IAlbumBusiness
    {
        private readonly AppDbContext _Context;

        public AlbumBusiness(AppDbContext context) : base(context)
        {
            _Context = context;
        }

        protected override int GetId(Album entity)
        {
            return entity.AlbumId;
        }

        protected override IQueryable<Album> GetQuery()
        {
            return _Context.Albumes.Include(x => x.Artist);
        }
    }
}