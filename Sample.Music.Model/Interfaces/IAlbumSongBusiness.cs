using Sample.Music.Model.Common;
using Sample.Music.Model.Entities;

namespace Sample.Music.Model.Interfaces
{
    public interface IAlbumSongBusiness : IRepository<int, AlbumSong>
    {
    }
}