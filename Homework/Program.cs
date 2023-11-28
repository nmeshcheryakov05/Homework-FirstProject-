using System;

namespace Homework
{
    class Program
    {
        static void Main(string[] args)
        {
            String userInput = null;
            StepTracker tracker = new StepTracker();
            bool work = true;
            while (work)
            {
                Console.WriteLine();
                printMenu();
                userInput = Console.ReadLine();
                if(userInput == "exit")
                {
                    work = false;
                }
                else if(userInput == "step")
                {
                    tracker.printStepDay();
                }
                else if(userInput == "edit")
                {
                    tracker.editTarget();
                }
                else if(userInput == "stat")
                {
                    tracker.printMonthStat();
                }
                else if(userInput == "enter")
                {
                    tracker.enterNewSteps();
                }
                else
                {
                    Console.WriteLine("!!!* Название функции введено некорректно! *!!!");
                }
            }
            Console.WriteLine("Программа завершена.");
        }

        public static void printMenu()
        {
            Console.WriteLine("---Что вы хотите сделать?---");
            Console.WriteLine("Ввести количество шагов за день:              --> enter<--");
            Console.WriteLine("Напечатать статистику за определенный месяц:  --> stat <--");
            Console.WriteLine("Вывести шаги за определенный день:            --> step <--");
            Console.WriteLine("Изменить цель по количеству шагов в день:     --> edit <--");
            Console.WriteLine("Выйти из приложения:                          --> exit <--");
        }
    }
}
