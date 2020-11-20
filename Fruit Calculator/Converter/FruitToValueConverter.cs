using System;
using System.Collections.Generic;
using System.Text;

namespace Fruit_Calculator
{
    internal static class FruitToValueConverter
    {
        internal static int  GetFruitQuanity(string key, Dictionary<string, int> fruitQuantity)
        {
            int quantity = fruitQuantity[key];
            return quantity;
        }

       

        internal static double GetFruitDiscountedPrice(string key, Dictionary<string, double> fruitDiscount)
        {
            if (fruitDiscount.ContainsKey(key))
            {
                return fruitDiscount[key];
            }

            return 1;
        }

        internal static int GetFruitPrice(string key, Dictionary<string, int> dictfruitCost)
        {
            if (dictfruitCost.ContainsKey(key))
            {
                return dictfruitCost[key];
            }
            else

            {
                Console.WriteLine("Item Price missing for " + key);
                throw new Exception("Missing Price for" + key);
            }
        }


        internal static  Dictionary<string, int> StandardizeBasketFormat(string basketItem)
        {
            try
            {
                Dictionary<string, int> basket = new Dictionary<string, int>();
                var FruitDollarPairing = basketItem.Split(',');
                foreach (string fruitItem in FruitDollarPairing)
                {
                    var FruitValuePair = fruitItem.Split(new char[] { '-', ' ' })[1];
                    //Validate Fruit has a value
                    int i = 0;
                    var value = fruitItem.Split(new char[] { '-' });
                    if (value.Length == 1)
                    {
                        value = value[0].Trim().Split(' ');
                    }
                    bool result = int.TryParse(value[1], out i);
                    if (result)
                    {
                        basket.Add(value[0].Trim().ToUpper(), int.Parse(value[1]));
                    }

                }
                return basket;

            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }

        internal static Dictionary<string, double> PopulateDiscount(string fruitCostDiscount)
        {
            Dictionary<string, double> discounts = new Dictionary<string, double>();
            var fruitDiscountPairing = fruitCostDiscount.ToUpper().Replace("BASKET","").Split(':')[0].Split(';');
            if(fruitDiscountPairing[0].ToUpper().IndexOf("NO")>0)
            {
                return discounts;
            }
            foreach (string fruitItem in fruitDiscountPairing)
            {
               if(!string.IsNullOrWhiteSpace(fruitItem))
                {
                    var FruitValuePair = fruitItem.Split('–')[1];
                    //Validate Fruit has a value
                    double i = 0;
                    var value = fruitItem.Split('–');
                    if (value.Length == 1)
                    {
                        value = value[0].Trim().Split(' ');
                    }
                    bool result = double.TryParse(value[1], out i);
                    if (result)
                    {
                        discounts.Add(value[0].Trim().ToUpper(), double.Parse(value[1]));
                    }


                }
               

            }
            return discounts;
        }

        internal static Dictionary<string, int> StandardizePricingFormat(string basketItem)
        {
            try
            {
                Dictionary<string, int> itemPrices = new Dictionary<string, int>();
                var FruitDollarPairing = basketItem.Split(':')[0].Split(';');
                foreach (string fruitItem in FruitDollarPairing)
                {
                    var FruitCostPair = fruitItem.Split('–');
                    //Validate Fruit has a value
                    int i = 0;
                    if (FruitCostPair[0].ToUpper().IndexOf("PROMOTIONS") == -1)
                    {
                        bool result = int.TryParse(FruitCostPair[1].Replace("$", String.Empty), out i);
                        if (result)
                        {
                            itemPrices.Add(FruitCostPair[0].Trim(), int.Parse(FruitCostPair[1].Replace("$", String.Empty)));
                        }
                    }

                }
       
                return itemPrices;

            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }
    }
}
