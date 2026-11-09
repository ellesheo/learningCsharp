namespace CP37_linq_zaprosi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new()
            {
                new Student(1, "Иванов"),
                new Student(2, "Петрова"),
                new Student(3, "Сидоров"),
                new Student(4, "Кузнецова"),
                new Student(5, "Смирнов")
            };

            List<Enrollment> enrollments = new()
            {
                new Enrollment(1, Course.Math, 5),
                new Enrollment(1, Course.Physics, 4),
                new Enrollment(1, Course.History, 3),
                new Enrollment(2, Course.Math, 4),
                new Enrollment(2, Course.Physics, 5),
                new Enrollment(3, Course.Math, 3),
                new Enrollment(3, Course.Physics, 4),
                new Enrollment(3, Course.History, 5),
                new Enrollment(4, Course.Math, 5),
                new Enrollment(4, Course.Physics, 3),
                new Enrollment(4, Course.History, 5)
            };

            Console.WriteLine("После Join");
            Console.WriteLine();
            PrintPairs(students, enrollments);

            Console.WriteLine();
            Console.WriteLine("Итог по курсам");
            Console.WriteLine();
            PrintReport(students, enrollments);

            Console.WriteLine();
            Console.WriteLine("Своя запись. Впишите порядковый номер ученика, курс и оценку (например, 1, Math, 5)");
            Console.WriteLine();

            enrollments.Add(ReadEnrollment(students));

            Console.WriteLine();
            Console.WriteLine("Итог заново");
            Console.WriteLine();
            PrintReport(students, enrollments);
        }

        static void PrintPairs(List<Student> students, List<Enrollment> enrollments)
        {
            var pairs = students
                .Join(enrollments,
                      student => student.Id,
                      enrollment => enrollment.StudentId,
                      (student, enrollment) => new { student.Name, enrollment.Course, enrollment.Grade });

            foreach (var pair in pairs)
                Console.WriteLine($"{pair.Name} - {pair.Course} - {pair.Grade}");
        }

        static void PrintReport(List<Student> students, List<Enrollment> enrollments)
        {
            var report = students
                .Join(enrollments,
                      student => student.Id,
                      enrollment => enrollment.StudentId,
                      (student, enrollment) => new { student.Name, enrollment.Course, enrollment.Grade })
                .GroupBy(row => row.Course)
                .Select(group => new
                {
                    Course = group.Key,
                    Average = group.Average(row => row.Grade),
                    Students = group.Select(row => row.Name).Distinct().Count()
                })
                .OrderByDescending(row => row.Average);

            foreach (var row in report)
                Console.WriteLine($"{row.Course}: балл {row.Average:0.00} ({Label(row.Average)}), студентов {row.Students}");
        }

        static string Label(double average) => average switch
        {
            >= 4.5 => "отлично",
            >= 4 => "хорошо",
            >= 3 => "средне",
            _ => "плохо"
        };

        static Enrollment ReadEnrollment(List<Student> students)
        {
            while (true)
            {
                Console.Write("Запись (1, Math, 5): ");

                try
                {
                    return ParseEnrollment(Console.ReadLine() ?? "", students);
                }
                catch (InvalidEnrollmentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        static Enrollment ParseEnrollment(string line, List<Student> students)
        {
            string[] parts = line.Split(',');

            if (parts.Length != 3)
                throw new InvalidEnrollmentException("Нужно три поля: 1, Math, 5");

            if (!int.TryParse(parts[0].Trim(), out int id) || !students.Any(student => student.Id == id))
                throw new InvalidEnrollmentException($"Нет студента {parts[0].Trim()}. Есть 1-5");

            if (!Enum.TryParse(parts[1].Trim(), true, out Course course) || !Enum.IsDefined(typeof(Course), course))
                throw new InvalidEnrollmentException($"Нет курса {parts[1].Trim()}. Есть Math, Physics, History");

            if (!int.TryParse(parts[2].Trim(), out int grade) || grade < 2 || grade > 5)
                throw new InvalidEnrollmentException("Оценка от 2 до 5");

            return new Enrollment(id, course, grade);
        }
    }
}