using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Lb8._3
{
    class Lines
    {
        static object locker = new object();
        Random random = new Random();

        public void Print(object X)
        {
            int len = random.Next(5, Console.WindowHeight - 10);
            int x = (int)X;
            int y = random.Next(0, Console.WindowHeight - 2);
            int temp = 0;

            for (int i = 0; i < len; i++)
            {
                lock (locker)
                {
                    if (y == Console.WindowHeight - 1)
                    {
                        y = 0;
                        Console.SetCursorPosition(x, y);
                        temp = y + 1;
                    }
                    else
                    {
                        Console.SetCursorPosition(x, y++);
                        temp = y + 1;
                    }

                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("{0}", Convert.ToChar(random.Next(100, 126)));

                    if (temp > 3 && i >= 2)
                    {
                        Console.SetCursorPosition(x, temp - 3);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("{0}", Convert.ToChar(random.Next(100, 126)));

                        Console.SetCursorPosition(x, temp - 4);
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine("{0}", Convert.ToChar(random.Next(100, 126)));
                    }
                    else if (temp <= 2)
                    {
                        Console.SetCursorPosition(x, temp - 4 + Console.WindowHeight);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("{0}", Convert.ToChar(random.Next(100, 126)));

                        Console.SetCursorPosition(x, temp - 5 + Console.WindowHeight);
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine("{0}", Convert.ToChar(random.Next(100, 126)));
                    }

                    if (i == len - 1)
                    {
                        if (y >= len)
                        {
                            Console.SetCursorPosition(x, y - len);
                            Console.Write(' ');
                            i--;
                        }
                        else
                        {
                            Console.SetCursorPosition(x, Console.WindowHeight - len + y);
                            Console.Write(' ');
                            i--;
                        }
                    }
                    Thread.Sleep(0);
                }
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Lines lines = new Lines();
            for (int i = 0; i < Console.WindowWidth - 1;)
            {
                new Thread(new ParameterizedThreadStart(lines.Print)).Start((object)i);
                i += 2;
            }

        }
    }
}
