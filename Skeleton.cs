using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roguelike
{
    public class Skeleton : Monster, IsMonster
    {

        public Skeleton(int level)
        {
            Attack = 3 + level;
            HP = 18 + level*10;
            Name = "SKELETON";
            Level = level;
            XP = 12 + level * 6;

        }

        public string GetStats()
        {
            return Name;

        }

    }
}
