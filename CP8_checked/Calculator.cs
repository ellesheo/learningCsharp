using System;
using System.Collections.Generic;
using System.Text;

namespace CP8_checked
{
    public class Calculator
    {
        public int SumChecked(int[] numbers)
        {
            int sum = 0;
            try
            {
                checked
                {
                    foreach (int number in numbers)
                        sum += number;
                }
                return sum;
            }
            catch (OverflowException)
            {
                Console.WriteLine("Сумма превысила диапазон для типа int");
                return int.MaxValue;
            }
        }
        public int ParseOrZero(string input)
        {
            if (int.TryParse(input, out int result))
                return result;
            else
                return 0;
        }
    }
}