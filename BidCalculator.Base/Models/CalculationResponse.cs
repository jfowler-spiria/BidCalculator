namespace BidCalculator.Base.Models
{
    public class CalculationResponse : CalculationRequest
    {
        public decimal BasicFee { get; set; }
        public decimal SpecialFee { get; set; }
        public decimal AssociationFee { get; set; }
        public decimal StorageFee { get; set; }
        public decimal Total { get { return Math.Round(BasePrice + BasicFee + SpecialFee + AssociationFee + StorageFee, 2); } }
    }
}
