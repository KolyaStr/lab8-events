using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Lb8._2
{
    class Program
    {
        public static void Method(object num)
        {
            int n = (int)num;
            if (n <= 0)
                return;
            Thread thread = new Thread(Method);
            thread.Name = "Thread " + n;
            thread.Start(n - 1);
            Console.WriteLine($"В потоке: {thread.Name}");
        }
        static void Main(string[] args)
        {
            Method(5);

        }
    }
}
