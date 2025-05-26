using System;
using System.IO;

class Program
{
    static void Main()
    {
        string inputFile = "input.txt";  // Исходный файл
        string evenFile = "even_lines.txt";  // Файл для четных строк
        string oddFile = "odd_lines.txt";  // Файл для нечетных строк

        try
        {
            string[] lines = File.ReadAllLines(inputFile);

            using (StreamWriter evenWriter = new StreamWriter(evenFile))
            using (StreamWriter oddWriter = new StreamWriter(oddFile))
            {
                for (int i = 0; i < lines.Length; i++)
                {
                    if (i % 2 == 0)
                        evenWriter.WriteLine(lines[i]); // Четные строки (0, 2, 4...)
                    else
                        oddWriter.WriteLine(lines[i]);  // Нечетные строки (1, 3, 5...)
                }
            }

            Console.WriteLine("Файлы успешно созданы!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
    }
}
