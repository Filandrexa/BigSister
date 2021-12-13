using System;
using System.Linq;

namespace BigSister
{
    public class StartUpPoint
    {
        private string[] shipTypes;

        public StartUpPoint(string[] shipTypes)
        {
            this.shipTypes = shipTypes;
        }

        public Ship GreetingAndInputData()
        {
            Ship ship = new Ship();

            ship.type = ShipInput();
            ship.yearOfPurchase = YearInput();
            ship.yearOfTax = TaxInput();
            ship.lightMiles = MilesInput();

            return ship;
        }

        public void CalculatedTaxes(int tax)
        {
            if (tax <= 0)
            {
                tax = 0;
            }
            Console.WriteLine($"Tax to be payed: {tax} DVS");
        }

        public bool CalculateNew()
        {
            Console.WriteLine("Would you like to calculate again? 'Yes/No' ");
            var input = Console.ReadLine().Trim();

            if (input.ToLower() == "yes")
            {
                return true;
            }

            return false;
        }

        private string ShipInput() 
        {
            Console.Write("1. Type of ship: ");
            var ship = Console.ReadLine().Trim();

            while (!shipTypes.Contains(ship, StringComparer.OrdinalIgnoreCase))
            {
                Console.Write($"{ship} is not a valid input, please use {String.Join(',', shipTypes)}: ");
                ship = Console.ReadLine().Trim();
            }

            return ship;
        }

        private int YearInput()
        {
            Console.Write("2. Year of purchase: ");
            var input = Console.ReadLine().Trim();
            var yearOfPurchaseBool = int.TryParse(input, out int yearOfPurchase);

            while (!yearOfPurchaseBool || yearOfPurchase <= 0)
            {
                Console.Write($"{input} is not a valid input, please input year of purchase: ");
                input = Console.ReadLine().Trim();
                yearOfPurchaseBool = int.TryParse(input, out yearOfPurchase);
            }

            return yearOfPurchase;
        }

        private int TaxInput()
        {
            Console.Write("3. Year of tax calculation: ");
            var input = Console.ReadLine().Trim();
            var yearOfTaxBool = int.TryParse(input, out int yearOfTax);

            while (!yearOfTaxBool || yearOfTax <= 0)
            {
                Console.Write($"{input} is not a valid input, please input year of tax calculation: ");
                input = Console.ReadLine().Trim();
                yearOfTaxBool = int.TryParse(input, out yearOfTax);
            }

            return yearOfTax;
        }

        private int MilesInput()
        {
            Console.Write("3. Light miles traveled: ");
            var input = Console.ReadLine().Trim().Split('_', StringSplitOptions.RemoveEmptyEntries).ToArray()[0];
            var milesBool = int.TryParse(input, out int lightMiles);

            while (!milesBool || lightMiles <= 0)
            {
                Console.Write($"{input} is not a valid input, please input light miles traveled: ");
                input = Console.ReadLine().Trim().Split('_', StringSplitOptions.RemoveEmptyEntries).ToArray()[0];
                milesBool = int.TryParse(input, out lightMiles);
            }

            return lightMiles;
        }
    }
}
