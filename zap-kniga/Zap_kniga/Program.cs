using System;
using System.IO;

namespace Zap_kniga
{
  class Program
  {
    static void Main(string[] args)
    {
      string str1 = "";
      string filename = "data.txt";
      while (str1 != "q")
      {
        Console.WriteLine();
        Console.WriteLine("Введите q для выхода");
        Console.WriteLine("Введите a для добавления записи");
        Console.WriteLine("Введите d для удаления файла");
        Console.WriteLine("Введите p для отображения записи");
        str1 = Console.ReadLine();
        if (str1 == "a")
        {
          Console.WriteLine("Введите строку для добавления в записи");
          str1 = Console.ReadLine();
          if (!File.Exists(filename))
          {
            using (StreamWriter sw = File.CreateText(filename))
            {
              sw.WriteLine(str1);
            }
          }
          else
          {
            using (StreamWriter sw = File.AppendText(filename))
            {
              sw.WriteLine(str1);
            }
          }
        }
        if (str1 == "p")
        {
          if (File.Exists(filename))
          {
            Console.WriteLine("Вот все записи");
            StreamReader sr = new StreamReader(filename);
            string line;
            while ((line = sr.ReadLine()) != null)
            {
              Console.WriteLine(line);
            }
            sr.Close();
          }
          else
          {
            Console.WriteLine("дурак файла нет");
          }
        }
        if (str1 == "d")
        {
          File.Delete(filename);
        }
      }
    }
  }
}
