using System;

namespace FindTheExit
{
    class Player : Character
    {
        private Game game;

        public Player(int startX, int startY, Game game) : base(startX, startY)
        {
            this.game = game;
        }

        public void Move(ConsoleKey key, Maze maze)
        {
            int newX = X, newY = Y;

            switch (key)
            {
                case ConsoleKey.UpArrow:
                    newY--;
                    break;
                case ConsoleKey.DownArrow:
                    newY++;
                    break;
                case ConsoleKey.LeftArrow:
                    newX--;
                    break;
                case ConsoleKey.RightArrow:
                    newX++;
                    break;
            }

            if (maze.IsValidMove(newX, newY))
            {
                X = newX;
                Y = newY;
                MoveCount++;
                game.CheckCollision();
            }
        }
    }
}
