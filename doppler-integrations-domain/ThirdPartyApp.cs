namespace DopplerIntegrationsDomain
{
    public class ThirdPartyApp
    {
        public int IdThirdPartyApp { get; set; }

        public string Name { get; set; } = string.Empty;

        public bool Active { get; set; } = true;

        public bool ProductsEnabled { get; set; } 
        
        public bool AbandonedCartEnabled { get; set; } 

        public bool VisitedProductsEnabled { get; set; } 

        public bool CrossSellingEnabled { get; set; }

        public bool BestSellingEnabled { get; set; } 

        public bool NewProductsEnabled { get; set; } 

        public bool PendingOrderEnabled { get; set; }

        public bool ConfirmationOrderEnabled { get; set; }

        public bool RFMEnabled { get; set; }

        public bool PromotionCodeEnabled { get; set; }
        
        public bool AssistedShoppingEnabled { get; set; }
    }
}
