namespace CP10_var2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<IAnimal> animals = new List<IAnimal>();

            try
            {
                animals.Add(new Lion(ReadName("Имя льва: ")));
            }
            catch (InvalidAnimalException ex)
            {
                Console.WriteLine($"Лев не создан. {ex.Message}");
            }

            try
            {
                animals.Add(new Dog(ReadName("Имя собаки: ")));
            }
            catch (InvalidAnimalException ex)
            {
                Console.WriteLine($"Собака не создана. {ex.Message}");
            }

            try
            {
                animals.Add(new Dolphin(ReadName("Имя дельфина: ")));
            }
            catch (InvalidAnimalException ex)
            {
                Console.WriteLine($"Дельфин не создан. {ex.Message}");
            }

            Console.WriteLine();

            foreach (IAnimal animal in animals)
            {
                Console.WriteLine(animal);
                animal.MakeSound();

                if (animal is ITrainable trainable)
                    Console.WriteLine(trainable.Train());

                Console.WriteLine();
            }
        }

        static string ReadName(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine() ?? "";
        }
    }
}