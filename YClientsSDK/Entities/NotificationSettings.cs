using System;
using System.Text.Json.Serialization;

namespace YClientsSDK.Entities
{
    public class NotificationSettings
    {

        [JsonPropertyName("urls")]
        public string[] NotifyUrls { get; set; } = Array.Empty<string>();

        [JsonInclude]
        [JsonPropertyName("active")]
        public int Active { get; private set; }

        [JsonInclude]
        [JsonPropertyName("record")]
        public int Record { get; private set; }



        [JsonIgnore]
        public int CompanyId { get; set; }
        [JsonIgnore]
        public bool NotifyStatus
        {
            get
            {
                return Active == 1;
            }
            set
            {
                Active = value ? 1 : 0;
            }
        }
        [JsonIgnore]
        public bool RecordsIsNotify
        {
            get
            {
                return Record == 1;
            }
            set
            {
                Record = value ? 1 : 0;
            }
        }
    }
}
