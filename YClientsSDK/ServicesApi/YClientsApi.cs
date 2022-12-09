using System.Net;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using RateLimiter;
using ComposableAsync;
using YClientsSDK.Entities;

namespace YClientsSDK.ServicesApi
{
    public abstract class YClientsApi<T> : IDisposable
    {
        private string _partnerToken = YClientsSettings.PartnerToken;
        private const int _maxCountRequestsPerSecond = 4;
        private static TimeLimiter _timeConstraint;

        protected HttpClient _client;
        protected JsonSerializerOptions _options = new JsonSerializerOptions(JsonSerializerDefaults.Web);

        static YClientsApi()
        {
            _timeConstraint = TimeLimiter.GetFromMaxCountByInterval(_maxCountRequestsPerSecond, TimeSpan.FromSeconds(1));

        }
        public YClientsApi(string userToken)
        {
            _client = new HttpClient();

            string bearer = string.IsNullOrEmpty(userToken) ? $"Bearer {_partnerToken}" : $"Bearer {_partnerToken}, User {userToken}";
            _client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", bearer);
            _client.DefaultRequestHeaders.Add("Accept", "application/vnd.yclients.v2+json");
            _client.DefaultRequestHeaders.Add("ContentType", "application/json");

        }
        public YClientsApi() : this(null) { }

        public void Dispose() => 
            _client.Dispose();

        protected async Task<User> AuthorizeAsync(string login, string password, Uri url) =>
            TryGetResult<User>(await PostAsync(url, GetContent(new { login, password })));

        protected async Task<T> CreateEntityAsync(T entity, Uri url) =>
            TryGetResult<T>(await PostAsync(url, GetContent(entity)));

        protected async Task<T> UpdateEntityAsync(T entity, Uri url) =>
            TryGetResult<T>(await PutAsync(url, GetContent(entity)));

        protected async Task<IEnumerable<T>> GetEntitiesAsync(Uri url) =>
            TryGetResult<IEnumerable<T>>(await GetAsync(url));

        protected async Task<T> GetEntityAsync(Uri url) =>
            TryGetResult<T>(await GetAsync(url));

        protected async Task DeleteEntityAsync(Uri url) =>
            await DeleteAsync(url);


        private bool IsSuccess(string result) => 
            bool.Parse(JsonNode.Parse(result)["success"].ToString());

        private string GetResultMessage(string result) =>
            JsonNode.Parse(result)["meta"]["message"].ToString();

        private TResult GetResult<TResult>(string result) =>
            JsonSerializer.Deserialize<TResult>(JsonNode.Parse(result)["data"], _options);

        private StringContent GetContent(object entity) => 
            new StringContent(JsonSerializer.Serialize(entity, _options), Encoding.UTF8, "application/json");

        
        private TResult TryGetResult<TResult>(string result)
        {
            if (IsSuccess(result))
                return GetResult<TResult>(result);

            throw new Exception(GetResultMessage(result));
        }

        private async Task<string> PostAsync(Uri url, StringContent content)
        {
            await _timeConstraint;
            var response = await _client.PostAsync(url, content);
            return await response.Content.ReadAsStringAsync();
        }

        private async Task<string> PutAsync(Uri url, StringContent content)
        {
            await _timeConstraint;
            var response = await _client.PutAsync(url, content);
            return await response.Content.ReadAsStringAsync();
        }

        private async Task<string> GetAsync(Uri url)
        {
            await _timeConstraint;
            var response = await _client.GetAsync(url);
            return await response.Content.ReadAsStringAsync();
        }

        private async Task DeleteAsync(Uri url)
        {
            await _timeConstraint;
            var response = await _client.DeleteAsync(url);

            if (response.StatusCode != HttpStatusCode.NoContent)
            {
                throw new Exception(GetResultMessage(await response.Content.ReadAsStringAsync()));
            }
        }
    }
}
