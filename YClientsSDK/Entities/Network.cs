using System.Text.Json.Serialization;

namespace YClientsSDK.Entities
{
    public class Network
    {
        public int Id { get; set; }

        [JsonPropertyName("title")]
        public string Name { get; set; }
    }
}
