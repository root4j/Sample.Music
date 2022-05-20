using Sample.Music.Model.Common;
using Sample.Music.Model.Entities;

namespace Sample.Music.Model.Interfaces
{
    public interface ISongBusiness : IRepository<int, Song>
    {
    }
}