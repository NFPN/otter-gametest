using Otter;
using System;


namespace GameSetup
{
    class Program
    {
        static void Main(string[] args)
        {
            var game = new Game("The Collector", 800, 600);


            game.Start();
            //Console.ReadKey();
        }
    }
}
