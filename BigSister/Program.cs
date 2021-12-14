using System;
using System.Collections.Generic;

namespace BigSister
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Ship> ships = new Dictionary<string, Ship>();
            ships.Add("cargo", new Ship("Cargo", 10000, 1000, 736));
            ships.Add("family", new Ship("Family", 5000, 100, 355));

            StartUpPoint startUpPoint = new StartUpPoint(ships);
            
            Console.WriteLine("Welcome to Big Sister's tax collection system. Please input the needed parameters:");
            var calculateNewTax = true;

            while (calculateNewTax)
            {
                var ship = startUpPoint.GreetingAndInputData();
                Console.WriteLine($"Taxes to pay Big Sister for {ship.type} ship: {ship.Taxes()} DVS");
                calculateNewTax = startUpPoint.NewCalculate();
            }
        }
    }
}
