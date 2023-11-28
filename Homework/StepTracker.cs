using System;
using System.Collections.Generic;

namespace Homework
{
    public class StepTracker
    {
        Dictionary<int, MonthData> monthToData = new Dictionary<int, MonthData>();
        const int steps = 10000;
        Converter converter = new Converter();
        String answer1 = null;
        String answer2 = null;
        String answer3 = null;
        int sum = 0;
        int max = 0;
        double middle = 0;
        double distance = 0;
        double calories = 0;
        int count = 0;
        public StepTracker()
        {
            for (int i = 0; i < 12; i++)
            {
                MonthData monthData = new MonthData();
                for(int j = 0; j < 30; j += 1)
                {
                    monthData.days[j] = steps;
                }
                monthToData.Add(i, monthData);
            }
        }
        public void printStepDay()
        {
            Console.Write("Введите месяц по счету (от 1 до 12): ");
            answer1 = Console.ReadLine();
            Console.Write("Введите за какой день необходимо узнать статистику (от 1 до 30): ");
            answer2 = Console.ReadLine();
            if(int.Parse(answer1) > 0 && int.Parse(answer1) < 13 && int.Parse(answer2) > 0 && int.Parse(answer2) < 31)
            Console.WriteLine($"Количество шагов за этот день: {monthToData[int.Parse(answer1) - 1].days[int.Parse(answer2) - 1]}");
            else Console.WriteLine("!!!* Месяц или день введен неверено! *!!!");
        }
        public void editTarget()
        {
            Console.Write("За какой месяц по счету необходимо заменить цель? (от 1 до 12): ");
            answer1 = Console.ReadLine();
            Console.Write($"Текущее значение - {monthToData[int.Parse(answer1) - 1].target}, на какое значение заменить?: ");
            answer2 = Console.ReadLine();
            if (int.Parse(answer1) > 0 && int.Parse(answer1) < 13 && int.Parse(answer2) > 0)
            monthToData[int.Parse(answer1) - 1].target = int.Parse(answer2);
            else Console.WriteLine("!!!* Месяц или значение введены неверено! *!!!");
        }
        public void printMonthStat()
        {
            Console.Write("За какой месяц по счету необходимо узнать статистику? (от 1 до 12): ");
            answer1 = Console.ReadLine();
            if (int.Parse(answer1) > 0 && int.Parse(answer1) < 13)
            {
                Console.WriteLine("Количество пройденных шагов: ");
                for (int i = 0; i < 30; i += 1)
                {
                    Console.WriteLine($"{i + 1} день - {monthToData[int.Parse(answer1) - 1].days[i]}");
                }
                for (int i = 0; i < 30; i += 1)
                {
                    sum += monthToData[int.Parse(answer1) - 1].days[i];
                }
                Console.WriteLine($"Общее количество шагов за месяц: {sum}");
                middle = sum / 30;
                distance = converter.convertDistance(sum);
                calories = converter.convertCalories(sum);
                sum = 0;
                for (int i = 0; i < 30; i += 1)
                {
                    if (monthToData[int.Parse(answer1) - 1].days[i] > max)
                    {
                        max = monthToData[int.Parse(answer1) - 1].days[i];
                    }
                }
                Console.WriteLine($"Максимальное количество шагов в месяце: {max}");
                max = 0;
                Console.WriteLine($"Среднее количество шагов в месяце: {middle}");
                middle = 0;
                Console.WriteLine($"Пройденное расстояние в этом месяце ~{distance} километров");
                distance = 0;
                Console.WriteLine($"Сожжено калорий в этом месяце ~{calories} (~{calories / 1000} килокалорий)");
                calories = 0;
                for (int i = 0; i < 30; i += 1)
                {
                    if (monthToData[int.Parse(answer1) - 1].days[i] > monthToData[int.Parse(answer1) - 1].target)
                    {
                        count += 1;
                    }
                }
                Console.WriteLine($"Количество дней, когда количество шагов превысило норму: {count}");
                count = 0;
            }
            else
            {
                Console.WriteLine("!!!* Месяц введен неверено! *!!!");
            }
            
        }
        public void enterNewSteps()
        {
            Console.Write("Введите месяц, в котором необходимо заменить количество шагов (от 1 до 12): ");
            answer1 = Console.ReadLine();
            Console.Write("Введите день, в котором необходимо заменить количество шагов (от 1 до 30): ");
            answer2 = Console.ReadLine();
            if (int.Parse(answer1) > 0 && int.Parse(answer1) < 13 && int.Parse(answer2) > 0 && int.Parse(answer2) < 31)
            {
                Console.WriteLine($"Текущее количество шагов {answer1} месяца {answer2} дня: {monthToData[int.Parse(answer1) - 1].days[int.Parse(answer2) - 1]}");
                Console.Write("Введите новое значение: ");
                answer3 = Console.ReadLine();
                monthToData[int.Parse(answer1) - 1].days[int.Parse(answer2) - 1] = int.Parse(answer3);
            }

        }
    }

    public class Converter
    {
        public double convertDistance(int sum)
        {
            return (sum * 75) / 100000;
        }
        public double convertCalories(int sum)
        {
            return sum * 50;
        }
    }
    public class MonthData
    {
        public int[] days = new int[30];
        public int target = 10000;
    }
}
