using System.Text.Json.Serialization;

namespace YClientsSDK.Entities
{
    public class ServiceCategory
    {
        public int Id { get; set; }

        [JsonPropertyName("title")]
        public string Name { get; set; }

        [JsonPropertyName("staff")]
        public int[] StaffIds { get; set; }
    }
}
