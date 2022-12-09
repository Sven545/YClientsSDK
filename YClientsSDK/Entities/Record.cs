using System.Text.Json.Serialization;


namespace YClientsSDK.Entities
{
    public class Record
    {

        [JsonPropertyName("company_id")]
        public int CompanyId { get; set; }

        [JsonPropertyName("staff_id")]
        public int StaffId { get; set; }

        [JsonPropertyName("datetime")]
        public DateTime StartDateTime { get; set; }

        [JsonPropertyName("last_change_date")]
        public string LastChangeDateStr { get; set; }

        [JsonPropertyName("create_date")]
        public string CreateDateStr { get; set; }

        [JsonPropertyName("seance_length")]
        public int Length { get; set; }

        [JsonPropertyName("attendance")]
        public RecordStatusYclients Status { get; set; }

        [JsonPropertyName("save_if_busy")]
        public bool SaveIfBusy { get; set; } = true;

        public int Id { get; set; }
        public Service[] Services { get; set; }
        public Staff Staff { get; set; }
        public Client Client { get; set; }
        public bool Deleted { get; set; }
        public string Comment { get; set; }


        [JsonIgnore]
        public DateTime EndDateTime
        {
            get
            {
                return StartDateTime.AddSeconds(Length);
            }
        }

        [JsonIgnore]
        public DateTime LastChangeDateTime
        {
            get
            {
                return ErrorDateTimeYclToNorma(LastChangeDateStr);
            }
        }

        [JsonIgnore]
        public DateTime CreateDateTime
        {
            get
            {
                return ErrorDateTimeYclToNorma(CreateDateStr);
            }
        }


        /// <summary>
        /// Метод исправляет ошибку в формате даты, полученной от YClients (2022-08-12T18:57:44+0300 => 2022-08-12T18:57:44+03:00)
        /// </summary>
        private DateTime ErrorDateTimeYclToNorma(string badDateTime)
        {
            var goodDateTime = badDateTime.Insert(badDateTime.Length - 2, ":");
            return DateTime.Parse(goodDateTime);
        }

        public enum RecordStatusYclients
        {
            ClientNotCome = -1,
            ClientWaiting,
            ClientServiced,
            ClientConfirmed
        }
    }
}
