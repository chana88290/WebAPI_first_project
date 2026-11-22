using System.ComponentModel.DataAnnotations;

namespace WebAPI
{
    public class Userreg
    {
        //In C#, properties are written in PascalCase: Id. Users.txt stores the current names: if you rename them, set PropertyNameCaseInsensitive = true in the JsonSerializerOptions, so the existing file still loads
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
