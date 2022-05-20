using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sample.Music.Model.Entities;
using Sample.Music.Model.Interfaces;

namespace Sample.Music.View.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlbumSongController : ControllerBase
    {
        private readonly IAlbumSongBusiness _Business;

        public AlbumSongController(IAlbumSongBusiness business)
        {
            _Business = business;
        }

        // GET: api/AlbumSong
        [HttpGet]
        public ActionResult<IEnumerable<AlbumSong>> Get()
        {
            try
            {
                return _Business.ReadAll();
            }
            catch (Exception ex)
            {
                Model.Loggers.AppLogger.Error(ex.Message, ex);
                throw;
            }
        }

        // GET: api/AlbumSong/1
        [HttpGet("{id}")]
        public ActionResult<IEnumerable<AlbumSong>> GetById(int id)
        {
            try
            {
                return _Business.ReadByPredicate(x => x.AlbumSongId == id).OrderBy(x => x.AlbumSongId).ToList();
            }
            catch (Exception ex)
            {
                Model.Loggers.AppLogger.Error(ex.Message, ex);
                throw;
            }
        }

        // PUT: api/AlbumSong/1
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] AlbumSong entity)
        {
            try
            {
                if (id != entity.AlbumSongId)
                {
                    return BadRequest();
                }
                _Business.Update(id, entity);
                return Ok(entity);
            }
            catch (Exception ex)
            {
                Model.Loggers.AppLogger.Error(ex.Message, ex);
                throw;
            }
        }

        // POST: api/AlbumSong
        [HttpPost]
        public ActionResult Post([FromBody] AlbumSong entity)
        {
            try
            {
                _Business.Create(entity);
                return Ok(entity);
            }
            catch (Exception ex)
            {
                Model.Loggers.AppLogger.Error(ex.Message, ex);
                throw;
            }
        }

        // DELETE: api/AlbumSong/1
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _Business.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                Model.Loggers.AppLogger.Error(ex.Message, ex);
                throw;
            }
        }
    }
}