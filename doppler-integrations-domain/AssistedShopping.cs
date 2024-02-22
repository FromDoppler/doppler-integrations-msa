namespace DopplerIntegrationsDomain
{
    public class AssistedShopping
    {
        public int IdUser { get; set; }

        public int IdCampaign { get; set; }

        public int IdSubscriber { get; set; }

        public int IdThirdPartyApp { get; set; }

        public string IdOrder { get; set; }

        public double OrderTotal { get; set; }

        public string Currency { get; set; }

        public DateTime OrderDate { get; set; } 
        
        public DateTime OpenDate { get; set; } 

        public DateTime UTCAddedDate { get; set; }

        public Campaign Campaign { get; set; }
    }
}
