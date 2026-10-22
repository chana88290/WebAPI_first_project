using System.ComponentModel.DataAnnotations;

namespace WebAPI
{
    public class Userlog
    {
        [EmailAddress]
        public string l_email { get; set; }
        [Required]
        public string l_password { get; set; }
    }
}
