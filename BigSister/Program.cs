using System;
using System.Linq;

namespace BigSister
{
    class Program
    {
        static void Main(string[] args)
        {
            //spaceship type, year of purchase, year of tax calculation, and light miles traveled

            var input = Console.ReadLine().Split(',', StringSplitOptions.RemoveEmptyEntries).ToArray();

            var spaceShip = input[0].ToLower();
            var yearOfPurchase = int.Parse(input[1]);
            var yearOfTax = int.Parse(input[2]);
            var lightMiles = int.Parse(input[3].Split('_', StringSplitOptions.RemoveEmptyEntries).ToArray()[0]);

            var tax = 0;
            if (spaceShip == "cargo")
            {
                tax += 10000;
                tax += 1000 * lightMiles;
                tax -= 736 * (yearOfTax - yearOfPurchase);
            }
            else if (spaceShip == "family")
            {
                tax += 5000;
                tax += 100 * lightMiles;
                tax -= 355 * (yearOfTax - yearOfPurchase);
            }

            Console.WriteLine($"Ship: {spaceShip}, purchased: {yearOfPurchase}, tax: {yearOfTax}, miles: {lightMiles}");
            Console.WriteLine($"Tax to be payed:{tax} DVS");
        }
    }
}
