using System;
using System.Collections.Generic;
using System.Linq;

namespace BigSister
{
    public class StartUpPoint
    {
        private Dictionary<string, Ship> ships;

        public StartUpPoint(Dictionary<string, Ship> ships)
        {
            this.ships = ships;
        }

        public Ship GreetingAndInputData()
        {
            var ship = ShipInput();
            YearOfPurchaseInput(ship);
            YearOfTaxInput(ship);
            MilesInput(ship);

            return ship;
        }

        public bool NewCalculate()
        {
            Console.WriteLine("Would you like to calculate again? 'Yes/No' ");
            var input = ReadInput();

            if (input.ToLower() == "yes")
            {
                return true;
            }

            return false;
        }

        public Ship ShipInput() 
        {
            Console.Write("1. Type of ship: ");
            var ship = ReadInput();

            while (!ships.ContainsKey(ship.ToLower()))
            {
                Console.Write($"'{ship}' is not a valid input, please use '{String.Join(", ", ships.Keys)}': ");
                ship = ReadInput();
            }

            return ships[ship.ToLower()];
        }

        public void YearOfPurchaseInput(Ship ship)
        {
            Console.Write("2. Year of purchase: ");
            var input = ReadInput();
            var flag = ship.yearOfPurchase(input);
            
            while (!flag)
            {
                Console.Write($"'{input}' is not a valid input, please input year of purchase: ");
                input = ReadInput();
                flag = ship.yearOfPurchase(input);
            }
        }

        public void YearOfTaxInput(Ship ship)
        {
            Console.Write("3. Year of tax calculation: ");
            var input = ReadInput();
            var flag = ship.yearOfTax(input);

            while (!flag)
            {
                Console.Write($"'{input}' is not a valid input, please input year of tax calculation: ");
                input = ReadInput();
                flag = ship.yearOfTax(input);
            }
        }

        public void MilesInput(Ship ship)
        {
            Console.Write("3. Light miles traveled: ");
            var separator = new char[] { '_', ',', '.'};
            var input = ReadInput().Split(separator, StringSplitOptions.RemoveEmptyEntries).ToArray()[0];
            var flag = ship.lightMiles(input);

            while (!flag)
            {
                Console.Write($"'{input}' is not a valid input, please input light miles traveled: ");
                input = ReadInput().Split('_', StringSplitOptions.RemoveEmptyEntries).ToArray()[0];
                flag = ship.lightMiles(input);
            }
        }

        public string ReadInput() 
        {
            return Console.ReadLine().Trim();
        }
    }
}
