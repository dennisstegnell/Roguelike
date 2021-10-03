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
            Attack = 2 + Level*2;
            HP = 25 + Level*10;
            Name = "Rat";
            
            
        }

        public string GetStats() 
        {
            return Name;

        }
        
    }
}
