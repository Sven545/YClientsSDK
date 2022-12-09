using System.Text.Json.Serialization;


namespace YClientsSDK.Entities
{
    public class Company
    {
        public int Id { get; set; }

        [JsonPropertyName("main_group_id")]
        public int NetworkId { get; set; }

        [JsonPropertyName("title")]
        public string Name { get; set; }

        [JsonPropertyName("main_group")]
        public Network Network { get; set; }
    }
}
