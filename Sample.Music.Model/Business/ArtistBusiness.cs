using Sample.Music.Model.Common;
using Sample.Music.Model.Entities;
using Sample.Music.Model.Interfaces;

namespace Sample.Music.Model.Business
{
    public class ArtistBusiness : Repository<int, Artist>, IArtistBusiness
    {
        public ArtistBusiness(AppDbContext context) : base(context)
        {
        }

        protected override int GetId(Artist entity)
        {
            return entity.ArtistId;
        }
    }
}