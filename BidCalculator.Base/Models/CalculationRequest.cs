using BidCalculator.Base.Enums;

namespace BidCalculator.Base.Models
{
    public class CalculationRequest
    {
        public VehicleType VehicleType { get; set; }
        public decimal BasePrice { get; set; }
    }
}
