using System;
using System.IO;

namespace FindTheExit
{
    class Maze
    {
        private char[,] grid;
        public int Width { get; private set; }
        public int Height { get; private set; }
        public int ExitX { get; private set; }
        public int ExitY { get; private set; }

        public Maze(char[,] grid, int exitX, int exitY)
        {
            this.grid = grid;
            Width = grid.GetLength(1);
            Height = grid.GetLength(0);
            ExitX = exitX;
            ExitY = exitY;
        }

        public static Maze ParseFileToArray(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException($"Could not find file '{filePath}'");
            }

            string[] lines = File.ReadAllLines(filePath);
            int height = lines.Length;
            int width = lines[0].Length;
            char[,] grid = new char[height, width];

            int exitX = -1, exitY = -1;

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    grid[y, x] = lines[y][x];
                    if (lines[y][x] == 'E')
                    {
                        exitX = x;
                        exitY = y;
                    }
                }
            }

            if (exitX == -1 || exitY == -1)
            {
                throw new InvalidOperationException("The maze must have an exit 'E'.");
            }

            return new Maze(grid, exitX, exitY);
        }

        public bool IsValidMove(int x, int y)
        {
            char[] wallChars = { '#', '─', '│', '┐', '└', '┘', '┌', '├', '┬', '┤', '┴', '┼', '_', '|'};
            return x >= 0 && x < Width && y >= 0 && y < Height && Array.IndexOf(wallChars, grid[y, x]) == -1;
        }

        public void PrintMaze(int playerX, int playerY, int monsterX, int monsterY)
        {
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    if (x == playerX && y == playerY)
                    {
                        Console.Write('P');
                    }
                    else if (x == monsterX && y == monsterY)
                    {
                        Console.Write('C');
                    }
                    else
                    {
                        Console.Write(grid[y, x]);
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
