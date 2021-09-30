using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roguelike
{
    class Tree : MapObject, IsMapObject, Passable
    {
        public char MapIcon { get; set; } = Convert.ToChar(165);
        public int Heigth { get; set; }
        public int Length { get; set; }
        public string Description { get; set; } = "Forest";


        public Tree(int heigth, int length)
        {
            Heigth = heigth;
            Length = length;
        }
        public void MapsIcon()
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write(MapIcon);
            Console.ForegroundColor = ConsoleColor.White;
        }
        public string MapObjectDescription()
        {

            return Description;
        }
    }
}
