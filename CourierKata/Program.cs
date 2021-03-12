using System;
using System.Collections.Generic;
using System.Linq;

namespace CourierKata
{
    class Program
    {
        public static void Main()
        {
            Basket basket = new Basket();
            List<decimal> smallParcelDiscount = new List<decimal>();
            List<decimal> mediumParcelDiscount = new List<decimal>();

            bool stillAddingParcels = true;
            bool sDiscountApplied = false;
            bool mDiscountApplied = false;
            decimal totalPrice = 0;
            int sParcelCount = 0;
            int mParcelCount = 0;
            int lParcelCount = 0;
            int xlParcelCount = 0;
            int hParcelCount = 0;

            while (stillAddingParcels)
            {
                Console.Clear();
                Console.WriteLine("Welcome to our new CourierABC system. What would you like to do?");
                Console.WriteLine("Type 'add' to add a new parcel in yoru basket.");
                Console.WriteLine("Type 'view' to view parcels in your basket and the total price.");
                Console.WriteLine("Type 'clear' to clear your basket.");
                Console.WriteLine("Type 'exit' to quit the system.");

                string menuInput = Console.ReadLine().ToLower();
                Console.Clear();

                switch (menuInput)
                {
                    case "add":
                        {
                            Console.WriteLine("Please enter the number of the parcel you wish to add to the basket.");
                            Console.WriteLine("1 - Small Parcel (< 10cm, < 1KG), $3");
                            Console.WriteLine("2 - Medium Parcel (< 50cm, < 3KG), $8");
                            Console.WriteLine("3 - Large Parcel (< 100cm, < 6KG), $15");
                            Console.WriteLine("4 - XL Parcel (> 100cm, < 10KG), $25");
                            Console.WriteLine("5 - Heavy Parcel (< 50KG), $50");
                            Console.WriteLine("An additional $2 will be added for each Kg is the parcel is over the corresponded weight.");

                            string parcelInput = Console.ReadLine();

                            switch (parcelInput)
                            {
                                case "1":
                                    Console.WriteLine("Parcel Added");
                                    basket.AddToBasket("Small Parcel", 3);
                                    sParcelCount++;
                                    basket.ClearSmallParcelDiscounts();
                                    sDiscountApplied = false;
                                    break;
                                case "2":
                                    Console.WriteLine("Parcel Added");
                                    basket.AddToBasket("Medium Parcel", 8);
                                    mParcelCount++;
                                    basket.ClearMediumParcelDiscounts();
                                    mDiscountApplied = false;
                                    break;
                                case "3":
                                    Console.WriteLine("Parcel Added");
                                    basket.AddToBasket("Large Parcel", 15);
                                    lParcelCount++;
                                    break;
                                case "4":
                                    Console.WriteLine("Parcel Added");
                                    basket.AddToBasket("XL Parcel", 25);
                                    xlParcelCount++;
                                    break;
                                case "5":
                                    Console.WriteLine("Parcel Added");
                                    basket.AddToBasket("Heavy Parcel", 50);
                                    hParcelCount++;
                                    break;
                                default:
                                    Console.WriteLine("Wrong input. Please press enter and try again.");
                                    Console.Read();
                                    break;
                            }

                            // Parcel Weight
                            Console.WriteLine("What is the weight of the parcel?");
                            var weightInput = Console.ReadLine();
                            basket.GetParcelWeight(parcelInput, weightInput);

                            // Speedy Shipping
                            Console.WriteLine("Would you like to add speedy shipping? (Reply with a yes or no)");
                            Console.WriteLine("This will cost double the price of the parcel.");
                            string speedyShippingInput = Console.ReadLine().ToLower();

                            while (speedyShippingInput != "yes" && speedyShippingInput != "no")
                            {
                                Console.WriteLine("The output must be either yes or no. Please try again.");
                                speedyShippingInput = Console.ReadLine().ToLower();
                            }

                            if (speedyShippingInput == "yes")
                            {
                                basket.GetSpeedyShipping(parcelInput);
                                Console.WriteLine("Speedy Shipping Added. Press enter to continue.");
                                Console.Read();
                            }
                            else
                            {
                                basket.AddToBasket("Speedy Shipping", 0);
                                Console.WriteLine("Parcel Added with no Speedy Shipping. Press enter to continue.");
                                Console.Read();
                            }
                        }
                        break;
                    case "view":
                        {
                            // Applying Small Parcel Mania Discount
                            while (sParcelCount >= 4 && sDiscountApplied == false)
                            {
                                basket.GetSmallBasketDiscounts();
                                sDiscountApplied = true;
                            }

                            // Applying Medium Parcel Mania Discount
                            while (mParcelCount >= 3 && mDiscountApplied == false)
                            {
                                basket.GetMediumBasketDiscounts();
                                mDiscountApplied = true;
                            }

                            // Printing items in basket
                            foreach (string parcel in basket.GetBasketParcels())
                                Console.WriteLine(parcel);

                            totalPrice = 0; // Reset Price

                            // Basket Calculation
                            totalPrice = basket.GetBasketTotalPrice();

                            // Viewing Total Price
                            if (totalPrice != 0)
                            {
                                Console.WriteLine("----------");
                                Console.WriteLine("Total Price For Parcels: $" + totalPrice);
                                Console.WriteLine("Press enter to continue");
                                Console.ReadLine();
                                break;
                            }
                            else
                            {
                                Console.WriteLine("No items added in basket.");
                                Console.WriteLine("Press enter to continue");
                                Console.ReadLine();
                            }

                            break;
                        }
                    case "clear":
                        basket.Clear();
                        sParcelCount = 0;
                        mParcelCount = 0;
                        lParcelCount = 0;
                        xlParcelCount = 0;
                        hParcelCount = 0;
                        Console.WriteLine("Basket Cleared.");
                        Console.WriteLine("Press enter to continue");
                        Console.ReadLine();
                        break;
                    case "exit":
                        stillAddingParcels = false;
                        break;
                    default:
                        Console.WriteLine("Please select one of the above options.");
                        break;

                }
            }
        }
    }
}
