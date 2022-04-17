using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lb8._1_events
{
    class Program
    {
        static void Main(string[] args)
        {
            Calc calc = new Calc();
            calc.Notify += DisplayMessage;
            void DisplayMessage(string message) => Console.WriteLine(message);

            Console.WriteLine("Введите пример:");

            string str = calc.Input();

            string[] numbers = str.Split(new char[] { '-', '+', '*', '/' }, StringSplitOptions.RemoveEmptyEntries);
            string[] actions = str.Split(new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', ',', '.' }, StringSplitOptions.RemoveEmptyEntries);

            string[] task = new string[numbers.Length + actions.Length];

            int a = 0;
            for (int i = 0, b = 1, c = 0; i < task.Length; i += 2, b += 2, c++)
            {
                task[i] = numbers[c];
                if (a < actions.Length)
                    task[b] = actions[c];
                a++;
            }

            if (task.Length == 1 || task.Length == 2)
            {
                Console.WriteLine("Ошибка ввода!");
            }
            string primer = null;
            for (int i = 0; i < task.Length; i++)
            {
                primer += task[i];
            }


            int nulls = 0;
            for (int i = 0; i < task.Length; i++)
            {
                if (task[i] == "/")
                {
                    task[i - 1] = Convert.ToString(calc.Div(Convert.ToDouble(task[i - 1]), Convert.ToDouble(task[i + 1])));
                    task[i] = null;
                    task[i + 1] = null;
                    nulls += 2;
                }
                else if (task[i] == "*")
                {
                    task[i - 1] = Convert.ToString(calc.Mul(Convert.ToDouble(task[i - 1]), Convert.ToDouble(task[i + 1])));
                    task[i] = null;
                    task[i + 1] = null;
                    nulls += 2;
                }
            }

            string[] newTask = new string[task.Length - nulls];

            for (int i = 0, b = 0; i < task.Length; i++)
            {
                if (task[i] != null)
                {
                    newTask[b] = task[i];
                    b++;
                }
            }

            for (int i = 0; i < newTask.Length - 1; i++)
            {
                if (newTask[i] == "+")
                {
                    newTask[i + 1] = Convert.ToString(calc.Add(Convert.ToDouble(newTask[i - 1]), Convert.ToDouble(newTask[i + 1])));
                    newTask[i] = null;
                    newTask[i - 1] = null;
                }
                else if (newTask[i] == "-")
                {
                    newTask[i + 1] = Convert.ToString(calc.Sub(Convert.ToDouble(newTask[i - 1]), Convert.ToDouble(newTask[i + 1])));
                    newTask[i] = null;
                    newTask[i - 1] = null;
                }
            }

            string result = null;

            for (int i = 0; i < newTask.Length; i++)
            {
                result += newTask[i];
            }
            calc.Result(primer, result);
        }
    }
}
