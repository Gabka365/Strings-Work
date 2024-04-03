using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strings.Homework
{
    static class OutputSentences
    {
        public static string[] FindEmotionalSentences(in string Text)
        {
            int? startIndex = 0;
            int min;
            List<string> ExclamationSentence = new List<string>(); 
            List<string> QuestionSentence = new List<string>();

            while (startIndex != null)
            {
                min = FindMin(in Text, startIndex);

                if (min == -1) { startIndex = null; }
                
                switch (Text[min])
                {
                    case '!':
                        ExclamationSentence.Add(Text.Substring((int)startIndex, min - (int)startIndex + 1));
                        startIndex = min + 1;
                        break;
                    case '.':
                        startIndex = min + 1;
                        if (startIndex == Text.Length) { startIndex = null; }
                        break;
                    case '?':
                        QuestionSentence.Add(Text.Substring((int)startIndex, min - (int)startIndex + 1));
                        startIndex = min + 1;
                        break;
                    default:
                        startIndex = null;
                        break;
                }   
            }
            string[] Sentences = new string[ExclamationSentence.Count + QuestionSentence.Count];
            Sentences = WriteToSentences(Sentences, ExclamationSentence, QuestionSentence);
            return Sentences;
        }

        public static string[] FindNoCommaSentences(in string Text)
        {
            int? startIndex = 0;
            int min;
            int indexOfComma;
            List<string> NoCommaSentences = new List<string>();


            while (true)
            {
                indexOfComma = Text.IndexOf(',', (int)startIndex);
                min = FindMin(in Text, startIndex);


                if ((Text[min] != '!' 
                    && Text[min] != '?'
                    && Text[min] != '.')
                    || (min == Text.Length - 1 
                    && (int)startIndex == Text.Length))
                { break; }
                


                if (indexOfComma != -1 && min == -1) { break;}

                if ((indexOfComma == -1 &&  min != -1)
                    || (indexOfComma == -1 && min == -1))
                {
                    NoCommaSentences.Add(Text.Substring((int)startIndex, min - (int)startIndex + 1));
                    startIndex = min + 1;
                }


                if (indexOfComma != -1 && min != -1)
                {
                    if (min > indexOfComma)
                    {
                        startIndex = min + 1;
                    }
                    else
                    {
                        NoCommaSentences.Add(Text.Substring((int)startIndex, min - (int)startIndex + 1));
                        startIndex = min + 1;
                    }
                }
            }

            string[] Sentences = new string[NoCommaSentences.Count];
            
            for (int i = 0; i < Sentences.Length; i++)
            {
                Sentences[i] = NoCommaSentences[i];
            }

            return Sentences;
        }

        public static void DisplaySentences(string[] Sentences)
        {
            for(int i = 0; i < Sentences.Length; i++)
            {
                Console.WriteLine(" Предложение {0}-е: {1}", i, Sentences[i]);
            }
        }

        private static int FindMin(in string Text, int? startIndex)
        {
            int place;
            int min = Text.Length - 1;

            place = Text.IndexOf(".", (int)startIndex);
            if (place != -1) { min = place; }

            place = Text.IndexOf('!', (int)startIndex);
            if (place != -1 && place < min) { min = place; }

            place = Text.IndexOf('?', (int)startIndex);
            if (place != -1 && place < min) { min = place; }

            return min;
        }

        private static string[] WriteToSentences(string[] Sentences, List<string> ExclamationSentence, List<string> QuestionSentence)
        {
            for (int i = 0; i < Sentences.Length; i++)
            {
                try
                {
                    Sentences[i] = QuestionSentence[i];
                }
                catch
                {
                    Sentences[i] = ExclamationSentence[i - QuestionSentence.Count];
                }
            }
            return Sentences;
        }
    }
}
