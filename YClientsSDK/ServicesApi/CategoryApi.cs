using YClientsSDK.Entities;

namespace YClientsSDK.ServicesApi
{
    public class CategoryApi : YClientsApi<ServiceCategory>
    {

        public CategoryApi(string userToken) : base(userToken) { }


        public async Task<ServiceCategory> CreateServiceCategoryAsync(ServiceCategory category,string companyId)
        {

            var url = new Uri($"https://api.yclients.com/api/v1/service_categories/{companyId}");
            return await CreateEntityAsync(category, url);

        }

        public async Task<ServiceCategory> GetServiceCategoryAsync(string companyId, string categoryId)
        {
            var url = new Uri($"https://api.yclients.com/api/v1/service_category/{companyId}/{categoryId}");

            return await GetEntityAsync(url);

        }

        public async Task<ServiceCategory> UpdateServiceCategoryAsync(ServiceCategory category, string companyId)
        {
            var url = new Uri($"https://api.yclients.com/api/v1/service_category/{companyId}/{category.Id}");

            return await UpdateEntityAsync(category, url);

        }

    }
}
