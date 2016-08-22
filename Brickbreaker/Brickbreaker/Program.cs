using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brickbreaker
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Threading.Thread.Sleep(1000);
            Game newGame = new Game();
            if (Console.KeyAvailable)
            {
                newGame.RunGameHard(100);
            }
            else
            newGame.RunGameEasy(100);
        }
    }
}
