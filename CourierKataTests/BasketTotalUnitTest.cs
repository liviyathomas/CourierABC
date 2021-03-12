using CourierKata;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CourierKataTests
{
    [TestClass]
    public class BasketTotalUnitTest
    {
        [TestMethod]
        public void Test_AddingVariousParcels()
        {
            Basket basket = new Basket();
            basket.AddToBasket("Medium Parcel", 8);
            basket.AddToBasket("Small Parcel", 3);
            basket.AddToBasket("XL Parcel", 25);
            basket.AddToBasket("Large Parcel", 15);
            basket.AddToBasket("Small Parcel", 3);
            basket.AddToBasket("XL Parcel", 25);
            decimal totalPrice = basket.GetBasketTotalPrice();
            Assert.AreEqual(totalPrice, 79);
        }

        [TestMethod]
        public void Test_AddingVariousSpeedyShipping()
        {
            Basket basket = new Basket();
            basket.GetSpeedyShipping("2");
            basket.GetSpeedyShipping("4");
            basket.GetSpeedyShipping("1");
            decimal totalPrice = basket.GetBasketTotalPrice();
            Assert.AreEqual(totalPrice, 36);
        }

        [TestMethod]
        public void Test_SmallParcelDiscount()
        {
            Basket basket = new Basket();
            basket.AddToBasket("Small Parcel", 3);
            basket.GetParcelWeight("1", "1");
            basket.AddToBasket("Speedy Shipping", 0);
            basket.AddToBasket("Small Parcel", 3);
            basket.GetParcelWeight("1", "1");
            basket.GetSpeedyShipping("1");
            basket.AddToBasket("Small Parcel", 3);
            basket.GetParcelWeight("1", "3");
            basket.GetSpeedyShipping("1");
            basket.AddToBasket("Small Parcel", 3);
            basket.GetParcelWeight("1", "3");
            basket.AddToBasket("Speedy Shipping", 0);
            basket.GetSmallBasketDiscounts();
            decimal totalPrice = basket.GetBasketTotalPrice();
            Assert.AreEqual(totalPrice, 23);
        }

        [TestMethod]
        public void Test_MediumParcelDiscount()
        {
            Basket basket = new Basket();
            basket.AddToBasket("Medium Parcel", 8);
            basket.AddToBasket("Additional Weight Cost", 0);
            basket.AddToBasket("Speedy Shipping", 0);
            basket.AddToBasket("Medium Parcel", 8);
            basket.AddToBasket("Additional Weight Cost", 0);
            basket.GetSpeedyShipping("2");
            basket.AddToBasket("Medium Parcel", 8);
            basket.GetParcelWeight("2", "5");
            basket.GetSpeedyShipping("2");
            basket.AddToBasket("Medium Parcel", 8);
            basket.GetParcelWeight("2", "7");
            basket.AddToBasket("Speedy Shipping", 0);
            basket.AddToBasket("Medium Parcel", 8);
            basket.GetParcelWeight("2", "6");
            basket.AddToBasket("Speedy Shipping", 0);
            basket.AddToBasket("Medium Parcel", 8);
            basket.GetParcelWeight("2", "5");
            basket.AddToBasket("Speedy Shipping", 0);
            basket.GetMediumBasketDiscounts();
            decimal totalPrice = basket.GetBasketTotalPrice();
            Assert.AreEqual(totalPrice, 66);
        }

        [TestMethod]
        public void Test_ClearingBasket()
        {
            Basket basket = new Basket();
            basket.AddToBasket("Medium Parcel", 8);
            basket.AddToBasket("Additional Weight Cost", 0);
            basket.AddToBasket("Speedy Shipping", 0);
            basket.AddToBasket("XL Parcel", 25);
            basket.AddToBasket("Additional Weight Cost", 0);
            basket.GetSpeedyShipping("4");
            basket.AddToBasket("Small Parcel", 3);
            basket.GetParcelWeight("1", "3");
            basket.GetSpeedyShipping("1");
            basket.Clear(); // Clear basket
            decimal totalPrice = basket.GetBasketTotalPrice();
            Assert.AreEqual(totalPrice, 0);
        }

        [TestMethod]
        public void Test_ClearingBasketAndDiscount()
        {
            Basket basket = new Basket();
            basket.AddToBasket("Small Parcel", 3);
            basket.GetParcelWeight("1", "4");
            basket.GetSpeedyShipping("1");
            basket.AddToBasket("Small Parcel", 3);
            basket.AddToBasket("Additional Weight Cost", 0);
            basket.GetSpeedyShipping("1");
            basket.AddToBasket("Small Parcel", 3);
            basket.GetParcelWeight("1", "3");
            basket.GetSpeedyShipping("1");
            basket.AddToBasket("Small Parcel", 3);
            basket.GetParcelWeight("1", "3");
            basket.AddToBasket("Speedy Shipping", 0);
            basket.GetSmallBasketDiscounts(); // Add discount to parcels
            basket.Clear(); // Clear basket
            basket.AddToBasket("Small Parcel", 3);
            basket.AddToBasket("Additional Weight Cost", 0);
            basket.GetSpeedyShipping("1");
            decimal totalPrice = basket.GetBasketTotalPrice();
            Assert.AreEqual(totalPrice, 6);
        }
    }
}
