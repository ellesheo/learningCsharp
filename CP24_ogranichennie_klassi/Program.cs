namespace CP24_ogranichennie_klassi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Repository<Product> products = new();
            products.Add(new Product { Id = 1, Name = "Клавиатура" });
            products.Add(new Product { Id = 2, Name = "Мышь" });

            Repository<Customer> customers = new();
            customers.Add(new Customer { Id = 10, Email = "anna@mail.ru" });
            customers.Add(new Customer { Id = 11, Email = "boris@mail.ru" });

            Console.WriteLine("Проверочные ключи:");
            Console.WriteLine();
            Console.WriteLine($"Товаров в репозитории: {products.Count}, клиентов: {customers.Count}");
            Console.WriteLine();

            Show(products, 1);
            Show(products, 2);
            Show(products, 99);
            Show(customers, 10);
            Show(customers, 11);
            Show(customers, 99);

            Console.WriteLine();
            Console.WriteLine("Попытка добавить товар с уже занятым Id:");

            try
            {
                products.Add(new Product { Id = 1, Name = "Вторая клавиатура" });
            }
            catch (DuplicateIdException ex)
            {
                Console.WriteLine($"ошибка: {ex.Message}");
            }

            Console.WriteLine();
            Console.WriteLine("Свой поиск:");
            Console.WriteLine();

            Show(products, ReadId("Введите Id товара (есть 1 и 2): "));
            Show(customers, ReadId("Введите Id клиента (есть 10 и 11): "));
        }

        static void Show<T>(Repository<T> repository, int id) where T : Entity
        {
            T? found = repository.GetById(id);

            Console.WriteLine(found switch
            {
                null => $"Id {id} - ничего не найдено (null)",
                _ => $"Id {id} - {found}"
            });
        }

        static int ReadId(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);

                if (int.TryParse((Console.ReadLine() ?? "").Trim(), out int id))
                    return id;

                Console.WriteLine("Это не число, попробуйте ещё раз");
            }
        }
    }
}