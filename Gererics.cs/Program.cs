using System;

namespace Gererics.cs
{
    class Program
    {
        public class MyClass<T>
        {
            public T Value { get; set; }
            public MyClass(T value)
            {
                this.Value = value;
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine(Add(2,3));
            Console.WriteLine(Add(2.5, 3.3));

            MyClass<int> obj = new MyClass<int>(2);
            Console.WriteLine(obj.Value);

            Console.ReadLine();
        }

        private static T Add<T, U>(T v1, U v2)
        {
            dynamic num1 = v1;
            dynamic num2 = v2;
            return (T)(num1 + num2);
        }
    }
}
