using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UserApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        UserDbContext _ctx;
        public UserController(UserDbContext context)
        {
            _ctx = context;
        }
        // GET: api/<UserController>
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return _ctx.Users.ToList();
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public User Get(int id)
        {
            return _ctx.Users.FirstOrDefault(c => c.Id == id);
        }

        // POST api/<UserController>
        [HttpPost]
        public void Post([FromBody] User usr)
        {
            _ctx.Users.Add(usr);
            _ctx.SaveChanges();
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] User usr)
        {
            usr.Id = id;
            _ctx.Attach(usr);
            _ctx.Entry(usr).State = EntityState.Modified;
            _ctx.SaveChanges();
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var silinecek = _ctx.Users.FirstOrDefault(c => c.Id == id);
            _ctx.Remove(silinecek);
            _ctx.SaveChanges();
        }
    }
}

