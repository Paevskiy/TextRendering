using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;


namespace TextRendering
{
    using System.IO;
    using System.Text.RegularExpressions;
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Скачиваем файл из интернет");
            var webClient=new WebClient();
            webClient.Encoding = Encoding.GetEncoding(1251);
            // сталин о экономике СССР
            var text = webClient.DownloadString(@"http://www.e-reading.club/txt.php/1028031/%D0%A1%D1%82%D0%B0%D0%BB%D0%B8%D0%BD_-_%D0%AD%D0%BA%D0%BE%D0%BD%D0%BE%D0%BC%D0%B8%D1%87%D0%B5%D1%81%D0%BA%D0%B8%D0%B5_%D0%BF%D1%80%D0%BE%D0%B1%D0%BB%D0%B5%D0%BC%D1%8B_%D1%81%D0%BE%D1%86%D0%B8%D0%B0%D0%BB%D0%B8%D0%B7%D0%BC%D0%B0_%D0%B2_%D0%A1%D0%A1%D0%A1%D0%A0.txt");
            //Война и мир
            //var text = webClient.DownloadString("http://vojnaimir.ru/files/book1.txt");
            File.WriteAllText("StringText.txt", text);
            // разбиваем текст на предложения
            var CentensesRegex= new Regex("[А-ЯA-Z]((т.п.|т.д.|пр.)|[^?!.\\(]|\\([^\\)]*\\))*[.?!]");
            var StringCollection = CentensesRegex.Matches(text)
                .OfType<Match>()
                .Select(s => s.Value)
                .ToList();
            File.WriteAllLines("StringCollection.txt", StringCollection);
            // вывод на экран массива строк(предложений)
            //for (int item = 0; item < StringCollection.Count; item++)
            //{
            //    Console.WriteLine(StringCollection[item]);
            //}
            //Разбиваем текст на слова
            var WordsRegex = new Regex("\\w+?\\b");
            var WordsCollection = WordsRegex.Matches(text)
                .OfType<Match>()
                .Select(s => s.Value)
                .ToList();
            File.WriteAllLines("WordsCollection.txt", WordsCollection);
        }
    }
}
