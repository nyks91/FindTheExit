using System;

namespace FindTheExit
{
    class MainMenu
    {
        private static MusicPlayer musicPlayer = new MusicPlayer();
        private static bool isMusicPlaying = false;

        public static void Show()
        {
            if (!isMusicPlaying && Settings.IsMusicEnabled)
            {
                musicPlayer.Play(MusicPlayer.GetFullMusicPath("Undertale_StartMenu"), 0.09f);
                isMusicPlaying = true;
            }

            Console.Clear();
            Console.WriteLine("╔═══════════════════════════╗");
            Console.WriteLine("║         MAIN MENU         ║");
            Console.WriteLine("╠═══════════════════════════╣");
            Console.WriteLine("║ 1. PLAY GAME              ║");
            Console.WriteLine("║ 2. SETTINGS               ║");
            Console.WriteLine("║ 3. EXIT                   ║");
            Console.WriteLine("╠═══════════════════════════╣");
            Console.WriteLine("║ 4. HOW TO PLAY?           ║");
            Console.WriteLine("╚═══════════════════════════╝");

            while (true)
            {
                ConsoleKey key = Console.ReadKey(true).Key;
                if (key == ConsoleKey.D1 || key == ConsoleKey.NumPad1)
                {
                    musicPlayer.Stop();
                    isMusicPlaying = false;
                    Game game = new Game();
                    game.CurrentLevel = Settings.StartingLevel;
                    game.PlayerHealth = Settings.StartingHealth;
                    game.Run();
                    break;
                }
                else if (key == ConsoleKey.D2 || key == ConsoleKey.NumPad2)
                {
                    musicPlayer.Stop();
                    isMusicPlaying = false;
                    Settings.Show();
                }
                else if (key == ConsoleKey.D3 || key == ConsoleKey.NumPad3)
                {
                    musicPlayer.Stop();
                    isMusicPlaying = false;
                    Environment.Exit(0);
                }
                else if (key == ConsoleKey.D4 || key == ConsoleKey.NumPad4)
                {
                    musicPlayer.Stop();
                    isMusicPlaying = false;
                    HowToPlay.Show();
                }
                else if (key == ConsoleKey.Escape)
                {
                    isMusicPlaying = false;
                    musicPlayer.Stop();
                    Environment.Exit(0);
                }
            }
        }
    }
}
