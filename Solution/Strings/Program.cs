using System.Diagnostics;
using System.Globalization;
using System.Text;
using static System.Console;

namespace Strings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //CharLoopDemo();
            //StringVsStringBuilder();

            //WriteLine(Reverse("Hello"));
            //DemoCultures();

            try
            {
                //GetFibonacci(-1);
                GetFibonacci(48);
            }
            catch (Exception e)
            {
                WriteLine(e.Message);
            }

            WriteLine($"{string.Join(", " ,GetFibonacci(0))}");
            WriteLine($"{string.Join(", ", GetFibonacci(1))}");
            WriteLine($"{string.Join(", ", GetFibonacci(2))}");
            WriteLine($"{string.Join(", ", GetFibonacci(10))}");
            WriteLine($"{string.Join(", ", GetFibonacci(47))}");
        }

        private static void DemoCultures()
        {
            var number = 1.9999m;
            var date = DateTime.Now;

            WriteLine(CultureInfo.CurrentCulture);
            WriteLine($"\t{date} \n\t{number}");

            // setting cultuture to pl-PL - Polish - Poland
            CultureInfo.CurrentCulture = new CultureInfo("pl-PL");
            WriteLine(CultureInfo.CurrentCulture);
            WriteLine($"\n\t{date} \n\t{number}");
        }

        private static void StringVsStringBuilder()
        {
            int count = 200_000;
            String result = String.Empty;
            Stopwatch sw = Stopwatch.StartNew();
            for (int i = 1; i < count; i++)
            {
                result += "a";
            }
            sw.Stop();
            WriteLine($"String {count} concatenations : {sw.ElapsedMilliseconds}");

            // string builder
            StringBuilder stringBuilder = new StringBuilder();
            sw = Stopwatch.StartNew();
            for (int i = 1; i < count; i++)
            {
                stringBuilder.Append("a");
            }
            sw.Stop();
            WriteLine($"String Builder {count} appends: {sw.ElapsedMilliseconds}");
        }

        private static void CharLoopDemo()
        {
            for (char c = 'A'; c <= 'Z'; c++)
            {
                Write($"{c}, ");
            }
        }

        private static string Reverse(string input)
        {
            if (input == "")
                return input;

            StringBuilder sb = new StringBuilder();
            for (int i = input.Length - 1; i >= 0; i--) 
            {
                sb.Append(input[i]);
            }
            return sb.ToString();
        }

        public static IEnumerable<int> GetFibonacci(int n)
        {
            const int Min = 0;
            const int Max = 47;
            if (n < Min || n > Max)
                throw new ArgumentOutOfRangeException($"Valid inclusive range for input {Min} to {Max}");

            List<int> fibs = new List<int>();
            for (int i = 0; i < n; i++)
            {
                if (i == 0 || i == 1)
                    fibs.Add(i);
                else
                    fibs.Add(fibs[i-1] + fibs[i-2]);
            }
            return fibs;            
        }
    }
}
