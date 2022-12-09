using YClientsSDK.Entities;

namespace YClientsSDK.ServicesApi
{
    public class AuthorizationApi : YClientsApi<User>
    {
        public AuthorizationApi():base()
        {}

        public async Task<User> AuthorizeAsync(string userLogin, string userPassword)
        {
            
            var url = new Uri("https://api.yclients.com/api/v1/auth");
            return await AuthorizeAsync(userLogin, userPassword, url);

        }
    }
}
