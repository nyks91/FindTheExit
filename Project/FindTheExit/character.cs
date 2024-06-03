namespace FindTheExit
{
    abstract class Character
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int MoveCount { get; protected set; }

        public Character(int startX, int startY)
        {
            X = startX;
            Y = startY;
            MoveCount = 0;
        }

        public virtual void Move(Maze maze)
        {
           
        }

        public bool IsAtExit(Maze maze)
        {
            return X == maze.ExitX && Y == maze.ExitY;
        }
    }
}
