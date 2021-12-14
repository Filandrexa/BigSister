namespace BigSister
{
    public class Ship
    {
        public readonly string type;

        private readonly int initialTax;

        private readonly int lightMilesCoefficient;

        private readonly int yearlyCoefficient;

        public Ship(string type, int initialTax, int lightMilesCoefficient, int yearlyCoefficient)
        {
            this.type = type;
            this.initialTax = initialTax;
            this.lightMilesCoefficient = lightMilesCoefficient;
            this.yearlyCoefficient = yearlyCoefficient;
        }

        public int yearOfPurchase { get; set; }

        public int yearOfTax { get; set; }

        public int lightMiles { get; set; }

        public int Taxes() => initialTax + lightMiles * lightMilesCoefficient - (yearOfTax - yearOfPurchase) * yearlyCoefficient;
    }
}
