using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roguelike
{
    public class Items : MapObject , Passable
    {
        public Items()
        {
            MapIcon = Convert.ToChar(162);
        }
        public override void MapsIcon()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write(MapIcon);
            Console.ForegroundColor = ConsoleColor.White;
        }
        public void effect(Player player, Items a)
        {
            //HP_Potion a = new HP_Potion();       Vill flytta effecten till "HP_Potion"
            //a.effect(player);                    
            player.CurrentHP += 25;
            player.Inventory.Remove(a);         //Radera Item från Listan när man använt men det fungerar inte atm
        }
        public void randomizeitem(Player player)
        {
            Items item;
            Random rng = new Random();
            int a = rng.Next(0, 4);
            if (a == 1)
            {
                item = new HP_Potion();
            }
            else
            {
                item = new HP_Potion();
            }
            player.AddToInventory(item);
            
        }
    }
}
