using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sample.Music.Model.Entities;
using Sample.Music.Model.Interfaces;

namespace Sample.Music.View.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SongController : ControllerBase
    {
        private readonly ISongBusiness _Business;

        public SongController(ISongBusiness business)
        {
            _Business = business;
        }

        // GET: api/Song
        [HttpGet]
        public ActionResult<IEnumerable<Song>> Get()
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

        // GET: api/Song/1
        [HttpGet("{id}")]
        public ActionResult<IEnumerable<Song>> GetById(int id)
        {
            try
            {
                return _Business.ReadByPredicate(x => x.SongId == id).OrderBy(x => x.Title).ToList();
            }
            catch (Exception ex)
            {
                Model.Loggers.AppLogger.Error(ex.Message, ex);
                throw;
            }
        }

        // PUT: api/Song/1
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Song entity)
        {
            try
            {
                if (id != entity.SongId)
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

        // POST: api/Song
        [HttpPost]
        public ActionResult Post([FromBody] Song entity)
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

        // DELETE: api/Song/1
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