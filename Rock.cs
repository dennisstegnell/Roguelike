using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roguelike
{
    public class Rock : MapObject
    {
        
        public Rock(int heigth, int length)
        {
            Heigth = heigth;
            Length = length;
            Description = "Rock";
            MapIcon = 'O';
            MapColor = ConsoleColor.DarkGray;
        }

        public override void MapsIcon()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write(MapIcon);
            Console.ForegroundColor = ConsoleColor.White;
        }
        

    }

   
}
