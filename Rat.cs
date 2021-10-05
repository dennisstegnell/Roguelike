using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roguelike
{
    public class Rat: Monster, IsMonster
    {
        
        public Rat(int level)
        {
            Level = level;
            Attack = 1 + Level*2;
            HP = 20 + Level*10;
            Name = "Rat";
            XP = 9 + level * 5;
            
            
        }

        public string GetStats() 
        {
            return Name;

        }
        
    }
}
