using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roguelike
{
    interface IsMonster
    {
        public int Attack { get; set; }
        public int HP { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }
        public string GetStats();
    }
}
