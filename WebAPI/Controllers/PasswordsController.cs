using Microsoft.AspNetCore.Mvc;
using Service;
using Zxcvbn;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PasswordsController : ControllerBase
    {
        private readonly IStrongPassword _strongPassword;

        public PasswordsController(IStrongPassword strongPassword)
        {
            _strongPassword = strongPassword;
        }

        // GET: api/<PasswordsController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<PasswordsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<PasswordsController>
        [HttpPost]
        public IActionResult Post([FromBody] string password)
        {
            return Ok(_strongPassword.GetStrongPassword(password));
        }

        // PUT api/<PasswordsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PasswordsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
