using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Strings.Homework
{
    static class WorkingWithAFiles
    {

        private static string _path = @"C:\C#\Strings.Homework\Strings.Homework\input.txt";

        public static string WtiteToString()
        {
            string? Text = null;
            string WritingText;

            using (FileStream file = new FileStream(_path, FileMode.OpenOrCreate))
            {
                while (Text == null) 
                {
                    switch (file.Length)
                    {
                        case > 0:
                            using (StreamReader a = new StreamReader(file))
                                Text = a.ReadToEnd();
                            Text = Text.Replace("\r\n", ".");
                            break;
                        case 0:
                            using (StreamWriter a = new StreamWriter(file))
                            {
                                Console.WriteLine("Данные в файле отсутствуют. Введите их:\n");
                                WritingText = Console.ReadLine();
                                a.Write(WritingText);
                            }
                            break;
                    }
                }
            }

            return Text;
        }

        public static void DisplayStartText()
        {
            string path = @"C:\C#\Strings.Homework\Strings.Homework\startText.txt";
            string startText;

            using (FileStream file = new FileStream(path, FileMode.Open))
            {
                using (StreamReader a = new StreamReader(file))
                    startText = a.ReadToEnd();
            }

            Console.WriteLine(startText);
        }

        public static void ReplaceNumbers(ref string Text) 
        { 
            StringBuilder FixText = new StringBuilder(Text);

            for (int i = 0; i < FixText.Length; i++)
            {
                switch(FixText[i])
                {
                    case '0':
                        FixText.Replace(FixText[i].ToString(), "ноль");
                        break;
                    case '1':
                        FixText.Replace(FixText[i].ToString(), "один");
                        break;
                    case '2':
                        FixText.Replace(FixText[i].ToString(), "два");
                        break;
                    case '3':
                        FixText.Replace(FixText[i].ToString(), "три");
                        break;
                    case '4':
                        FixText.Replace(FixText[i].ToString(), "четыре");
                        break;
                    case '5':
                        FixText.Replace(FixText[i].ToString(), "пять");
                        break;
                    case '6':
                        FixText.Replace(FixText[i].ToString(), "шесть");
                        break;
                    case '7':
                        FixText.Replace(FixText[i].ToString(), "семь");
                        break;
                    case '8':
                        FixText.Replace(FixText[i].ToString(), "восемь");
                        break;
                    case '9':
                        FixText.Replace(FixText[i].ToString(), "девять");
                        break;
                }
            }
            Text = FixText.ToString();
        }

        public static void WriteToFile(in string Text)
        {
            using (StreamWriter sw = new StreamWriter(_path))
            {
                sw.Flush();
                sw.WriteLine(Text);
            }
        }
    }
}



