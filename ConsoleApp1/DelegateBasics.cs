using System;

namespace ConsoleApp1
{
    class Prog
    {
        public delegate void DelegateOfVoidAndNoArgument(string name);

        static void JustAnotherMethod(string[] args)
        {
            //mymethod();
            DelegateOfVoidAndNoArgument DelegateOfMyMethod = MyMethod;
            DelegateOfMyMethod("tushar goyal");
            Console.ReadLine();
        }

        public static void MyMethod(string name)
        {
            Console.WriteLine($"MyMethod is called, hello mr.{name}");
        }
    }
}
