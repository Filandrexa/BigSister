using NUnit.Framework;

namespace BigSister.Tests
{
    public class Tests
    {
        Ship cargoShip = new Ship("Cargo", 10000, 1000, 736);
        Ship familyShip = new Ship("Family", 5000, 100, 355);

        [Test]
        [TestCase("100", "2000", "2020")]
        [TestCase("100", "2000", "2000")]
        [TestCase("100", "0", "2000")]
        [TestCase("100", "2000", "0")]
        [TestCase("1", "2000", "2020")]
        [TestCase("1", "-2000", "2020")]
        [TestCase("1", "2000", "-2020")]
        [TestCase("0", "2000", "2020")]
        [TestCase("-1", "2000", "2020")]
        [TestCase("1", "2000", "3300")]
        [TestCase("5001", "2000", "2020")]
        [TestCase("0", "0", "0")]
        public void ShipTaxMethodShouldReturnAPositiveNumberOrZero(
            string lightMiles, string yearOfPurchase, string yearOfTax)
        {
            cargoShip.lightMiles(lightMiles);
            cargoShip.yearOfPurchase(yearOfPurchase);
            cargoShip.yearOfTax(yearOfTax);

            var tax = cargoShip.Taxes();

            Assert.That(tax >= 0);
        }

        [Test]
        [TestCase("344", "2332", "2369")]
        public void CargoShipTaxMethodShouldReturnTheCorrectValue(
            string lightMiles, string yearOfPurchase, string yearOfTax) 
        {
            cargoShip.lightMiles(lightMiles);
            cargoShip.yearOfPurchase(yearOfPurchase);
            cargoShip.yearOfTax(yearOfTax);

            var tax = cargoShip.Taxes();

            Assert.That(tax == 326768);
        }

        [Test]
        [TestCase("2", "2300", "2307")]
        public void FamilyShipTaxMethodShouldReturnTheCorrectValue(
            string lightMiles, string yearOfPurchase, string yearOfTax)
        {
            familyShip.lightMiles(lightMiles);
            familyShip.yearOfPurchase(yearOfPurchase);
            familyShip.yearOfTax(yearOfTax);

            var tax = familyShip.Taxes();

            Assert.That(tax == 2715);
        }

        [Test]
        [TestCase("")]
        [TestCase("A")]
        [TestCase("%$#")]
        public void ShipLightMilesMethodShouldReturnFalseIfParamsAreNotInTheCorrectFormat(string lightMiles)
        {
            var flag = cargoShip.lightMiles(lightMiles);

            Assert.That(flag == false);
        }

        [Test]
        [TestCase("")]
        [TestCase("A")]
        [TestCase("%$#")]
        public void ShipYearOfPurchaseShouldReturnFalseIfParamsAreNotInTheCorrectFormat(string year)
        {
            var flag = cargoShip.yearOfPurchase(year);

            Assert.That(flag == false);
        }

        [Test]
        [TestCase("")]
        [TestCase("A")]
        [TestCase("%$#")]
        public void ShipYearOfTaxShouldReturnFalseIfParamsAreNotInTheCorrectFormat(string year)
        {
            var flag = cargoShip.yearOfTax(year);

            Assert.That(flag == false);
        }

        [Test]
        [TestCase("0")]
        [TestCase("200")]
        [TestCase("-1")]
        public void ShipYearOfTaxShouldReturnFalseIfYearOfPurchaseValueIsGreater(string year)
        {
            cargoShip.yearOfPurchase("999");
            var flag = cargoShip.yearOfTax(year);

            Assert.That(flag == false);
        }
    }
}