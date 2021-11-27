using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp4
{
    class Dynamic_Programming
    {
        //{1,2,5}  11
        public static int CoinChange(int[] coins, int amount)
        {
            Array.Sort(coins);
            return Coin(coins, amount, 2);
        }
        public static int Coin(int[] coins, int amount, int index)
        {
            if (amount == 0)
            {
                return 0;
            }
            if (index < 0)
            {
                return -1;
            }
            if (index == 0)
            {
                if(amount%coins[index] != 0)
                {
                    return -1;
                }
            }

            int maxFrequency = amount / coins[index];
            int minVal = Int32.MaxValue;
            for (int i= 0; i <= maxFrequency; i++)
            {
                int remainingAmount = amount - i * coins[index];
                int res = i + Coin(coins, remainingAmount, index-1);
                if(res != -1)
                {
                    minVal = Math.Min(minVal, res);
                }
            }

            return minVal;
        }
    }
}
