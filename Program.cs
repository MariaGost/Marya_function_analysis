using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marya_function_analysis
{
    class Program
    {
        static void Main(string[] args)
        {
            double a, b, c;
            double x0, x1;

            Console.WriteLine("Введите коэффициенты");
            
            Console.Write("a> ");
            a = double.Parse(Console.ReadLine());

            Console.Write("b> ");
            b = double.Parse(Console.ReadLine());

            Console.Write("c> ");
            c = double.Parse(Console.ReadLine());

            Console.WriteLine("Введите интервал исследования");

            Console.Write("x0> ");
            x0 = double.Parse(Console.ReadLine());

            Console.Write("x1> ");
            x1 = double.Parse(Console.ReadLine());



        }
    }
}
