using System;
using System.Collections.Generic;
using System.Text;

namespace CP9_oshibki_nadezhno
{
    public class OrderProcessingException : Exception
    {
        public OrderProcessingException() { }
        public OrderProcessingException(string message) : base(message) { }
        public OrderProcessingException(string message, Exception innerException) : base(message, innerException) { }
    }
    public class OrderProcessor
    {
        public void Process(List<string> lines)
        {
            int obrabotano = 0;
            int succes = 0;
            int skipped = 0;
            try
            {
                foreach (string line in lines)
                {
                    obrabotano++;
                    string[] parts = line.Split(';');
                    if (parts.Length != 3 || !decimal.TryParse(parts[1], out decimal price) || !int.TryParse(parts[2], out int quantity))
                    {
                        Console.WriteLine($"Пропущено {line}");
                        skipped++;
                        continue;
                    }
                    try
                    {
                        if (price < 0)
                            throw new OrderProcessingException($"Отрицательная цена: {price}");
                        Console.WriteLine("Заказ {0}: {1} шт по {2}", parts[0], quantity, price);
                        succes++;
                    }
                    catch (OrderProcessingException ex) when (ex.Message.Contains("цена"))
                    {
                        Console.WriteLine(ex.Message);
                        skipped++;
                    }
                }
            }
            finally
            {
                Console.WriteLine($"Обработано: {obrabotano}");
                Console.WriteLine($"Успешно: {succes}");
                Console.WriteLine($"Пропущено: {skipped}");
            }
        }
    }
}