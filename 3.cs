using System;
using System.IO;
using System.Linq;

class Program
{
    static void Main()
    {
        string filePath = "textfile.txt";
        string newFilePath = "new_textfile.txt";
        char startLetter = 'A'; // Укажите букву для поиска строк

        // Запись 5 строк в файл
        File.WriteAllLines(filePath, new string[]
        {
            "Hello, world!",
            "C# programming",
            "This is a test file",
            "AI helps developers",
            "Last line in file"
        });

        // a) Вывод файла на экран
        string[] lines = File.ReadAllLines(filePath);
        Console.WriteLine("Содержимое файла:");
        foreach (string line in lines)
            Console.WriteLine(line);

        // b) Подсчёт количества строк
        Console.WriteLine($"\nКоличество строк: {lines.Length}");

        // c) Подсчёт символов в каждой строке
        Console.WriteLine("\nКоличество символов в каждой строке:");
        foreach (string line in lines)
            Console.WriteLine($"{line}: {line.Length} символов");

        // d) Удаление последней строки и запись в новый файл
        File.WriteAllLines(newFilePath, lines.Take(lines.Length - 1));
        Console.WriteLine("\nПоследняя строка удалена, новый файл создан.");

        // e) Вывод строк с s1 по s2 (пример: 2-я по 4-ю строку)
        int s1 = 1, s2 = 3; // Индексы начинаются с 0
        Console.WriteLine($"\nСтроки с {s1 + 1}-й по {s2 + 1}-ю:");
        for (int i = s1; i <= s2 && i < lines.Length; i++)
            Console.WriteLine(lines[i]);

        // f) Поиск самой длинной строки
        string longest = lines.OrderByDescending(l => l.Length).First();
        Console.WriteLine($"\nСамая длинная строка ({longest.Length} символов): {longest}");

        // g) Вывод строк, начинающихся с заданной буквы
        Console.WriteLine($"\nСтроки, начинающиеся с '{startLetter}':");
        foreach (string line in lines.Where(l => l.StartsWith(startLetter.ToString())))
            Console.WriteLine(line);

        // h) Запись строк в новый файл в обратном порядке
        File.WriteAllLines("reversed_textfile.txt", lines.Reverse());
        Console.WriteLine("\nФайл с обратным порядком строк создан.");
    }
}
