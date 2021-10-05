using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roguelike
{
    public abstract class MapObject
    {
        public char MapIcon { get; set; }
        public int Heigth { get; set; }
        public int Length { get; set; }
        public string Description { get; set; }
        public ConsoleColor MapColor { get; set; }


        public abstract void MapsIcon();

        
        
    }
}
