using System;
using System.Timers;

namespace NestedStatesConsole
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            Player player = new Player();

            Timer timer = new Timer(1000)
            {
                AutoReset = true
            };
            timer.Elapsed += player.Update;
            timer.Start();
            Console.ReadLine();
        }
    }
}
