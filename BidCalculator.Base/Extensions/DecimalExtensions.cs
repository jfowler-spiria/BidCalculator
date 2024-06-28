namespace BidCalculator.Base.Extensions
{
    public static class DecimalExtensions
    {
        public static decimal RoundedPercentage(this decimal value, decimal percentage)
        {
            return Math.Round(value * percentage, 2);
        }

        public static decimal LimitToRange(this decimal value, decimal minimum, decimal maximum)
        {
            if (minimum > maximum) throw new ArgumentException("Minimum is above maximum", nameof(minimum));
            if (maximum < minimum) throw new ArgumentException("Maximum is below minimum ", nameof(maximum));

            return Math.Min(maximum, Math.Max(minimum, value));
        }
    }
}
