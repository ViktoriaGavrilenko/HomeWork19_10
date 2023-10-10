using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sample4
{
    internal class Program
    {
        //Thread Function
        public static void DoTheTask(object obj)
        {           
            SharedState sharedState = obj as SharedState;
            lock (sharedState)            {
                for (int i = 0; i< 5000; i++)                {
                    sharedState.State++;                }
}
        }
        static void Main(string[] args)
{
    int countTheads = 20;
    Thread[] mas = new Thread[countTheads]; SharedState sharedState = new SharedState();
    for (int i = 0; i < countTheads; i++)
    {
        mas[i] = new Thread(DoTheTask); mas[i].Start(sharedState);
    }
    for (int i = 0; i < countTheads; i++)
    {
        mas[i].Join();
    }
    Console.WriteLine($"Sum={sharedState.State}");
}    }


}
