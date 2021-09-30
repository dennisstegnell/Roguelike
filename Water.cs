using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roguelike
{
    class Water : MapObject, IsMapObject
    {
        public char MapIcon { get; set; } = '~';
        public int Heigth { get; set; }
        public int Length { get; set; }
        public string Description { get; set; } = "Lake";

        public Water(int height, int length)
        {
            Heigth = height;
            Length = length;
        }
        public char MapsIcon()
        {
            return MapIcon;
        }
        public string MapObjectDescription()
        {
            return Description;
        }
    }
}
