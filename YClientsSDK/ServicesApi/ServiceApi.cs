using YClientsSDK.Entities;

namespace YClientsSDK.ServicesApi
{
    public class ServiceApi : YClientsApi<Service>
    {

        public ServiceApi(string userToken) : base(userToken)
        { }


        public async Task<IEnumerable<Service>> GetServicesAsync(string companyId)
        {

            var url = new Uri($"https://api.yclients.com/api/v1/company/{companyId}/services");
            return await GetEntitiesAsync(url);

        }

        public async Task<Service> GetServiceAsync(string companyId, string serviceId)
        {

            var url = new Uri($"https://api.yclients.com/api/v1/company/{companyId}/services/{serviceId}");
            return await GetEntityAsync(url);

        }

        public async Task<Service> UpdateServiceAsync(Service service, string companyId)
        {

            var url = new Uri($"https://api.yclients.com/api/v1/services/{companyId}/{service.Id}");
            return await UpdateEntityAsync(service, url);

        }

        public async Task<Service> CreateServiceAsync(Service service, string companyId)
        {

            var url = new Uri($"https://api.yclients.com/api/v1/services/{companyId}");
            return await CreateEntityAsync(service, url);

        }

        public async Task RemoveServiceAsync(string companyId, string serviceId)
        {

            var url = new Uri($"https://api.yclients.com/api/v1/services/{companyId}/{serviceId}");
            await DeleteEntityAsync(url);

        }

    }
}



