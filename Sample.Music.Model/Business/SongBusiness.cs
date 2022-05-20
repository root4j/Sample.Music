using Sample.Music.Model.Common;
using Sample.Music.Model.Entities;
using Sample.Music.Model.Interfaces;

namespace Sample.Music.Model.Business
{
    public class SongBusiness : Repository<int, Song>, ISongBusiness
    {
        public SongBusiness(AppDbContext context) : base(context)
        {
        }

        protected override int GetId(Song entity)
        {
            return entity.SongId;
        }
    }
}