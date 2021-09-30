﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roguelike
{
    public class Board
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public IsMapObject[,] MapGrid { get; set; }
        public int PlayerXCoord { get; set; } = 0;
        public int PlayerYCoord { get; set; } = 0;


        public Board(int height, int width)
        {
            Width = width;
            Height = height;
            MapGrid = new IsMapObject[Width, Height];
            
        }
        public void PrintBoard(int level)
        {
            char a;
            for (int i = Height-1; i>= 0; i--)
            {
                for(int j = 0; j < Width; j++)
                {
                    if (j == PlayerXCoord && i == PlayerYCoord)
                    {
                        Console.Write("P");
                        continue;      
                    }
                    else if (MapGrid[j, i] is IsMapObject)
                    { 
                        a = MapGrid[j,i].MapsIcon();
                        Console.Write(a);   
                    }
                    else
                        Console.Write(" ");
                }
                Console.Write('#');
                Console.WriteLine();
            }
            for(int i =0; i<Width+1; i++)
            {
                Console.Write("#");
            }
            Console.SetCursorPosition(45, Height + 1);
            Console.Write("Level " + level);

        }
        public void FillBoardWithMapObjects()
        {
            for (int i = 0; i <= (Height+Width)/2; i++)
            {
                AddRock();
                AddWater();
            }
            for(int i = 0; i <= (Height + Width); i++)
            {
                AddTree();
            }
        }
        public void AddWater()
        {
            int a, b;
            Random rngManip = new Random();
            Water water;
            Water lake = new Water(3, 4);
            Water puddle = new Water(2, 2);

            a = rngManip.Next(0, 11);
            if (a <= 3)
            {
                water = puddle;
            }

            else
                water = lake;
            a = rngManip.Next(0, Width);
            b = rngManip.Next(0, Height);

            for (int i = 0; i < water.Heigth; i++)
            {
                for (int j = 0; j < water.Length; j++)
                {
                    if (i + a >= Width || j + b >= Height)
                        continue;
                    if (MapGrid[i + a, j + b] == null)
                        MapGrid[i + a, j + b] = water;
                    

                }
            }

        }

        public void AddTree()
        {
            int a, b;
            Random rngManip = new Random();
            Tree tree;
            Tree forest = new Tree(3,2);
            Tree trees = new Tree(1, 1);
            a = rngManip.Next(0, 11);
            if (a <= 3)
            {
                tree = forest;
            }
            else
                tree = trees;
            
            a = rngManip.Next(0, Width);
            b = rngManip.Next(0, Height);

            for (int i = 0; i < tree.Heigth; i++)
            {
                for (int j = 0; j < tree.Length; j++)
                {
                    if (i + a >= Width || j + b >= Height)
                        continue;
                    MapGrid[i + a, j + b] = tree;
                   
                }
            }
        }
       
        public void AddRock()
        {
            int a, b;
            Random rngManip = new Random();
            Rock rock;
            a = rngManip.Next(0, 21);
            Rock smallRock = new Rock(2, 2);
            Rock mediumRock = new Rock(3, 2);
            Rock largeRock = new Rock(3, 3);

            if (a <= 5)
            {
                rock = smallRock;
            }
            else if (a > 5 && a < 15)
            {
                rock = mediumRock;
            }
            else
                rock = largeRock;


            a = rngManip.Next(0, Width);
            b = rngManip.Next(0, Height);

            for (int i = 0; i < rock.Heigth; i++)
            {
                for (int j = 0; j < rock.Length; j++)
                {
                    if (i + a >= Width || j + b >= Height)
                        continue;
                    if ((i + a >= Width - 2 || i + a < 1) && (j + b >= Height - 2 || j + b < 1))
                        continue;
                    else
                        MapGrid[i + a, j + b] = rock;
                }
            }

        }
    }
}

//public void AddRock(Board board)
//{
//    int a, b;
//    Random myTal = new Random();
//    string[,] rockSize = new string[Length, Height];
//    a = myTal.Next(1, board.BoardSize);
//    b = myTal.Next(1, board.BoardSize);
//    board.Boardfield[a, b] = "O";

//    for (int i = 0; i < Height; i++)
//        for (int j = 0; j < Length; j++)
//        {
//            if (i + a >= board.BoardSize || j + b >= board.BoardSize)
//                continue;
//            if (i + a == board.BoardSize - 1 && j + b == board.BoardSize - 1)
//                continue;
//            if (board.Boardfield[i + a, j + b] == ".")
//                board.Boardfield[i + a, j + b] = "O";
//        }