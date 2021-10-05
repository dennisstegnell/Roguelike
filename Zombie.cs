using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roguelike
{
    class Zombie : Monster
    {
            public Zombie(int level)
            {
                Attack = 5 + level;
                HP = 30 + level * 10;
                Name = "Zombie";
                Level = level;
                XP = 15 + level * 6;
            }

            public string GetStats()
            {
                return Name;

            }

    }
}
