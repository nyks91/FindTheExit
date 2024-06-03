using System;

namespace FindTheExit
{
    class Monster : Character
    {
        private bool movingRight;

        public Monster(int startX, int startY) : base(startX, startY)
        {
            movingRight = true;
        }

        public override void Move(Maze maze)
        {
            int newX = movingRight ? X + 1 : X - 1;

            if (!maze.IsValidMove(newX, Y))
            {
                movingRight = !movingRight;
                newX = movingRight ? X + 1 : X - 1;
            }

            X = newX;
            MoveCount++;
        }
    }
}
