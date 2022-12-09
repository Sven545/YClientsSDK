using System.Text.Json.Serialization;

namespace YClientsSDK.Entities
{
    public class Staff
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Specialization { get; set; }

        [JsonPropertyName("company_id")]
        public int CompanyId { get; set; }
        public string Information { get; set; }

        [JsonPropertyName("seance_length")]
        public int? SeanceLength { get; set; }
    }
}
