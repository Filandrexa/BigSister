namespace BigSister
{
    public class Ship
    {
        public readonly string Type;

        private int InitialTax;

        private int LightMilesCoefficient;

        private int YearlyCoefficient;

        private int YearOfPurchase;

        private int YearOfTax;

        private int LightMiles;

        public Ship(string type, int initialTax, int lightMilesCoefficient, int yearlyCoefficient)
        {
            this.Type = type;
            this.InitialTax = initialTax;
            this.LightMilesCoefficient = lightMilesCoefficient;
            this.YearlyCoefficient = yearlyCoefficient;
        }

        public bool yearOfPurchase(string year)
        {
            var yearOfPurchaseBool = int.TryParse(year, out int yearOfPurchase);

            if (yearOfPurchaseBool && yearOfPurchase >= 0)
            {
                YearOfPurchase = yearOfPurchase;
                return true;
            }

            return false;
        }

        public bool yearOfTax(string year) 
        {
            var yearOfTaxBool = int.TryParse(year, out int yearOfTax);

            if (yearOfTaxBool && yearOfTax >= 0 && yearOfTax >= YearOfPurchase)
            {
                YearOfTax = yearOfTax;
                return true;
            }

            return false;
        }

        public bool lightMiles(string miles)
        {
            var lightMilesBool = int.TryParse(miles, out int lightMiles);

            if (lightMilesBool && lightMiles >= 0)
            {
                LightMiles = lightMiles;
                return true;
            }

            return false;
        }

        public int Taxes()
        {
           var taxes = InitialTax + LightMiles * LightMilesCoefficient - (YearOfTax - YearOfPurchase) * YearlyCoefficient;

           if (taxes < 0)
           {
                return 0;
           }

           return taxes;
        }
    }
}
