using System;

namespace BigSister
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] types = new string[]{ "Cargo", "Family" };
            StartUpPoint startUpPoint = new StartUpPoint(types);
            Calculator calculator = new Calculator();

            Console.WriteLine("Welcome to Big Sister's tax collection system. Please input the needed parameters:");
            var calculateNewTax = true;

            while (calculateNewTax)
            {
                var ship = startUpPoint.GreetingAndInputData();
                startUpPoint.CalculatedTaxes(calculator.TaxCalculated(ship));
                calculateNewTax = startUpPoint.CalculateNew();
            }
        }
    }
}
