using System.Text.Json.Serialization;

namespace YClientsSDK.Entities
{
    public class User
    {
        public int Id { get; set; }

        [JsonPropertyName("user_token")]
        public string Token { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
    }
}
