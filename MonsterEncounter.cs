using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Roguelike
{
    class MonsterEncounter
    {
        public Player Player { get; set; }
        public int Level { get; set; }


        public MonsterEncounter(Player player, int level)
        {
            Player = player;
            Level = level;
        }

        public bool GenerateBattle()
        {
            List<IsMonster> listOfMobs = new List<IsMonster>();             //Lista av monster vid implementering av fler mobs per battle
            Console.Clear();
            IsMonster monster;
            monster = GenerateMonster();                                   // Genererar vilken monsterklass som helst vid IsMonster interface, kan göra regler för vilka mobs per vilken lvl
            listOfMobs.Add(monster);                                       // Kan adda det i monster props kanske? Vet ej än.
            PrintBattle(monster);      

            while (monster.HP > 0 && Player.CurrentHP > 0)
            {
                
                PlayerMove(monster);                                      // Alternerar mellan player och listan av monster, funkar inte än då fler monster inte är implementerat, funkar
                if (monster.HP < 1)                                       // på en mob tho
                {
                    
                    Console.SetCursorPosition(30, 8);
                    Console.Write($"HP LEFT : {monster.HP}");
                    Console.SetCursorPosition(56, 20);
                    Console.Write("VICTORY");
                    Console.ReadLine();
                    break;  
                }
                foreach(IsMonster mob in listOfMobs)
                {
                    MonsterMove(mob); 
                }
                if (Player.CurrentHP < 1)
                {
                    Console.WriteLine("You died! Try stay over 0HP next time!");
                    return false;
                }

            }
            return true;
        }
        private void PrintBattle(IsMonster monster)
        {
            Console.SetCursorPosition(56, 2);
            Console.Write("BATTLE");
            Console.SetCursorPosition(45, 3);
            Console.Write($"YOU HAVE ENCOUNTERED A {monster.Name.ToUpper()}");
            Console.SetCursorPosition(30, 8);
            Console.Write($"HP LEFT : {monster.HP}");
            Console.SetCursorPosition(30, 7);
            Console.Write($"{monster.Name.ToUpper()}");
            Console.SetCursorPosition(80, 7);
            Console.Write($"{Player.Name.ToUpper()}");
            Console.SetCursorPosition(80, 8);
            Console.Write($"HP LEFT : {Player.CurrentHP}");
            Console.SetCursorPosition(56, 16);
            Console.ReadLine();
        }
        private void MonsterMove(IsMonster monster)
        {
            
            Player.CurrentHP -= monster.Attack;
            Console.SetCursorPosition(45, 15);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(45, 15);
            Console.Write($"{monster.Name} Attacks {Player.Name} for {monster.Attack} damage!".ToUpper());
            Console.SetCursorPosition(80, 8);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(80, 8);
            Console.Write($"HP LEFT : {Player.CurrentHP}");
            Console.SetCursorPosition(56, 16);
            Console.ReadLine();


        }

        private void PlayerMove(IsMonster monster)
        {
            
            monster.HP -= Player.Attack;
            Console.SetCursorPosition(45,15);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(45, 15);
            Console.Write($"You Attack {monster.Name} for {Player.Attack} damage!".ToUpper());
            Console.SetCursorPosition(30, 8);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(30, 8);
            Console.Write($"HP LEFT : {monster.HP}");
            Console.SetCursorPosition(80, 8);
            Console.Write($"HP LEFT : {Player.CurrentHP}");
            Console.SetCursorPosition(56, 16);
            Console.ReadLine();


        }


        public IsMonster GenerateMonster()
        {

            int a;
            Random rng = new Random();
            a = rng.Next(0, 10);
            {
                if (a < 5)
                {
                    
                    return new Rat(Level);
                }
                else
                {
                    return new Skeleton(Level);
                }
            }


        }
        public void PrintShit()
        {

        }
    }
    

}
