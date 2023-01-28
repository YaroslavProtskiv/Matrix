using System;
using System.Threading;

namespace Task_1
{
    class Matrix
    {
        static readonly object locker = new object();

        Random rand;

        const string litters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

        public int Colunm { get; set; }

        public Matrix(int col)
        {
            Colunm = col;
            rand = new Random((int)DateTime.Now.Ticks);
        }

        private char GetChar()
        {
            return litters.ToCharArray()[rand.Next(0, 35)];
        }

        public void Move()
        {
            int lenght1, lenght2;
            int count1, count2;
            int hiatus;

            while (true)
            {
                count1 = rand.Next(6, 9);
                count2 = rand.Next(6, 9);
                lenght1 = 0; lenght2 = 0;
                hiatus = (40 - count1 - count2) / 2 + rand.Next(-5, 5);
                Thread.Sleep(rand.Next(20, 5000));
                for (int i = 0; i < 40; i++)
                {
                    lock (locker)
                    {
                        Console.CursorTop = 0;
                        Console.ForegroundColor = ConsoleColor.Black;
                        for (int j = 0; j < i; j++)
                        {
                            Console.CursorLeft = Colunm;
                            Console.WriteLine("█");
                        }
                        lenght1 = LastToTop(i, lenght1, ref count1);
                        ChangeMatrix(i, lenght1);
                        if (i > hiatus + count1)
                        {
                            lenght2 = LastToTop(i, lenght2, ref count2);
                            ChangeMatrix(i, lenght2, hiatus);
                        }
                        Thread.Sleep(20);
                    }
                }
            }
        }

        private void ChangeMatrix(int lastSize, int lenght, int hiatus = 0)
        {
            Console.CursorTop = lastSize - lenght - hiatus + 1;
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            for (int j = 0; j < lenght - 2; j++)
            {
                Console.CursorLeft = Colunm;
                Console.WriteLine(GetChar());
            }
            if (lenght >= 2)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.CursorLeft = Colunm;
                Console.WriteLine(GetChar());
            }
            if (lenght >= 1)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.CursorLeft = Colunm;
                Console.WriteLine(GetChar());
            }
        }

        private int LastToTop(int lastSize, int lenght, ref int count)
        {
            
            if (lenght < count)
                lenght++;
            else
               if (lenght == count)
                count = 0;

            if (39 - lastSize < lenght)
                lenght--;

            return lenght;
        }
    }
}
