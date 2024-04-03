using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Strings.Homework.ChoiceOfNextStep;


namespace Strings.Homework
{
    public static class Support
    {
        public static bool IsContinue()
        {
            ChoiceOfNextStep Choice = 0;
            Console.WriteLine("\nЖелаете ли вы выполнить ещё одну операцию?");
            Console.WriteLine("1 - да, 2 - нет");

            while (true)
            {
                try
                {
                    Choice = (ChoiceOfNextStep)Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine(" Ошибка при выборе операции. Повторите.");
                }

                if ((int)Choice == 1 || (int)Choice == 2)
                    break;
                else
                    Console.WriteLine(" Ошибка при выборе операции. Повторите.");
            }

            if (Choice == ChoiceOfNextStep.ContinuationTheProgram)
                return true;
            else
                return false;
        }

        public static bool IsTextCorrect(string Text)
        {
            string AcceptableCharacters = ",.;:?!— ()[]";


            foreach(char component in Text)
            {
                if (AcceptableCharacters.Contains(component))
                    continue;
                if (component >= 'A' && component <= 'Z')
                    continue;
                if (component >= 'a' && component <= 'z')
                    continue;
                if (component >=  '0' && component <= '9')
                    continue;
                else
                {
                    Console.WriteLine("Ошибка при выборе операции. Повторите.");
                    return false;
                }              
            }

            return true;
        }

        public static void DisplayText(in string Text)
        {
            Console.WriteLine("\n" + Text + "\n");
        }


    }
}
