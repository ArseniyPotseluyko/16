using System;
using System.IO;

class Program
{
    static void Main()
    {
        string drive = "D:\\";  // Укажите диск (например, "C:\\" или "D:\\")
        string targetFolder = Path.Combine(drive, "Exmple_36tp");
        string sourceFolder = "D:\\SourceFolder"; // Исходный каталог с файлами

        // 1️⃣ Вывести список всех файлов на диске
        Console.WriteLine($"Файлы на диске {drive}:");
        foreach (string file in Directory.GetFiles(drive, "*.*", SearchOption.AllDirectories))
        {
            Console.WriteLine(file);
        }

        // 2️⃣ Создать каталог "Exmple_36tp"
        if (!Directory.Exists(targetFolder))
        {
            Directory.CreateDirectory(targetFolder);
            Console.WriteLine($"Каталог '{targetFolder}' создан.");
        }

        // 3️⃣ Скопировать 3 файла из другого каталога
        string[] filesToCopy = Directory.GetFiles(sourceFolder).Take(3).ToArray();
        foreach (string file in filesToCopy)
        {
            string destFile = Path.Combine(targetFolder, Path.GetFileName(file));
            File.Copy(file, destFile, true);
            Console.WriteLine($"Файл '{file}' скопирован в '{destFile}'.");
        }

        // 4️⃣ Поменять атрибуты файлов на "Скрытый"
        foreach (string file in Directory.GetFiles(targetFolder))
        {
            File.SetAttributes(file, FileAttributes.Hidden);
            Console.WriteLine($"Файл '{file}' стал скрытым.");
        }

        // 5️⃣ Создать файлы ссылок на скрытые файлы
        foreach (string file in Directory.GetFiles(targetFolder))
        {
            string shortcutFile = file + ".lnk";
            using (StreamWriter writer = new StreamWriter(shortcutFile))
            {
                writer.WriteLine($"Ссылка на: {file}");
            }
            Console.WriteLine($"Создан файл-ссылка: {shortcutFile}");
        }

        Console.WriteLine("Все операции успешно выполнены!");
    }
}
