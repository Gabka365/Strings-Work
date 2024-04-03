using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strings.Homework
{
    static class FindingWords
    {
        public static void FindWordMaxNumbers(in string Text)
        {
            string[] Words = SeparateText(in Text);
            string MainWord = null;
            int temp = 0, biggestCount = 0;

            foreach (string word in Words)
            {
                foreach (char c in word)
                {
                    if (c >= '0' && c <= '9')
                        temp++;
                }

                if (temp > biggestCount)
                {
                    biggestCount = temp;
                    MainWord = word;
                }

                temp = 0;
            }

            if (MainWord != null)
                Console.WriteLine("Это слово " + MainWord);
            else 
                Console.WriteLine("Нет подходящих слов");
          
        }

        public static void FindLongestWord(in string Text) 
        {
            string[] Words = SeparateText(in Text);
            string? MainWord = null;

            int LongestLength = 0, CountOfLongestWord = 0;


            for(int i = 0; i < Words.Length; i++)
            {
                if (i == 0)
                {
                    MainWord = Words[i];
                    LongestLength = MainWord.Length;
                    CountOfLongestWord++;
                    continue;
                }
                if (Words[i].Length > LongestLength)
                {
                    MainWord = Words[i];
                    LongestLength = MainWord.Length;
                    CountOfLongestWord = 1;
                }                
                else
                {
                    if (Words[i] == MainWord) { CountOfLongestWord++; }
                }
            }


            if (MainWord != null)
                Console.WriteLine($"Это слово {MainWord}, встречающееся столько раз: {CountOfLongestWord} .");
            else
                Console.WriteLine("Нет подходящих слов");


        }

        public static void FindRingWords(in string Text)
        {
            string[] Words = SeparateText(in Text);

            for(int i = 0; i < Words.Length; i++)
            {
                if (Words[i].Length > 1 && 
                    Words[i].StartsWith(Words[i][Words[i].Length - 1]))
                {
                    Console.WriteLine("{0} - подходящее слово ", Words[i]);
                }
            }
        }

        private static string[] SeparateText(in string Text)
        {
            char[] Separators = { '!', '?', ',', '.', ' ', '-', '(', ')', '[', ']', ';', ':' };
            string[] Words = Text.Split(Separators);
            return Words;
        }

    }
}
