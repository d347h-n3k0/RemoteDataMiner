using System;
using System.Threading;

namespace TestPlugin
{
    public class Class1
    {
        public void Init(string message)
        {
            Console.WriteLine(message);
            Thread test = new Thread(Test.Start);
            test.Start();
        }
    }

    internal class Test
    {
        public static void Start()
        {
            Thread.Sleep(500);
            Console.WriteLine("Thread Test");
        }
    }
}
