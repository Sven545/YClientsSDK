using YClientsSDK.Entities;

namespace YClientsSDK.ServicesApi
{
    public class StaffApi : YClientsApi<Staff>
    {

        public StaffApi( string userToken) : base(userToken)
        {}


        public async Task<IEnumerable<Staff>> GetStaffsAsync(string companyId)
        {

            var url = new Uri($"https://api.yclients.com/api/v1/company/{companyId}/staff/");        
            return await GetEntitiesAsync(url);

        }

    }
}
