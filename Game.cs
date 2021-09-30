using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;

namespace Roguelike
{
    public class Game
    {
        public Player player { get; set; } = new Player();
        public int level { get; set; } = 1;

        public Game()
        {

        }
        public bool GenerateLevel()
        {
            Board gameBoard = new Board(25, 100);
            bool leaveLevel = false;
            gameBoard.FillBoardWithMapObjects();
            gameBoard.PrintBoard(level);
            
            Console.WriteLine();
            while (leaveLevel == false)
            {
                if(PlayerMovement(gameBoard) == false)
                {
                    return false;
                }
                    
                if (gameBoard.PlayerXCoord == gameBoard.Width-1 && gameBoard.PlayerYCoord == gameBoard.Height-1)
                {
                    leaveLevel = true;
                    Console.Clear();
                }  
            }

            return true;
            
            
        }
        public bool PlayerGoRight(Board gameBoard)
        {
            if (gameBoard.PlayerXCoord < gameBoard.Width-1)
            {
                var a = gameBoard.MapGrid[gameBoard.PlayerXCoord + 1, gameBoard.PlayerYCoord];
                if (a is null || a is Passable || (a is Water && player.canSwim == true))
                {
                    
                    gameBoard.PlayerXCoord++;
                    Console.SetCursorPosition(gameBoard.PlayerXCoord, gameBoard.Height - gameBoard.PlayerYCoord);

                    if (gameBoard.MapGrid[gameBoard.PlayerXCoord - 1, gameBoard.PlayerYCoord] is null)
                        Console.Write(" ");
                    else
                        gameBoard.MapGrid[gameBoard.PlayerXCoord - 1, gameBoard.PlayerYCoord].MapsIcon();
                    Console.SetCursorPosition(gameBoard.PlayerXCoord+1, gameBoard.Height - gameBoard.PlayerYCoord);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("P");
                    Console.ForegroundColor = ConsoleColor.White;
                    return true;
                }
                else
                    return false;
            }
            return false;
        }
        public bool PlayerGoLeft(Board gameBoard)
        {
            if (gameBoard.PlayerXCoord > 0)
            {
                var a = gameBoard.MapGrid[gameBoard.PlayerXCoord - 1, gameBoard.PlayerYCoord];
                if ((a is null || a is Passable || (a is Water && player.canSwim == true)))
                {
                    gameBoard.PlayerXCoord--;
                    Console.SetCursorPosition(gameBoard.PlayerXCoord + 2, gameBoard.Height - gameBoard.PlayerYCoord);

                    if (gameBoard.MapGrid[gameBoard.PlayerXCoord + 1, gameBoard.PlayerYCoord] is null)
                        Console.Write(" ");
                    else
                        gameBoard.MapGrid[gameBoard.PlayerXCoord + 1, gameBoard.PlayerYCoord].MapsIcon();
                    Console.SetCursorPosition(gameBoard.PlayerXCoord+1, gameBoard.Height - gameBoard.PlayerYCoord);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("P");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.SetCursorPosition(0, gameBoard.Height + 2);
                    return true;
                }
                else
                    return false;
            }
            return false;
        }
        public bool PlayerGoUp(Board gameBoard)
        {
            if (gameBoard.PlayerYCoord < gameBoard.Height-1)
            {
                var a = gameBoard.MapGrid[gameBoard.PlayerXCoord, gameBoard.PlayerYCoord + 1];
                if (a is null || a is Passable || (a is Water && player.canSwim == true))
                {
                    gameBoard.PlayerYCoord++;
                    Console.SetCursorPosition(gameBoard.PlayerXCoord+1, gameBoard.Height - gameBoard.PlayerYCoord+1);

                    if (gameBoard.MapGrid[gameBoard.PlayerXCoord, gameBoard.PlayerYCoord - 1] is null)
                        Console.Write(" ");
                    else
                        gameBoard.MapGrid[gameBoard.PlayerXCoord, gameBoard.PlayerYCoord - 1].MapsIcon();
                    Console.SetCursorPosition(gameBoard.PlayerXCoord+1, gameBoard.Height - gameBoard.PlayerYCoord);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("P");
                    Console.ForegroundColor = ConsoleColor.White;
                    //Console.SetCursorPosition(0, gameBoard.Height + 2);
                    //if (gameBoard.MapGrid[gameBoard.PlayerXCoord, gameBoard.PlayerYCoord] is Passable)
                    //{
                    //    Console.Write("You are standing on ");
                    //    Console.Write(gameBoard.MapGrid[gameBoard.PlayerXCoord, gameBoard.PlayerYCoord].MapObjectDescription());
                    //}
                    //else
                    //    Console.Write(new string(' ', Console.WindowWidth));
                    return true;

                }
                else
                    return false;
            }
            return false;
        }
        public bool PlayerGoDown(Board gameBoard)
        {
            if (gameBoard.PlayerYCoord > 0)
            {
                var a = gameBoard.MapGrid[gameBoard.PlayerXCoord, gameBoard.PlayerYCoord - 1];
                if ((a is null || a is Passable || (a is Water && player.canSwim == true)))
                {

                    Console.SetCursorPosition(gameBoard.PlayerXCoord+1, gameBoard.Height - gameBoard.PlayerYCoord);

                    if (gameBoard.MapGrid[gameBoard.PlayerXCoord, gameBoard.PlayerYCoord] is null)
                        Console.Write(" ");
                    else
                        gameBoard.MapGrid[gameBoard.PlayerXCoord, gameBoard.PlayerYCoord].MapsIcon();
                    Console.SetCursorPosition(gameBoard.PlayerXCoord+1, gameBoard.Height - gameBoard.PlayerYCoord+1);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("P");
                    Console.ForegroundColor = ConsoleColor.White;
                    //Console.SetCursorPosition(0, gameBoard.Height + 2);
                    //if (gameBoard.MapGrid[gameBoard.PlayerXCoord, gameBoard.PlayerYCoord-1] is Passable)
                    //{
                    //    Console.Write("You are standing on ");
                    //    Console.Write(gameBoard.MapGrid[gameBoard.PlayerXCoord, gameBoard.PlayerYCoord-1].MapObjectDescription());
                    //}
                    //else
                    //    Console.Write(new string(' ', Console.WindowWidth));
                    gameBoard.PlayerYCoord--;
                    
                    
                    return true;

                }
                else
                    return false;
            }
            else
                return false;
        }
        public bool PlayerMovement(Board gameBoard)
        {
            bool validMove = false;
            while (validMove == false)
            {

                Console.Write(" ");
                Console.SetCursorPosition(0, gameBoard.Height + 2);
                ConsoleKey input = Console.ReadKey().Key;
                
                switch (input)
                {
                    case ConsoleKey.A:
                        validMove = PlayerGoLeft(gameBoard);
                        break;
                    case ConsoleKey.S:
                        validMove = PlayerGoDown(gameBoard);
                        break;
                    case ConsoleKey.D:
                        validMove = PlayerGoRight(gameBoard);
                        break;
                    case ConsoleKey.W:
                        validMove = PlayerGoUp(gameBoard);
                        break;
                }
                if (gameBoard.MapGrid[gameBoard.PlayerXCoord, gameBoard.PlayerYCoord] is not Water)
                {
                    player.swimStamina = 3;
                    player.canSwim = true;
                }
                else if (gameBoard.MapGrid[gameBoard.PlayerXCoord, gameBoard.PlayerYCoord] is Water)
                {

                    Console.SetCursorPosition(20, gameBoard.Height + 3);
                    player.Swim();
                    Console.Write($"Swimming: {player.swimStamina} stamina left");
                    
                    if (player.swimStamina == 0)
                    {
                        int count = 0;
                        IsMapObject a;

                        if (gameBoard.PlayerXCoord == 0)
                            count++;
                        if (gameBoard.PlayerXCoord == gameBoard.Width - 1)
                            count++;
                        if (gameBoard.PlayerYCoord == 0)
                            count++;
                        if (gameBoard.PlayerYCoord == gameBoard.Height - 1)
                            count++;
                        
                        if (gameBoard.PlayerXCoord < gameBoard.Width-1)
                        {
                            a = gameBoard.MapGrid[gameBoard.PlayerXCoord + 1, gameBoard.PlayerYCoord];
                            if (a is not Passable && a is not null)
                                count++;
                        }
                        if(gameBoard.PlayerXCoord > 0)
                        {
                            a = gameBoard.MapGrid[gameBoard.PlayerXCoord - 1, gameBoard.PlayerYCoord];
                            if (a is not Passable && a is not null)
                                count++;
                        }
                        if(gameBoard.PlayerYCoord > 0)
                        {
                            a = gameBoard.MapGrid[gameBoard.PlayerXCoord, gameBoard.PlayerYCoord-1];
                            if (a is not Passable && a is not null)
                                count++;
                        }
                        if(gameBoard.PlayerYCoord < gameBoard.Height-1)
                        {
                            a = gameBoard.MapGrid[gameBoard.PlayerXCoord, gameBoard.PlayerYCoord+1];
                            if (a is not Passable &&  a is not null)
                                count++;

                        }
                        if (count == 4)
                        {
                            Console.Clear();
                            Console.WriteLine("Game over. Du drunkna, sopa");
                            return false;
                        }
                        else
                        {
                            player.Swim();                           
                        }
                    }
                    
                    
                }
            }           
                
                Console.SetCursorPosition(0, gameBoard.Height + 3);
                if (gameBoard.MapGrid[gameBoard.PlayerXCoord, gameBoard.PlayerYCoord] is IsMapObject)
                {
                    if(gameBoard.MapGrid[gameBoard.PlayerXCoord, gameBoard.PlayerYCoord] is not Water)
                        Console.Write(new string(' ', Console.WindowWidth));
                    else
                        Console.Write(new string(' ', 15));
                Console.SetCursorPosition(0, gameBoard.Height + 3);
                    Console.Write("Biome: ");
                    Console.Write(gameBoard.MapGrid[gameBoard.PlayerXCoord, gameBoard.PlayerYCoord].MapObjectDescription());
                }
                else
                    Console.Write(new string(' ', Console.WindowWidth));
            return true;
        }
        
        }

    }

