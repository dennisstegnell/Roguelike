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
        public Random rng { get; set; } = new Random();


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
                    
                    Console.WriteLine("VICTORY");
                    CalculateCombat(monster);
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

        private void CalculateCombat(IsMonster monster)
        {
            Player.PlayerXP += monster.XP;
            
            if(Player.PlayerXP > Player.LvlUpValues[Player.PlayerLvL])
            {
                Player.PlayerLvL++;
                Console.WriteLine($"DING DU BLEV LVL {Player.PlayerLvL}");
                Console.WriteLine("YOU GAIN 20 MAX HP");
                Console.WriteLine("YOU GAIN 1 ATTACK");
                Player.Attack++;
                Player.MaxHP += 20;
                Player.CurrentHP = Player.MaxHP;
            }
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
            int rngdodge = rng.Next(1, 5);
            int rngdamage = rng.Next(-1, 2);
            int thisattack = rngdamage + monster.Attack;

            if (rngdodge != 1)
            {
                Player.CurrentHP -= thisattack;
                Console.SetCursorPosition(43, 15);
                Console.Write(new string(' ', Console.WindowWidth));
                Console.SetCursorPosition(43, 15);
                Console.Write($"{monster.Name} Attacks {Player.Name} for {thisattack} damage!".ToUpper());
                Console.SetCursorPosition(80, 8);
                Console.Write(new string(' ', Console.WindowWidth));
                Console.SetCursorPosition(80, 8);
                Console.Write($"HP LEFT : {Player.CurrentHP}");
                Console.SetCursorPosition(56, 16);
                Console.ReadLine();
            }
            else
            {
                Console.SetCursorPosition(43, 15);
                Console.Write(new string(' ', Console.WindowWidth));
                Console.SetCursorPosition(43, 15);
                Console.Write($"Nice Moves, You managed to dodge The {monster.Name }'s attack!");
                Console.ReadLine();
            }
            


        }

        private void PlayerMove(IsMonster monster)
        {
            int rngdodge = rng.Next(1, 5);
            int rngdamage = rng.Next(-1, 2);
            int thisattack = rngdamage + Player.Attack;
            if (rngdodge != 1)
            {
                monster.HP -= thisattack;
                Console.SetCursorPosition(43, 15);
                Console.Write(new string(' ', Console.WindowWidth));
                Console.SetCursorPosition(43, 15);
                Console.Write($"You Attack {monster.Name} for {thisattack} damage!".ToUpper());
                Console.SetCursorPosition(30, 8);
                Console.Write(new string(' ', Console.WindowWidth));
                Console.SetCursorPosition(30, 8);
                Console.Write($"HP LEFT : {monster.HP}");
                Console.SetCursorPosition(80, 8);
                Console.Write($"HP LEFT : {Player.CurrentHP}");
                Console.SetCursorPosition(56, 16);
                Console.ReadLine();
            }
            else
            {
                Console.SetCursorPosition(43, 15);
                Console.Write(new string(' ', Console.WindowWidth));
                Console.SetCursorPosition(43, 15);
                Console.Write($"Dang it, The {monster.Name } dodged your attack!");
                Console.ReadLine();
            }


        }


        public IsMonster GenerateMonster()
        {
            int a;
            Random rng = new Random();
            a = rng.Next(1, 4);
            {
                if (a == 1)
                {
                    
                    return new Rat(Level);
                }
                else if (a == 2)
                {
                    return new Skeleton(Level);
                }
                else
                {
                    return new Zombie(Level);
                }
            }


        }
        public void PrintShit()
        {

        }
    }
    

}
