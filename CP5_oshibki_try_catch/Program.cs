using System.Collections;

namespace CP5_oshibki_try_catch
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var config = new Dictionary<string, string>();
            config["timeout"] = "30";
            config["retries"] = "тридцать";
            var converter = new ConfigConverter();
            Console.WriteLine("ключ есть и значение корректно");
            Console.WriteLine(converter.GetInt(config, "timeout"));
            Console.WriteLine();
            Console.WriteLine("ключа нет");
            Show(converter, config, "missing");
            Console.WriteLine();
            Console.WriteLine("значение некорректно");
            Show(converter, config, "retries");
        }

        static void Show(ConfigConverter converter, Dictionary<string, string> config, string key)
        {
            try
            {
                Console.WriteLine(converter.GetInt(config, key));
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"Сообщение: {ex.Message}");
                Console.WriteLine($"Исходная причина: {ex.InnerException?.Message}");
                foreach (DictionaryEntry entry in ex.Data)
                    Console.WriteLine($"  {entry.Key}: {entry.Value}");
            }
        }
    }
}