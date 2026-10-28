using System.ComponentModel.DataAnnotations;

namespace WebAPI
{
    //A full name is clearer than an abbreviation (for example RegisterUser).
    //In C#, public properties are written in PascalCase (Id, FirstName, LastName, Email, Password).
    //If you rename them, Users.txt still has the old names, so read it with
    //new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
    public class Userreg
    {
        public int id { get; set; }
        [Required]
        public string firstName { get; set; }
        [Required]
        public string lastName { get; set; }
        [EmailAddress]
        public string email { get; set; }
        [Required]
        public string password { get; set; }
    }
}
