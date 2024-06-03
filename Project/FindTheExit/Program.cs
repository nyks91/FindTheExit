using System;

namespace FindTheExit
{
    class Program
    {
        static void Main(string[] args)
        {
            LoadingScreen.Show();
            Game game = new Game();
            game.Run();
        }
    }
}
