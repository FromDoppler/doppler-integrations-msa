namespace DopplerIntegrationsDomain
{
    public class ThirdPartyAppXUser
    {
        public int IdUser { get; set; }

        public int IdThirdPartyApp { get; set; }

        public string AccessToken { get; set; }

        public string RefreshToken { get; set; }

        public long IdAccount { get; set; }

        public string AccountName { get; set; }

        public DateTime UTCLastUpdate { get; set; }

        public bool SendNotificationEmail { get; set; }

        public DateTime UTCLastCompletedSync { get; set; }

        public int SourceType { get; set; }

        public int ConnectionErrors { get; set; }

        public DateTime UTCLastValidation { get; set; }

        public DateTime UTCCreationDate { get; set; }

        public bool RFMActive { get; set; }

        public int RFMPeriod { get; set; }

        public DateTime? UTCLastRFMCalc { get; set; }

        public DateTime BQUpdateDate { get; set; }

        public DateTime UTCTokenExpiration { get; set; }

        public DateTime UTCLastAssistedShoppingSync { get; set; }

        public ThirdPartyApp ThirdPartyApp { get; set; }
    }
}
