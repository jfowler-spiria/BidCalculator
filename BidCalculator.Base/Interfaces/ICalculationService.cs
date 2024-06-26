using BidCalculator.Base.Models;

namespace BidCalculator.Base.Interfaces
{
    public interface ICalculationService
    {
        CalculationResponse Calculate(CalculationRequest request);
    }
}
