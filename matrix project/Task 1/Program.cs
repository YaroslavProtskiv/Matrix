using System;
using System.Threading;

namespace Task_1
{
    class Program
    {
        static void Main()
        {
            Console.SetWindowSize(80, 40);

            Matrix instance;
            
            for (int i = 0; i < 20; i++)
            {
                instance = new Matrix(i * 4);
                new Thread(instance.Move).Start();
            }


            Console.ReadKey();
        }
    }
}
