using Strings.Homework;
using System.Runtime.InteropServices;
using System.Text;
using static Strings.Homework.WorkingWithAFiles;
using static Strings.Homework.ActionOnString;
using static Strings.Homework.Support;
using static Strings.Homework.FindingWords;
using static Strings.Homework.OutputSentences;

string Text;
ActionOnString Choice = 0;

DisplayStartText();

while (true)
{
    Console.WriteLine("\nВведите номер желаемого действия:");

    try
    {
        Choice = (ActionOnString)Convert.ToInt32(Console.ReadLine());
    }
    catch
    {
        Console.WriteLine("Ошибка при выборе операции. Повторите.");
        continue;
    }


    Text = WtiteToString();

    if (!IsTextCorrect(Text)) { continue; }


    DisplayText(in Text);


    switch (Choice)
    {
        case (ActionOnString.FindWordMaxNumbers):
            FindWordMaxNumbers(in Text);
            if (IsContinue()) continue;
            else return;
        case (ActionOnString.FindLongestWord):
            FindLongestWord(in Text);
            if (IsContinue()) continue;
            else return;
        case (ActionOnString.ReplaceNumbers):
            ReplaceNumbers(ref Text);
            DisplayText(in Text);
            WriteToFile(Text);
            if (IsContinue()) continue;
            else return;
        case (ActionOnString.DisplayEmotionalSentences):
            string[] EmotionalSentences = FindEmotionalSentences(in Text);
            DisplaySentences(EmotionalSentences);
            if (IsContinue()) continue;
            else return;
        case (ActionOnString.DisplayNoCommaSentences):
            string[] NoCommaSentences = FindNoCommaSentences(in Text);
            DisplaySentences(NoCommaSentences);
            if (IsContinue()) continue;
            else return;
        case (ActionOnString.FindRingWords):
            FindRingWords(in Text);
            if (IsContinue()) continue;
            else return;
        default: 
            Console.WriteLine("Повторите ввод.");
            continue;
    }

}



