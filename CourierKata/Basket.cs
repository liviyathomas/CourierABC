using System;
using System.Collections.Generic;
using System.Linq;

namespace CourierKata
{
    public class Basket
    {
        private List<Parcel> parcels;

        public Basket()
        {
            parcels = new List<Parcel>();
        }

        public string AddToBasket(string name, decimal price)
        {
            Parcel parcel = new Parcel(name, price);
            parcels.Add(parcel);

            return parcel.Name + " " + parcel.Price.ToString();
        }

        public IEnumerable<string> GetBasketParcels()
        {
            foreach (var parcel in parcels)
                yield return parcel.Name + " $" + parcel.Price;
        }

        public decimal GetBasketTotalPrice()
        {
            decimal totalPrice = 0;

            foreach (var parcelPrice in parcels)
                totalPrice += parcelPrice.Price;

            return totalPrice;

        }

        public void GetParcelWeight(string parcelInput, string weightInput)
        {
            decimal parcelWeight;
            int maxWeight = 0;

            switch (parcelInput)
            {
                case "1":
                    maxWeight = 1;
                    break;
                case "2":
                    maxWeight = 3;
                    break;
                case "3":
                    maxWeight = 6;
                    break;
                case "4":
                    maxWeight = 10;
                    break;
                case "5":
                    maxWeight = 50;
                    break;
                default:
                    break;
            }

            while (!Decimal.TryParse(weightInput, out parcelWeight) || parcelWeight < 0)
            {
                Console.WriteLine("Weight must be above 0. Please enter a valid number.");
                weightInput = Console.ReadLine();
            }

            var weightPrice = parcelWeight <= maxWeight ? 0 : (parcelWeight - maxWeight) * 2;
            AddToBasket("Additional Weight Cost", weightPrice);
            weightPrice = 0; // Clear weight price
        }

        public void GetSpeedyShipping(string parcelInput)
        {
            decimal speedyShippingPrice = 0;

            switch (parcelInput)
            {
                case "1":
                    speedyShippingPrice = 3;
                    break;
                case "2":
                    speedyShippingPrice = 8;
                    break;
                case "3":
                    speedyShippingPrice = 15;
                    break;
                case "4":
                    speedyShippingPrice = 25;
                    break;
                case "5":
                    speedyShippingPrice = 50;
                    break;
                default:
                    break;
            }

            AddToBasket("Speedy Shipping", speedyShippingPrice);
        }

        public void GetSmallBasketDiscounts()
        {
            decimal smallParcelDiscount = 0;
            List<decimal> smallParcels = new List<decimal>();
            List<decimal> smallParcelsDiscounted = new List<decimal>();

            for (int i = 0; i <= parcels.Count - 1; i++)
            {
                if (parcels[i].Name == "Small Parcel")
                {
                    smallParcelDiscount += parcels[i].Price + parcels[i + 1].Price + parcels[i + 2].Price;
                    smallParcels.Add(smallParcelDiscount);
                    smallParcelDiscount = 0;
                    i += 2;
                }
            }

            var orderedList = smallParcels.OrderBy(x => x).ToList();
            var noOfDiscounts = orderedList.Count / 4;

            for (int i = 0; i <= noOfDiscounts - 1; i++)
                AddToBasket("4th Small Parcel Discount", -Math.Abs(orderedList[i]));
        }

        public void ClearSmallParcelDiscounts()
        {
            foreach (var p in parcels.ToList())
            {
                if (p.Name == "4th Small Parcel Discount")
                    parcels.Remove(p);
            }
        }

        public void GetMediumBasketDiscounts()
        {
            decimal mediumParcelDiscount = 0;
            List<decimal> mediumParcels = new List<decimal>();
            List<decimal> mediumParcelsDiscounted = new List<decimal>();

            for (int i = 0; i <= parcels.Count - 1; i++)
            {
                if (parcels[i].Name == "Medium Parcel")
                {
                    mediumParcelDiscount += parcels[i].Price + parcels[i + 1].Price + parcels[i + 2].Price;
                    mediumParcels.Add(mediumParcelDiscount);
                    mediumParcelDiscount = 0;
                    i += 2;
                }
            }

            var orderedList = mediumParcels.OrderBy(x => x).ToList();
            var noOfDiscounts = orderedList.Count / 3;

            for (int i = 0; i <= noOfDiscounts - 1; i++)
                AddToBasket("3rd Medium Parcel Discount", -Math.Abs(orderedList[i]));
        }

        public void ClearMediumParcelDiscounts()
        {
            foreach (var p in parcels.ToList())
            {
                if (p.Name == "3rd Medium Parcel Discount")
                    parcels.Remove(p);
            }
        }

        public void Clear()
        {
            parcels.Clear();
        }
    }
}
