using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roguelike
{
    public class Tree : MapObject, Passable
    {
        public Tree(int heigth, int length)
        {
            Heigth = heigth;
            Length = length;
            Description = "Forest";
            MapIcon = Convert.ToChar(165);
        }
        public override void MapsIcon()
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write(MapIcon);
            Console.ForegroundColor = ConsoleColor.White;
        }
        
    }
}
