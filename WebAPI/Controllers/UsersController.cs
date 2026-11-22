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

        //The assignment asks the users controller to check the password too, and registration and update must reject a weak password (score below 3): which interface should this constructor take, and where is the check called?
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
        //Why isn't this implemented? It should read the users file and give back the user with this id
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
            var user_1 = _usersService.GetUser(user);
            //user is the request body, never null: this check doesn't find a wrong login. Check the search result (user_1) instead
            if (user == null)
                return NotFound();
            //Is this the stored user, with its id? Send user_1 instead of the request
            return Ok(user);
        }


        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        //The assignment asks PUT to return Ok(): change void to IActionResult and return Ok() at the end
        //Where is the weak password (score below 3) checked on update? The assignment asks for 400 here
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
