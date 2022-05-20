using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sample.Music.Model.Entities;
using Sample.Music.Model.Interfaces;

namespace Sample.Music.View.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private readonly IGenreBusiness _Business;

        public GenreController(IGenreBusiness business)
        {
            _Business = business;
        }

        // GET: api/Genre
        [HttpGet]
        public ActionResult<IEnumerable<Genre>> Get()
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

        // GET: api/Genre/1
        [HttpGet("{id}")]
        public ActionResult<IEnumerable<Genre>> GetById(int id)
        {
            try
            {
                return _Business.ReadByPredicate(x => x.GenreId == id).OrderBy(x => x.Name).ToList();
            }
            catch (Exception ex)
            {
                Model.Loggers.AppLogger.Error(ex.Message, ex);
                throw;
            }
        }

        // PUT: api/Genre/1
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Genre entity)
        {
            try
            {
                if (id != entity.GenreId)
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

        // POST: api/Genre
        [HttpPost]
        public ActionResult Post([FromBody] Genre entity)
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

        // DELETE: api/Genre/1
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