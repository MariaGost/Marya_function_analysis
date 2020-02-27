using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marya_function_analysis
{
    class Program
    {
        private static double GetIntegral( Func<double, double> f, double x1, double x2, double dx = 0.001 )
        {
            double x = x1;
            double sum = 0;

            while(x <= x2)
            {
                sum += f(x);
                x += dx;
            }

            return sum * dx;
        }

        private static double GetMedium(Func<double, double> f, double x1, double x2, int N = 10)
        {
            double dx = (x2 - x1) / N;
            double sum = 0;
            double x = x1;

            for (int i = 0; i <= N; ++i, x += dx)
            {
                sum += f(x);
            }

            return sum / (N + 1);
        }

        private static double GetDeviation( Func<double, double> f, double x1, double x2, int N = 10)
        {
            double sum = 0;
            double dx = (x2 - x1) / N;
            double x = x1;
            double medium = GetMedium(f, x1, x2, N);
            double t;

            for(int i = 0; i <= N; ++i, x += dx)
            {
                t = (f(x) - medium);
                sum += t * t;
            }

            return System.Math.Sqrt(sum / (N + 1));
        }

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

            Func<double, double> f = (x) => a * x * x + b * x + c;

            double X = -0.5 * b / a;
            double globalExtr = f(X);
            double localExtr = (X >= x0 && X <= x1) ? globalExtr : System.Math.Max(f(x0), f(x1));

            Console.WriteLine("Глобальный экстремум функции достигается в точке х = {0} и равен {1}", X, globalExtr);
            Console.WriteLine("Локальный экстремум равен {0}", localExtr);


            double integral = GetIntegral(f, x0, x1);
            Console.WriteLine("Интеграл от функции равен {0}", integral);

            double D = b * b - 4 * a * c;
            if(D < 0)
            {
                Console.WriteLine("Многочлен не имеет действительных корней");
            }
            else if(D == 0)
            {
                if (X >= x0 && X <= x1) Console.WriteLine("Многочлен имеет единственный корень x = {0}", X);
                else Console.WriteLine("Многочлен не имеет корней на заданном интервале.");
            }
            else
            {
                D = System.Math.Sqrt(D);
                double X1 = (-b + D) / (2 * a);
                double X2 = (-b - D) / (2 * a);

                if( X1 >= x0 && X1 <= x1 )
                {
                    if (X2 >= x0 && X2 <= x1) Console.WriteLine("Многочлен имеет два действительных корня x1 = {0} и x2 = {1}", X1, X2);
                    else Console.WriteLine("Многочлен достигает нуля на заданном интервале в единственной точке x = {0}", X1);
                }
                else if (X2 >= x0 && X2 <= x1)
                {
                    Console.WriteLine("Многочлен достигает нуля на заданном интервале в единственной точке x = {0}", X2);
                }
            }


            double medium = GetMedium(f, x0, x1);
            Console.WriteLine("Среднее значение равно {0}", medium);

            double dev = GetDeviation(f, x0, x1);
            Console.WriteLine("Среднеквадратичное отклонение равно {0}", dev);


            Console.ReadLine();
        }
    }
}
