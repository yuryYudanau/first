using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Test
{
    class Program
    {
        static int i;
        static void Main(string[] args)
        {
            i = 0;
            
            for (; i < 10000; ++i)
            {
                Thread thread = new Thread(MyThread);
                thread.Start(i);
            }
            Console.WriteLine("Done! " + i);
        }

        static void MyThread(object i)
        {
            try
            {
                Thread.Sleep(1000000);
            }
            catch(OutOfMemoryException ex)
            {
                Console.WriteLine(i);
            }
        }
    }
}
