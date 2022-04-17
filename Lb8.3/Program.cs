using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Lb8._3
{
    
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
