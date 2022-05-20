using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sample.Music.Model.Entities;
using Sample.Music.Model.Interfaces;

namespace Sample.Music.View.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistController : ControllerBase
    {
        private readonly IArtistBusiness _Business;

        public ArtistController(IArtistBusiness business)
        {
            _Business = business;
        }

        // GET: api/Artist
        [HttpGet]
        public ActionResult<IEnumerable<Artist>> Get()
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

        // GET: api/Artist/1
        [HttpGet("{id}")]
        public ActionResult<IEnumerable<Artist>> GetById(int id)
        {
            try
            {
                return _Business.ReadByPredicate(x => x.ArtistId == id).OrderBy(x => x.Name).ToList();
            }
            catch (Exception ex)
            {
                Model.Loggers.AppLogger.Error(ex.Message, ex);
                throw;
            }
        }

        // PUT: api/Artist/1
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Artist entity)
        {
            try
            {
                if (id != entity.ArtistId)
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

        // POST: api/Artist
        [HttpPost]
        public ActionResult Post([FromBody] Artist entity)
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

        // DELETE: api/Artist/1
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