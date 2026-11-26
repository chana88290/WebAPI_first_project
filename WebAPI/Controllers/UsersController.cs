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
        private readonly IStrongPassword _strongPassword;

        public UsersController(IUsersService usersService, IStrongPassword strongPassword)
        {
            _usersService = usersService;
            _strongPassword = strongPassword;
        }

        // GET: api/<UsersController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Userreg>> Get(int id)
        {
            Userreg user = await _usersService.GetAsync(id);
            if(user != null)
                return Ok(user);
            return NotFound();
        }

        // POST api/<UsersController>
        [HttpPost]
        public async Task<ActionResult<Userreg>> Post([FromBody] Userreg user)
        {
            if (_strongPassword.GetStrongPassword(user.password) < 3)
            {
                return BadRequest("Password too weak");
            }
            user = await _usersService.PostAsync(user);
            return CreatedAtAction(nameof(Get), new { id = user.id }, user);
        }

        [HttpPost("login")]
        public async Task<ActionResult<Userreg>> Post([FromBody] Userlog user)
        {
            var user_1 =await _usersService.PostLoginAsync(user);
            if (user == null)
                return NotFound();
            return Ok(user_1);
        }


        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Userreg>> Put(int id, [FromBody] Userreg user_1)
        {
            if (_strongPassword.GetStrongPassword(user_1.password) < 3)
            {
                return BadRequest("Password too weak");
            }
            await _usersService.PutAsync(id, user_1);
            return Ok();
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
