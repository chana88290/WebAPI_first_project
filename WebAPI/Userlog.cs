using System.ComponentModel.DataAnnotations;

namespace WebAPI
{
    //A full name is clearer than an abbreviation (for example LoginUser).
    //In C#, public properties are written in PascalCase without prefixes (Email, Password)
    public class Userlog
    {
        [EmailAddress]
        public string l_email { get; set; }
        [Required]
        public string l_password { get; set; }
    }
}
