namespace BigSister
{
    public class Calculator
    {
        public int TaxCalculated(Ship ship)
        {
            if (ship.type.ToLower() == "cargo")
            {
                return 10000 + ship.lightMiles * 1000 - ((ship.yearOfTax - ship.yearOfPurchase) * 736);
            }
            else
            {
                return 5000 + ship.lightMiles * 100 - ((ship.yearOfTax - ship.yearOfPurchase) * 355);
            }
        }
    }
}
