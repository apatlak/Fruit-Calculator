using System;
using System.Collections.Generic;
using System.Linq;

namespace Fruit_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            // Read Items List
            var items = new Basket().GetLineitems();
            // Loop through input items
            foreach (KeyValuePair<int, string> item in items)
            {
                //Write Out the input line being processed
                Console.WriteLine("Input : " + item.Value);

                //Validate Input is in Proper Format
                if (!InputValidator.IsLineItemValid(item.Value.ToUpper()))
                {
                    Console.WriteLine(string.Format("Line Item {0} is not in the proper format."), item.Key);
                }

                //Validate Fruit Items have proper values
                if (!InputValidator.IsFruitInputDollarPairingValid(item.Value.ToUpper()))
                {
                    Console.WriteLine(string.Format("Line Item {0} does not have fruit cost provided properly."), item.Key);
                }

                //Validate Bakset has proper values
                if (!InputValidator.IsBasketValid(item.Value.ToUpper()))
                {
                    Console.WriteLine(string.Format("Line Item " + item.Key + " does not have basket items provided properly."));
                }

                //Calculate Basket
                int total = 0;
                //Setup Dictionary for Basket
                var fruitQuantityInBasket = item.Value.ToUpper().Split(':')[2];
                var dictBasketFruitQuantity = FruitToValueConverter.StandardizeBasketFormat(fruitQuantityInBasket);
                //Setup Dictionary for fruit prices
                var costPerFruit = item.Value.ToUpper().Split(':')[0];
                var dictFruitPrices= FruitToValueConverter.StandardizePricingFormat(costPerFruit);

                //Setup Dictionary for provided discounts
                var fruitCostDiscount = item.Value.ToUpper().Split(':')[1];              
                var dictfruitCostDiscount = FruitToValueConverter.PopulateDiscount(fruitCostDiscount);


                //for each baket item get total price for that fruit and add to total
                foreach (var fruitItem in dictBasketFruitQuantity)
                {
                    
                    // Get Price 
                    // Would add a check to make sure a fruit is a valid fruit based on a dataset of all fruits available for this applications dataset
                    int fruitPrice = FruitToValueConverter.GetFruitPrice(fruitItem.Key, dictFruitPrices);
                    //Get Adjusted Discounted Price
                    fruitPrice = (int)(fruitPrice * FruitToValueConverter.GetFruitDiscountedPrice(fruitItem.Key, dictfruitCostDiscount));
                    //Multiply
                    int fruitCostInBasket = fruitPrice * FruitToValueConverter.GetFruitQuanity(fruitItem.Key, dictBasketFruitQuantity);
                    //add to total
                    total = total + fruitCostInBasket;

                }
                Console.WriteLine("Output: Total Price= " + total);
            }

        }


    }
}

