using System;
using System.Net.Security;
using System.Runtime.InteropServices;
using System.Text;

namespace Roguelike
{
    class Program
    {
        static void Main(string[] args)
        {
            bool play = true;
            while (play == true)
            {
                Console.Clear();
                Game game = new Game();
                bool gameOn = true;

                while (gameOn == true)
                {
                    gameOn = game.GenerateLevel();
                    game.level++;
                }

                Console.WriteLine("Play Again? Y/N");
                if (Console.ReadLine().ToUpper() == "Y")
                    play = true;
                else
                    play = false;
            }
            
        }
    }
}
