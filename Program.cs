using System;
using System.IO;

class Program
{
    static void Main()
    {
        string folderPath = "New_folder";

        // Проверяем существование папки
        if (!Directory.Exists(folderPath))
        {
            Directory.CreateDirectory(folderPath);
            Console.WriteLine($"Папка '{folderPath}' успешно создана!");
        }
        else
        {
            Console.WriteLine($"Папка '{folderPath}' уже существует.");
        }
    }
}
