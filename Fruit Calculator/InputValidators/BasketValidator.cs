using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fruit_Calculator
{
    internal static class InputValidator
    {
        internal static bool IsLineItemValid(string basketItem)
        {
            if(basketItem.ToUpper().IndexOf( Basketkeywords.Promotions)==0)
            {
                Console.WriteLine("You need to have Promotions or set Promotions:No");
                return false;
            }
            if (basketItem.ToUpper().IndexOf(Basketkeywords.Basket) == 0)
            {
                Console.WriteLine("You need to have a Basket with items in it provided as your input");
                return false;
            }
            return true;
        }

        internal static bool IsFruitInputDollarPairingValid(string basketItem)
        {
            try
            {
                var FruitDollarPairing = basketItem.Split(':')[0].Split(';');
                foreach (string fruitItem in FruitDollarPairing)
                {
                    var FruitCostPair = fruitItem.Split('–');
                    //Validate Fruit has a value
                    int i = 0;
                    if (FruitCostPair[0].ToUpper().IndexOf("PROMOTIONS") == 0)
                    {
                        bool result = int.TryParse(FruitCostPair[1].Replace("$", String.Empty), out i);
                        if (!result)
                        {
                            Console.WriteLine(String.Format("The fruit {0} does not have a proper numeric value assigned to it.", FruitCostPair[0]));
                            return false;
                        }
                    }

                }
                return true;

            }
            catch (Exception ex)
            {
                return false;
            } 
        }
        internal static bool IsBasketValid(string basketItem)
        {
            try
            {
                var FruitDollarPairing = basketItem.Split(':')[2].Split(',');
                foreach (string fruitItem in FruitDollarPairing)
                {
                    var FruitValuePair = fruitItem.Split(new char[] { '-', ' ' })[1];
                    //Validate Fruit has a value
                    int i = 0;
                    var value = fruitItem.Split(new char[] { '-' });
                    if(value.Length==1)
                    {
                        value = value[0].Trim().Split(' ');
                    }
                    bool result = int.TryParse(value[1], out i);
                    if (!result)
                    {
                        Console.WriteLine(String.Format("The fruit {0} does not have a proper numeric value assigned to it.", FruitValuePair[0]));
                        return false;
                    }

                }
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }

      


    }
}

