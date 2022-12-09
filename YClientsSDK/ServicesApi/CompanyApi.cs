using YClientsSDK.Entities;

namespace YClientsSDK.ServicesApi
{
    public class CompanyApi : YClientsApi<Company>
    {

        public CompanyApi(string userToken):base(userToken)
        {}


        public async Task<IEnumerable<Company>> GetCompaniesAsync()
        {
            var builder = new UriBuilder("https://api.yclients.com/api/v1/companies")
            {
                Query = $"my={1}"
            };
           
            return await GetEntitiesAsync(builder.Uri);
        }

    }
}
