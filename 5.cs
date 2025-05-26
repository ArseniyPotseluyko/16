using System;
using System.IO;
using System.Linq;

class Program
{
    static void Main()
    {
        string file1 = "f1.dat";
        string file2 = "f2.dat";

        // Создание и запись случайных целых чисел в файлы
        GenerateRandomFile(file1, 10);
        GenerateRandomFile(file2, 10);

        int[] numbers1 = ReadNumbers(file1);
        int[] numbers2 = ReadNumbers(file2);

        // 1️⃣ Найти число, ближайшее к минимальному в f2.dat
        int minValue = numbers2.Min();
        int closestValue = numbers2.OrderBy(x => Math.Abs(x - minValue)).Skip(1).First();
        Console.WriteLine($"Минимальное число в f2.dat: {minValue}, ближайшее к нему: {closestValue}");

        // 2️⃣ Подсчет положительных, отрицательных и нулей в файлах
        CountNumbers(file1);
        CountNumbers(file2);

        // 3️⃣ Проверка упорядоченности f1.dat
        bool isSorted = numbers1.SequenceEqual(numbers1.OrderBy(x => x));
        Console.WriteLine($"Числа в f1.dat упорядочены по возрастанию: {isSorted}");

        // 4️⃣ Проверка знакопеременной последовательности
        bool isAlternating = IsAlternating(numbers1);
        Console.WriteLine($"Числа в f1.dat образуют знакопеременную последовательность: {isAlternating}");
    }

    static void GenerateRandomFile(string filePath, int count)
    {
        Random rand = new Random();
        int[] numbers = Enumerable.Range(0, count).Select(_ => rand.Next(-50, 50)).ToArray();
        File.WriteAllLines(filePath, numbers.Select(x => x.ToString()));
    }

    static int[] ReadNumbers(string filePath)
    {
        return File.ReadAllLines(filePath).Select(int.Parse).ToArray();
    }

    static void CountNumbers(string filePath)
    {
        int[] numbers = ReadNumbers(filePath);
        int positive = numbers.Count(x => x > 0);
        int negative = numbers.Count(x => x < 0);
        int zeros = numbers.Count(x => x == 0);

        Console.WriteLine($"Файл {filePath}: Положительных: {positive}, Отрицательных: {negative}, Нулевых: {zeros}");
    }

    static bool IsAlternating(int[] numbers)
    {
        for (int i = 1; i < numbers.Length; i++)
        {
            if (Math.Sign(numbers[i]) == Math.Sign(numbers[i - 1]))
                return false;
        }
        return true;
    }
}
