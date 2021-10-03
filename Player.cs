using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roguelike
{
    public class Player
    {
        public int CurrentHP { get; set; } = 50;
        public int MaxHP { get; set; } = 50;
        public string Name { get; set; } = "PLAYER";
        public List<int> LvlUpValues { get; set; } = new List<int> { 0,30, 65, 120, 184, 270, 500 };
        public int PlayerLvL { get; set; } = 1;
        public int PlayerXP { get; set; } = 0;
        public bool canSwim { get; set; } = true;
        public int swimStamina { get; set; } = 3;
        public int Attack { get; set; } = 6;
        //public char MapIcon { get; set; } = 'P';

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
