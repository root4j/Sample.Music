using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sample.Music.Model.Entities;
using Sample.Music.Model.Interfaces;

namespace Sample.Music.View.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlbumController : ControllerBase
    {
        private readonly IAlbumBusiness _Business;

        public AlbumController(IAlbumBusiness business)
        {
            _Business = business;
        }

        // GET: api/Album
        [HttpGet]
        public ActionResult<IEnumerable<Album>> Get()
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

        // GET: api/Album/1
        [HttpGet("{id}")]
        public ActionResult<IEnumerable<Album>> GetById(int id)
        {
            try
            {
                return _Business.ReadByPredicate(x => x.AlbumId == id).OrderBy(x => x.Title).ToList();
            }
            catch (Exception ex)
            {
                Model.Loggers.AppLogger.Error(ex.Message, ex);
                throw;
            }
        }

        // PUT: api/Album/1
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Album entity)
        {
            try
            {
                if (id != entity.AlbumId)
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

        // POST: api/Album
        [HttpPost]
        public ActionResult Post([FromBody] Album entity)
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

        // DELETE: api/Album/1
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