using CsvHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Words
{
    class Program
    {
        /// <summary>
        /// в аргумент передается путь до файла с текстом, если файл существует происходит считывание иначе просто конец работы.
        /// 
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            
            if (args.Length == 0)
            {
                Console.WriteLine("Нужно задать путь до файла с текстом, иначе негде будет искать...");
                return;
            }

            Help();
            var filepath = args[0];

            if (File.Exists(filepath))
            {
                // забрать текст
                Console.WriteLine("Здесь я получаю текст");

                string[] textFile = File.ReadAllLines(filepath);

                var testText = String.Join(" ", textFile);

                string text = testText;

                string searchWord = null;

                while (string.IsNullOrEmpty(searchWord))
                {
                    Console.Write("Введите слово или слова через запятую , которое(которые) будем искать: ");
                    searchWord = Console.ReadLine();

                }

                var searchWords = searchWord.Split(',');

                var itemsForSearch = text.Split(new char[] { ' ', ',', '.', ':', '!', '?' }).Where(e => e != string.Empty);

                var result = new List<ItemCsv>();

                foreach (var word in searchWords)
                {
                    var wordCount = itemsForSearch.Where(e => e.Equals(word)).Count();

                    result.Add(new ItemCsv(word, wordCount));
                }

                if (result.Any())
                {

                    using (var writer = new StreamWriter($"{DateTime.Now.ToString("ddMMyyyyhhmmss")}.csv", false, Encoding.UTF8))
                    using (var csv = new CsvWriter(writer))
                    {
                        csv.WriteRecords<ItemCsv>(result);

                        Console.WriteLine($"Данные записаны в файл {searchWord}.csv");
                    }

                }
                else
                {
                    Console.WriteLine("Поиск не дал результатов.");
                }
            }
            else
            {
                Console.WriteLine("Файла не существует. Укажите путь к существующему файлу с текстом.");
            }

            //Console.ReadKey();
        }

        public static void DoWork()
        {

        }

        public static void Help()
        {
            Console.WriteLine("Подсказка:");
            Console.WriteLine("Чтобы задать путь до файла напишите C:/test.txt");
            Console.WriteLine("если файл находится в папке с приложением просто укажите имя файла");
        }
    }
}
