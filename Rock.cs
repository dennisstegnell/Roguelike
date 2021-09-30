using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roguelike
{
    class Rock : MapObject, IsMapObject
    {
        public char  MapIcon { get; set; } = 'O';
        public int Heigth { get; set; }
        public int  Length { get; set; }
        public string Description { get; set; } = "Rock";


        public Rock(int heigth, int length)
        {
            Heigth = heigth;
            Length = length;
        }

        public void MapsIcon()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write(MapIcon);
            Console.ForegroundColor = ConsoleColor.White;
        }
        public string MapObjectDescription()
        {
            return Description;
        }

    }

   
}
