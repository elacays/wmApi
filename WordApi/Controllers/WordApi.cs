using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WordApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WordApiController : ControllerBase
    {
        WordDbContext _context;
        public WordApiController(WordDbContext context)
        {
            _context=context;
        }
        // GET: api/<WordApi>
        [HttpGet]
        public IEnumerable<WordDefinition> Get()
        {
            return _context.WordDefinitions.Include(c=>c.Meanings).ToList();
        }

        // GET api/<WordApi>/5
        [HttpGet("{id}")]
        public WordDefinition Get(int id)
        {
            return _context.WordDefinitions.Include(c => c.Meanings).First(c=>c.Id==id);
        }

        // POST api/<WordApi>
        [HttpPost]
        public void Post([FromBody] WordDefinition entity)
        {
            _context.WordDefinitions.Add(entity);
            _context.SaveChanges();
        }

        // PUT api/<WordApi>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] WordDefinition entity)
        {
            entity.Id = id;
            _context.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;

            foreach(var meaning in entity.Meanings)
            {
                
                if (meaning.Id > 0)
                {
                    _context.Attach(meaning);
                    _context.Entry(meaning).State = EntityState.Modified;
                }
                else
                {
                    meaning.WordDefinitionId = entity.Id;
                    _context.WordMeanings.Add(meaning);
                }
            }


            _context.SaveChanges();
            
        }

        // DELETE api/<WordApi>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var deleted = _context.WordDefinitions.First(c => c.Id == id);
            _context.Remove(deleted);
            _context.SaveChanges();
        }

        [HttpDelete("meaning/{id}")]
        public void DeleteMeaning(int id)
        {
            var deleted = _context.WordMeanings.First(c => c.Id == id);
            _context.Remove(deleted);
            _context.SaveChanges();
        }
    }
}
