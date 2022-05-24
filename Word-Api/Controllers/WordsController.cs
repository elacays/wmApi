using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Word_Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class WordsController : ControllerBase
    {
        WordDbContext _ctx;
        public WordsController(WordDbContext context)
        {
            _ctx = context;
        }
        // GET: api/<LangsController>
        [HttpGet]
        public IEnumerable<Word> Get()
        {
            return _ctx.Words.ToList();
        }

        // GET api/<LangsController>/5
        [HttpGet("{id}")]
        public Word Get(int id)
        {
            return _ctx.Words.FirstOrDefault(c => c.Id == id);
        }

        // POST api/<LangsController>
        [HttpPost]
        public void Post([FromBody] Word word)
        {
            _ctx.Words.Add(word);
            _ctx.SaveChanges();

        }

        // PUT api/<LangsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Word word)
        {
            word.Id = id;
            _ctx.Attach(word);
            _ctx.Entry(word).State = EntityState.Modified;
            _ctx.SaveChanges();

        }

        // DELETE api/<LangsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var silinecek = _ctx.Words.FirstOrDefault(c => c.Id == id);
            _ctx.Remove(silinecek);
            _ctx.SaveChanges();
        }
    }
}
