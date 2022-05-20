using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sample.Music.Model.Entities;
using Sample.Music.Model.Interfaces;

namespace Sample.Music.View.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlbumGenreController : ControllerBase
    {
        private readonly IAlbumGenreBusiness _Business;

        public AlbumGenreController(IAlbumGenreBusiness business)
        {
            _Business = business;
        }

        // GET: api/AlbumGenre
        [HttpGet]
        public ActionResult<IEnumerable<AlbumGenre>> Get()
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

        // GET: api/AlbumGenre/1
        [HttpGet("{id}")]
        public ActionResult<IEnumerable<AlbumGenre>> GetById(int id)
        {
            try
            {
                return _Business.ReadByPredicate(x => x.AlbumGenreId == id).OrderBy(x => x.AlbumGenreId).ToList();
            }
            catch (Exception ex)
            {
                Model.Loggers.AppLogger.Error(ex.Message, ex);
                throw;
            }
        }

        // PUT: api/AlbumGenre/1
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] AlbumGenre entity)
        {
            try
            {
                if (id != entity.AlbumGenreId)
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

        // POST: api/AlbumGenre
        [HttpPost]
        public ActionResult Post([FromBody] AlbumGenre entity)
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

        // DELETE: api/AlbumGenre/1
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