using System.Text.Json.Serialization;

namespace YClientsSDK.Entities
{
    public class Resource
    {
        public int Id { get; set; }

        [JsonPropertyName("resource_id")]
        public int ResourceId { get; set; }

        [JsonPropertyName("title")]
        public string Name { get; set; }

    }
}
