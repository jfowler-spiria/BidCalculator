using BidCalculator.Base.Enums;
using BidCalculator.Base.Models;
using BidCalculator.Base.Services;

namespace BidCalculator.Base.Tests
{
    public class CalculationServiceTests
    {
        [Theory]
        [InlineData(398.00, VehicleType.Common, 39.80, 7.96, 5.00, 100.00, 550.76)]
        [InlineData(501.00, VehicleType.Common, 50.00, 10.02, 10.00, 100.00, 671.02)]
        [InlineData(57.00, VehicleType.Common, 10.00, 1.14, 5.00, 100.00, 173.14)]
        [InlineData(1_800.00, VehicleType.Luxury, 180.00, 72.00, 15.00, 100.00, 2_167.00)]
        [InlineData(1_100.00, VehicleType.Common, 50.00, 22.00, 15.00, 100.00, 1_287.00)]
        [InlineData(1_000_000.00, VehicleType.Luxury, 200.00, 40_000.00, 20.00, 100.00, 1_040_320.00)]
        public void Calculate_ReturnsCorrectAmounts(decimal basePrice, VehicleType vehicleType, decimal basicFee, decimal specialFee, decimal associationfee, decimal storageFee, decimal total)
        {
            var calculationService = new CalculationService();
            var response = calculationService.Calculate(new CalculationRequest { BasePrice = basePrice, VehicleType = vehicleType });

            Assert.Equal(basicFee, response.BasicFee);
            Assert.Equal(specialFee, response.SpecialFee);
            Assert.Equal(associationfee, response.AssociationFee);
            Assert.Equal(storageFee, response.StorageFee);
            Assert.Equal(total, response.Total);
        }
    }
}