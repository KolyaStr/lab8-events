using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lb8._1_events
{
    class Calc
    {
        public delegate double Operation(double x, double y);

        public delegate void Message(string message);
        public event Message Notify;

        public Operation Add = (x, y) => x + y;
        public Operation Sub = (x, y) => x - y;
        public Operation Mul = (x, y) => x * y;
        public Operation Div = (x, y) =>
        {

            if (y == 0)
            {
                return 0;
            }
            else
                return x / y;

        };

        public string Input()
        {
            string str = null;
            bool proverka = true;
            while (proverka)
            {
                string temp = Console.ReadLine().Replace(" ", "");
                if (temp.Any(q => char.IsLetter(q)) || string.IsNullOrWhiteSpace(temp))
                {
                    Notify?.Invoke("Ошибка ввода!");
                    continue;
                }
                else
                {
                    str = temp.Replace('.', ',');
                    proverka = false;
                    return str;
                }

            }
            return str;
        }

        public void Result(string primer, string result)
        {
            Notify?.Invoke($"{primer}={result}");
        }

    }
}
