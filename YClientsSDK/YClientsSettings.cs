namespace YClientsSDK
{
    public static class YClientsSettings
    {
        public static string PartnerToken { get; private set; }
        public static void Config(string partnerToken)
        {
            PartnerToken = partnerToken;
        }
    }
}
