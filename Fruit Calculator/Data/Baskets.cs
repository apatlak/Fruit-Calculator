using System;
using System.Collections.Generic;
using System.Text;

namespace Fruit_Calculator
{
    internal class Basket
    {
        private new readonly Dictionary<int, string> _lineItems = new Dictionary<int, string>();
        internal Basket()
        {

            _lineItems.Add(1, "Oranges – $10; Apples – $5 ; Promotions: No; Basket: Oranges - 5, Apples 1");
            _lineItems.Add(2, "Oranges – $10; Apples – $5 ; Promotions: Oranges – 0.5;  Basket: Oranges - 5, Apples 1");
        }

        internal Dictionary<int, string> GetLineitems()
        {
            return _lineItems;
        }



    }
}
