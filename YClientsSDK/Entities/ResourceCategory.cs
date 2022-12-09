using System.Text.Json.Serialization;

namespace YClientsSDK.Entities
{
    public class ResourceCategory
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }

        [JsonPropertyName("title")]
        public string Name { get; set; }

        public Resource[] Instances { get; set; }
    }
}
