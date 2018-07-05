﻿using System;
class StartUp
{
    static char[][] room;
    static void Main()
    {
        InitializeTheRoom();
        char[] moves;
        int[] samPosition;
        LocateThePositionOfSam(out moves, out samPosition);
        for (int i = 0; i < moves.Length; i++)
        {
            for (int row = 0; row < room.Length; row++)
                EnemyMoves(row);
            SamMovesThroughTheRoom(moves, samPosition, i);
        }
    }

    private static void SamMovesThroughTheRoom(char[] moves, int[] samPosition, int i)
    {
        int[] getEnemy = new int[2];
        for (int j = 0; j < room[samPosition[0]].Length; j++)
        {
            if (room[samPosition[0]][j] != '.' && room[samPosition[0]][j] != 'S')
            {
                getEnemy[0] = samPosition[0];
                getEnemy[1] = j;
            }
        }
        if (samPosition[1] < getEnemy[1] && room[getEnemy[0]][getEnemy[1]] == 'd' && getEnemy[0] == samPosition[0])
        {
            room[samPosition[0]][samPosition[1]] = 'X';
            Console.WriteLine($"Sam died at {samPosition[0]}, {samPosition[1]}");
            for (int row = 0; row < room.Length; row++)
            {
                for (int col = 0; col < room[row].Length; col++)
                {
                    Console.Write(room[row][col]);
                }
                Console.WriteLine();
            }
            Environment.Exit(0);
        }
        else if (getEnemy[1] < samPosition[1] && room[getEnemy[0]][getEnemy[1]] == 'b' && getEnemy[0] == samPosition[0])
        {
            room[samPosition[0]][samPosition[1]] = 'X';
            Console.WriteLine($"Sam died at {samPosition[0]}, {samPosition[1]}");
            for (int row = 0; row < room.Length; row++)
            {
                for (int col = 0; col < room[row].Length; col++)
                {
                    Console.Write(room[row][col]);
                }
                Console.WriteLine();
            }
            Environment.Exit(0);
        }


        room[samPosition[0]][samPosition[1]] = '.';
        switch (moves[i])
        {
            case 'U':
                samPosition[0]--;
                break;
            case 'D':
                samPosition[0]++;
                break;
            case 'L':
                samPosition[1]--;
                break;
            case 'R':
                samPosition[1]++;
                break;
            default:
                break;
        }
        room[samPosition[0]][samPosition[1]] = 'S';

        for (int j = 0; j < room[samPosition[0]].Length; j++)
        {
            if (room[samPosition[0]][j] != '.' && room[samPosition[0]][j] != 'S')
            {
                getEnemy[0] = samPosition[0];
                getEnemy[1] = j;
            }
        }
        if (room[getEnemy[0]][getEnemy[1]] == 'N' && samPosition[0] == getEnemy[0])
        {
            room[getEnemy[0]][getEnemy[1]] = 'X';
            Console.WriteLine("Nikoladze killed!");
            for (int row = 0; row < room.Length; row++)
            {
                for (int col = 0; col < room[row].Length; col++)
                {
                    Console.Write(room[row][col]);
                }
                Console.WriteLine();
            }
            Environment.Exit(0);
        }
    }

    private static void EnemyMoves(int row)
    {
        for (int col = 0; col < room[row].Length; col++)
        {
            if (room[row][col] == 'b')
            {
                if (row >= 0 && row < room.Length && col + 1 >= 0 && col + 1 < room[row].Length)
                {
                    room[row][col] = '.';
                    room[row][col + 1] = 'b';
                    col++;
                }
                else
                {
                    room[row][col] = 'd';
                }
            }
            else if (room[row][col] == 'd')
            {
                if (row >= 0 && row < room.Length && col - 1 >= 0 && col - 1 < room[row].Length)
                {
                    room[row][col] = '.';
                    room[row][col - 1] = 'd';
                }
                else
                {
                    room[row][col] = 'b';
                }
            }
        }
    }

    private static void LocateThePositionOfSam(out char[] moves, out int[] samPosition)
    {
        moves = Console.ReadLine().ToCharArray();
        samPosition = new int[2];
        for (int row = 0; row < room.Length; row++)
        {
            for (int col = 0; col < room[row].Length; col++)
            {
                if (room[row][col] == 'S')
                {
                    samPosition[0] = row;
                    samPosition[1] = col;
                }
            }
        }
    }

    private static void InitializeTheRoom()
    {
        int numOfRows = int.Parse(Console.ReadLine());
        room = new char[numOfRows][];

        for (int row = 0; row < numOfRows; row++)
        {
            var input = Console.ReadLine().ToCharArray();
            room[row] = new char[input.Length];
            for (int col = 0; col < input.Length; col++)
            {
                room[row][col] = input[col];
            }
        }
    }
}

