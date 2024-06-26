using BidCalculator.Base.Enums;
using BidCalculator.Base.Extensions;
using BidCalculator.Base.Interfaces;
using BidCalculator.Base.Models;

namespace BidCalculator.Base.Services
{
    public class CalculationService : ICalculationService
    {
        public CalculationResponse Calculate(CalculationRequest request)
        {
            var response = new CalculationResponse();

            if (request.BasePrice < 0) {
                throw new ArgumentException("Invalid base price");
            }

            response.BasePrice = request.BasePrice;
            response.VehicleType = request.VehicleType;

            // Basic user fee: 10% of the price of the vehicle
            response.BasicFee = response.BasePrice.RoundedPercentage(0.1m);

            response.BasicFee = response.VehicleType switch
            {
                // Common: minimum $10 and maximum $50
                VehicleType.Common => response.BasicFee.LimitToRange(10m, 50m),
                // Luxury: minimum 25$ and maximum 200$
                VehicleType.Luxury => response.BasicFee.LimitToRange(25, 200m),
                _ => throw new ArgumentException("Invalid vehicle type")
            };

            response.SpecialFee = response.VehicleType switch
            {
                // Common: minimum $10 and maximum $50
                VehicleType.Common => response.BasePrice.RoundedPercentage(0.02m),
                // Luxury: minimum 25$ and maximum 200$
                VehicleType.Luxury => response.BasePrice.RoundedPercentage(0.04m),
                _ => throw new ArgumentException("Invalid vehicle type")
            };

            response.AssociationFee = response.BasePrice switch
            {
                // $5 for an amount between $1 and $500
                (>= 1m) and (<= 500m) => 5m,
                // $10 for an amount greater than $500 up to $1000
                (> 500m) and (<= 1000m) => 10m,
                // $15 for an amount greater than $1000 up to $3000
                (> 1000m) and (<= 3000m) => 15m,
                // $15 for an amount greater than $1000 up to $3000
                > 3000m => 20m,
                // Specifications unclear for values between 0 and 1; assume zero for now
                _ => 0m
            };

            response.StorageFee = 100m;

            return response;
        }
    }
}
