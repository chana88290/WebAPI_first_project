using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService _usersService;

        //In C#, parameters are camelCase: usersService
        public UsersController(IUsersService UsersService)
        {
            _usersService = UsersService;
        }

        // GET: api/<UsersController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<UsersController>
        [HttpPost]
        public IActionResult Post([FromBody] Userreg user)
        {
            user = _usersService.AddUser(user);
            return CreatedAtAction(nameof(Get), new { id = user.id }, user);
        }

        [HttpPost("login")]
        public IActionResult Post([FromBody] Userlog user)
        {
            //Why does the null check test user and not user_1, the result of GetUser? What should login return when no user matches?
            var user_1 = _usersService.GetUser(user);
            if (user == null)
                return NotFound();
            return Ok(user);
        }


        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        //The assignment asks PUT to return Ok(): change void to IActionResult and return Ok() at the end
        public void Put(int id, [FromBody] Userreg user_1)
        {
            _usersService.UpdateUser(id, user_1);
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
