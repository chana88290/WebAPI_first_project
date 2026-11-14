using System.ComponentModel.DataAnnotations;

namespace WebAPI
{
    public class Userlog
    {
        [EmailAddress]
        //In C#, properties are PascalCase, and l_ is not a clear name. Don't rename it: the data file uses it. Add PropertyNameCaseInsensitive = true to the JSON options instead
        public string l_email { get; set; }
        [Required]
        public string l_password { get; set; }
    }
}
