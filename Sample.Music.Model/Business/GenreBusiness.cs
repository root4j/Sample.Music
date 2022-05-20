using Sample.Music.Model.Common;
using Sample.Music.Model.Entities;
using Sample.Music.Model.Interfaces;

namespace Sample.Music.Model.Business
{
    public class GenreBusiness : Repository<int, Genre>, IGenreBusiness
    {
        public GenreBusiness(AppDbContext context) : base(context)
        {
        }

        protected override int GetId(Genre entity)
        {
            return entity.GenreId;
        }
    }
}