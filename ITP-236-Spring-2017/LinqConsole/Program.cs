using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqConsole
{
    class Program
    {

        delegate int Numbers(int[] numbers);
        static void Main(string[] args)
        {
            int[] numbers = { 12, 123, 12, 12, 13, 51, 35, 82, 816, 36 };
            Numbers Happy = SumTheNumbers;
            int total = Happy(numbers);
            Happy = MaximumNumber;
            int max = Happy(numbers);
            Console.Write($"HAPPY {total}th Birthday");
            Console.Write($"Low is {max}");
            Console.ReadLine();
        }
        static int MaximumNumber(int[] numbers)
        {
            int max = int.MinValue;
            foreach (var num in numbers)
                if (num > max)
                    max = num;
            return max;
        }


        static int SumTheNumbers(int[] numbers)
        {
            int total = 0;
            foreach (int num in numbers)
                total += num;
            return total;
        }

    }
}
