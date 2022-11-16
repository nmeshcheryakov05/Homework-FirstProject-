using System;

namespace Homework
{
    class Program
    {
        static void Main(string[] args)
        {
            printMenu();
            int userInput = int.Parse(Console.ReadLine());

            while (userInput != 0)
            {
                //обработка разных случаев

                printMenu(); //получаем меню еще раз
                userInput = int.Parse(Console.ReadLine()); // повторное считывание данных от пользователя
            }
            Console.WriteLine("Программа завершена");
        }

        public static void printMenu()
        {

        }
    }
}
