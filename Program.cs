using System;
using System.Net.Security;
using System.Text;

namespace Roguelike
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Game game = new Game();
            bool gameOver = false;
            while(gameOver == false)
            {
                
                game.GenerateLevel();
                game.level++;
                
            }
        }
    }
}
