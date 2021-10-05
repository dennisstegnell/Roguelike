using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roguelike
{
    public class Water : MapObject
    {

        public Water(int height, int length)
        {
            Heigth = height;
            Length = length;
            Description = "Lake";
            MapIcon = '~';
            MapColor = ConsoleColor.DarkCyan;

        }
        public override void MapsIcon()
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write(MapIcon);
            Console.ForegroundColor = ConsoleColor.White;
        }
        
    }
}
