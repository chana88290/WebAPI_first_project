using System.ComponentModel.DataAnnotations;

namespace WebAPI
{
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
