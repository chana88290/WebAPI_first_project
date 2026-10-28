using Microsoft.AspNetCore.Mvc;
//fix: Removed "using System.Runtime.Intrinsics.Arm;" - it was added by mistake and is not used
using System.Text.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //fix: A controller class name ends with Controller (the file is already called UserController.cs).
    //The route stays api/User
    public class UserController : ControllerBase
    {
        //fix: The path never changes, so it can be readonly
        static readonly string filePath = "Users.txt";

        // GET: api/<user>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<user>/5
        [HttpGet("{id}")]
        //Why isn't it implemented? It should read the file and return the user with this id (or NotFound / NoContent)
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
                    //A clearer name than user_2 would help, for example userInFile
                    Userreg user_2 = JsonSerializer.Deserialize<Userreg>(currentUserInFile);
                    if (user.l_email == user_2.email && user.l_password == user_2.password)
                        return Ok(user_2);
                }
                return NoContent();
            }
        }

        // PUT api/<user>/5
        [HttpPut("{id}")]
        //The assignment asks PUT to return Ok(): change void to IActionResult and return Ok() at the end
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
                    {
                        textToReplace = currentUserInFile;
                        //fix: Found- break
                        break;
                    }
                }
            }
            if(textToReplace != string.Empty){
                //fix: Keep the id, otherwise the updated user is saved without it
                user_1.id = id;
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
