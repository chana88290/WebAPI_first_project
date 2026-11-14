using System.ComponentModel.DataAnnotations;

namespace WebAPI
{
    public class Userreg
    {
        public int id { get; set; }
        [Required]
        //In C#, properties are PascalCase (FirstName). Don't rename it: the data file uses firstName. Add PropertyNameCaseInsensitive = true to the JSON options instead
        public string firstName { get; set; }
        [Required]
        public string lastName { get; set; }
        [EmailAddress]
        public string email { get; set; }
        [Required]
        public string password { get; set; }
    }
}
