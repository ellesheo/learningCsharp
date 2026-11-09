namespace CP29_obobshennie_interfeisi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ковариантный интерфейс");
            Console.WriteLine();

            IContainer<Animal> dogBox = new Box<Dog>(new Dog { Name = "Рекс" });
            IContainer<Animal> catBox = new Box<Cat>(new Cat { Name = "Муся" });

            Console.WriteLine($"Box<Dog> как IContainer<Animal>: {dogBox.GetItem()}, тип {dogBox.GetItem().GetType().Name}");
            Console.WriteLine($"Box<Cat> как IContainer<Animal>: {catBox.GetItem()}, тип {catBox.GetItem().GetType().Name}");

            Console.WriteLine();
            Console.WriteLine($"в первой коробке: {Describe(dogBox)}");
            Console.WriteLine($"во второй коробке: {Describe(catBox)}");

            // Box<Animal> wrong = new Box<Dog>(new Dog());
            // так нельзя: Box<Dog> это не Box<Animal> (CS0029)

            // в IContainer<out T> нельзя дописать void SetItem(T item)
            // при out тип T можно только возвращать, а не принимать (CS1961)

            Console.WriteLine();
            Console.WriteLine("Свой ввод");
            Console.WriteLine();

            Animal own = ReadAnimal();

            IContainer<Animal> ownBox = own switch
            {
                Dog d => new Box<Dog>(d),
                Cat c => new Box<Cat>(c),
                _ => new Box<Animal>(own)
            };

            Console.WriteLine($"в коробке: {Describe(ownBox)}, тип {ownBox.GetItem().GetType().Name}");
        }

        static string Describe(IContainer<Animal> container) => container.GetItem() switch
        {
            Dog d => $"собака по имени {d.Name}",
            Cat c => $"кошка по имени {c.Name}",
            Animal a => $"зверь по имени {a.Name}",
            _ => "пусто"
        };

        static Animal ReadAnimal()
        {
            while (true)
            {
                Console.Write("Кого в коробку (dog, Рекс): ");

                try
                {
                    return ParseAnimal(Console.ReadLine() ?? "");
                }
                catch (InvalidAnimalException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        static Animal ParseAnimal(string line)
        {
            string[] parts = line.Split(',');

            if (parts.Length != 2)
                throw new InvalidAnimalException("Нужно два поля через запятую, например: dog, Рекс");

            string kindText = parts[0].Trim();
            string name = parts[1].Trim();

            if (name.Length == 0)
                throw new InvalidAnimalException("Имя пустое");

            if (!Enum.TryParse(kindText, true, out AnimalKind kind) || !Enum.IsDefined(typeof(AnimalKind), kind))
                throw new InvalidAnimalException($"\"{kindText}\" - не dog и не cat");

            return kind switch
            {
                AnimalKind.Dog => new Dog { Name = name },
                AnimalKind.Cat => new Cat { Name = name },
                _ => throw new InvalidAnimalException("неизвестный вид")
            };
        }
    }
}