namespace DopplerIntegrationsDomain
{
    public class Campaign
    {
        public int IdCampaign { get; set; }

        public string Name { get; set; }

        public string CampaignType { get; set; }

        public string AutomationEventType { get; set; }

        public int AmountSentSubscribers { get; set; }

        public int DistinctOpenedMailCount { get; set; }

        public DateTime UTCSentDate { get; set; }
    }
}
