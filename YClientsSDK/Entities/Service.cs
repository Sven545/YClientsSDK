using System.Text.Json.Serialization;

namespace YClientsSDK.Entities
{
    public class Service
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("category_id")]
        public int CategoryId { get; set; }

        public int Cost { get; set; }
        public int Amount { get; set; }

        [JsonPropertyName("title")]
        public string Name { get; set; }

        public int Duration { get; set; }
        public string Comment { get; set; }
       
        public Staff[] Staff { get; set; }
        public int[] Resources { get; set; }
    }
}
