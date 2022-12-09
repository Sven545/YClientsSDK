using YClientsSDK.Entities;

namespace YClientsSDK.ServicesApi
{

    public class RecordApi : YClientsApi<Record>
    {

        public RecordApi(string userToken) : base(userToken)
        { }


        public virtual async Task<Record> CreateRecordAsync(Record record)
        {

            var url = new Uri($"https://api.yclients.com/api/v1/records/{record.CompanyId}");

            return await CreateEntityAsync(record, url);

        }

        public virtual async Task<Record> UpdateRecordAsync(Record record)
        {

            var url = new Uri($"https://api.yclients.com/api/v1/record/{record.CompanyId}/{record.Id}");

            return await UpdateEntityAsync(record, url);

        }

        public virtual async Task<IEnumerable<Record>> GetRecordsAsync(string companyId, string staffId = null, string startDateTime_yyyy_MM_dd = null)
        {

            var builder = new UriBuilder($"https://api.yclients.com/api/v1/records/{companyId}")
            {
                Query= $"staff_id={staffId}&start_date={startDateTime_yyyy_MM_dd}"
            };

            return await GetEntitiesAsync(builder.Uri);

        }

        public virtual async Task<Record> GetRecordAsync(string companyId, string recordId)
        {

            var url = new Uri($"https://api.yclients.com/api/v1/record/{companyId}/{recordId}");

            return await GetEntityAsync(url);

        }

        public virtual async Task DeleteRecordAsync(Record record)
        {

            var url = new Uri($"https://api.yclients.com/api/v1/record/{record.CompanyId}/{record.Id}");

            await DeleteEntityAsync(url);

        }

    }
}
