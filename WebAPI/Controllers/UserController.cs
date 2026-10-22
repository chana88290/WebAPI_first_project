using Microsoft.AspNetCore.Mvc;
using System.Runtime.Intrinsics.Arm;
using System.Text.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class User : ControllerBase
    {
        static string filePath = "Users.txt";

        // GET: api/<user>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<user>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<user>
        [HttpPost]
        public IActionResult Post([FromBody] Userreg user)
        {
            int numberOfUsers = System.IO.File.ReadLines(filePath).Count();
            user.id = numberOfUsers + 1;
            string userJson = JsonSerializer.Serialize(user);
            System.IO.File.AppendAllText(filePath, userJson + Environment.NewLine);
            return CreatedAtAction(nameof(Get),new { id = user.id },user);
        }

        // POST api/<user>/logins 
        [HttpPost("login")]
        public IActionResult Post([FromBody] Userlog user)
        {
            using (StreamReader reader = System.IO.File.OpenText(filePath))
            {
                string? currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {
                    Userreg user_2 = JsonSerializer.Deserialize<Userreg>(currentUserInFile);
                    if (user.l_email == user_2.email && user.l_password == user_2.password)
                        return Ok(user_2);
                }
                return NoContent();
            }
        }

        // PUT api/<user>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Userreg user_1)
        {
            string textToReplace = string.Empty;
            using (StreamReader reader = System.IO.File.OpenText(filePath))
            {
                string currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {
                    Userreg user =
                    JsonSerializer.Deserialize<Userreg>(currentUserInFile);
                    if (user.id == id)
                        textToReplace = currentUserInFile;
                }
            }
            if(textToReplace != string.Empty){
                string text = System.IO.File.ReadAllText(filePath);
                text = text.Replace(textToReplace,
                JsonSerializer.Serialize(user_1));
                System.IO.File.WriteAllText(filePath, text);
            }
        }

        // DELETE api/<user>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
