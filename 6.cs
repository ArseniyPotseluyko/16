using System;
using System.IO;
using System.Linq;

class Program
{
    static void Main()
    {
        string filePath = "words.txt"; // Исходный файл с текстом
        char startLetter = 'A'; // Заданная буква для поиска
        int wordLength = 5; // Заданная длина слова

        try
        {
            // Чтение слов из файла
            string[] words = File.ReadAllText(filePath)
                                 .Split(new[] { ' ', '\n', '\r', ',', '.', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);

            // 1️⃣ Слова, начинающиеся на заданную букву
            var startWithLetter = words.Where(w => w.StartsWith(startLetter.ToString(), StringComparison.OrdinalIgnoreCase));
            Console.WriteLine($"Слова, начинающиеся на '{startLetter}': {string.Join(", ", startWithLetter)}");

            // 2️⃣ Слова, длина которых равна заданному числу
            var specificLengthWords = words.Where(w => w.Length == wordLength);
            Console.WriteLine($"Слова длиной {wordLength} символов: {string.Join(", ", specificLengthWords)}");

            // 3️⃣ Слова, начинающиеся и заканчивающиеся одной буквой
            var sameStartEndWords = words.Where(w => w.Length > 1 && w.First() == w.Last());
            Console.WriteLine($"Слова, начинающиеся и заканчивающиеся одной буквой: {string.Join(", ", sameStartEndWords)}");

            // 4️⃣ Слова, начинающиеся на ту же букву, что и последнее слово
            if (words.Length > 0)
            {
                char lastWordStart = words.Last().First();
                var sameAsLastWord = words.Where(w => w.StartsWith(lastWordStart.ToString(), StringComparison.OrdinalIgnoreCase));
                Console.WriteLine($"Слова, начинающиеся на ту же букву, что и последнее слово '{lastWordStart}': {string.Join(", ", sameAsLastWord)}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
    }
}
