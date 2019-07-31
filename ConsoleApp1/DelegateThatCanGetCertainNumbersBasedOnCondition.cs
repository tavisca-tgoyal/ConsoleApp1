using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public class DelegateThatCanGetCertainNumbersBasedOnCondition
    {
        public static bool LessThanFive(int number) { return number < 5; }
        public static bool LessThanTen(int number) { return number < 10; }
        public static bool GreaterThanThirteen(int number) { return number > 13; }

        public delegate bool GenericDelegate(int value);
        public static void Main(string[] args)
        {
            int[] numbers = new[] { 2, 3, 4, 5, 6, 7, 8, 19, 45, 22, 44, 335 };
            IEnumerable<int> result = NumberLessThan(GreaterThanThirteen, numbers);
            foreach(int num in result)
            {
                Console.WriteLine(num);
            }
            Console.Read();
        }

        public static IEnumerable<int> NumberLessThan(GenericDelegate gauntlet, IEnumerable<int> numbers){
            foreach(int number in numbers)
            {
                if(gauntlet(number))
                {
                    yield return number;
                }
            }
        }
    }
}
