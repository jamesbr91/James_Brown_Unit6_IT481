using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment6
{
    class Customer
    {
        int NumberOfItems;

        public Customer()
        {
            NumberOfItems = 6;
        }

        public Customer(int items)
        {
            int ClothingItems = items;

            if (ClothingItems == 0)
            {
                NumberOfItems = GetNumberOfItems(1, 20);
            }
            else
            {
                NumberOfItems = ClothingItems;
            }
        }

        public int getNumberOfItems()
        {
            return NumberOfItems;
        }

        //return the number of items
        public int GetNumberOfItems()
        {
            return NumberOfItems;
        }

        //random number methods
        private static readonly Random getRandom = new Random();
        public static int GetNumberOfItems(int min, int max)
        {
            lock (getRandom) { return getRandom.Next(min, max); }
        }
    }
}
