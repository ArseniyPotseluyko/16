using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Zadanie1
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = "f.txt"; // Укажите путь к файлу

            try
            {
                List<double> numbers = new List<double>();

                using (StreamReader reader = new StreamReader(filePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        numbers.Add(Convert.ToDouble(line));
                    }
                }

                if (numbers.Count > 0)
                {
                    double sum = numbers.Sum();
                    double difference = numbers.First() - numbers.Last();

                    Console.WriteLine($"Сумма компонент: {sum}");
                    Console.WriteLine($"Разность первой и последней компонент: {difference}");
                }
                else
                {
                    Console.WriteLine("Файл пуст или содержит некорректные данные.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }
    }
}
