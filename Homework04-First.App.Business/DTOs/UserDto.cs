using System.Text.Json.Serialization;

namespace First.App.Business.DTOs
{
    public class UserDto
    {
        public string Email { get; set; }
        public string Name { get; set; }

        public string Surname { get; set; }
        [JsonIgnore]
        public string Password { get; set; }
    }
}
