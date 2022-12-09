using YClientsSDK.Entities;

namespace YClientsSDK.ServicesApi
{
    public class NotificationApi : YClientsApi<NotificationSettings>
    {

        public NotificationApi(string userToken) : base(userToken)
        {}


        public async Task UpdateNotificationSettingsAsync(NotificationSettings settings)
        {

            var url = new Uri($"https://api.yclients.com/api/v1/hooks_settings/{settings.CompanyId}");
            await CreateEntityAsync(settings, url);

        }
    }
}
