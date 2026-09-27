using System;
using System.Collections.Generic;
using System.Text;

namespace CP6_trycatch_addition
{
    public class NumberParser
    {
        public int SumValidNumbers(List<string> values)
        {
            int sum = 0;
            int processed = 0;
            foreach (string value in values)
            {
                try
                {
                    sum += int.Parse(value);
                }
                catch (FormatException ex) when (string.IsNullOrWhiteSpace(value))
                {
                }
                catch (FormatException ex)
                {
                    Console.WriteLine($"{value} не число");
                }
                catch (OverflowException ex)
                {
                    Console.WriteLine($"{value} не влезает в int");
                    throw;
                }
                finally
                {
                    processed++;
                    Console.WriteLine($"обработано {processed}");
                }
            }
            return sum;
        }
    }
}