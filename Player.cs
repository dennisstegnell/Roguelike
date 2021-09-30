using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roguelike
{
    public class Player
    {
        public int HP { get; set; } = 10;
        public string Name { get; set; }
        public bool canSwim { get; set; } = true;
        public int swimStamina { get; set; } = 3;

        public char MapIcon { get; set; } = 'P';

        public Player()
        {
            ;
        }

        public void Swim()
        {
            if (swimStamina == 0)
                canSwim = false;
            if (swimStamina > 0)
            {
                swimStamina--;
            }

            
          
        }
        
    }
}
