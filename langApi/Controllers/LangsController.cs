using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace langApi
{
    [Route("api/[controller]")]
    [ApiController]
    public class LangsController : ControllerBase
    {
        LangDbContext _ctx;
        public LangsController(LangDbContext context)
        {
            _ctx = context;
        }
        // GET: api/<LangsController>
        [HttpGet]
        public IEnumerable<Language> Get()
        {
            return _ctx.Languages.ToList();
        }

        // GET api/<LangsController>/5
        [HttpGet("{id}")]
        public Language Get(int id)
        {
            return _ctx.Languages.FirstOrDefault(c=>c.Id==id);
        }

        // POST api/<LangsController>
        [HttpPost]
        public void Post([FromBody] Language lng)
        {
            _ctx.Languages.Add(lng);
            _ctx.SaveChanges();

        }

        // PUT api/<LangsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Language lng)
        {
            lng.Id = id;
            _ctx.Attach(lng);
            _ctx.Entry(lng).State = EntityState.Modified;
            _ctx.SaveChanges();

        }

        // DELETE api/<LangsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var silinecek=_ctx.Languages.FirstOrDefault(c => c.Id == id);
            _ctx.Remove(silinecek);
            _ctx.SaveChanges();
        }
    }
}
