using System;

namespace FindTheExit
{
    class HowToPlay
    {
        private static MusicPlayer musicPlayer = new MusicPlayer();
        private static bool isMusicPlaying = false;

        public static void Show()
        {
            if (!isMusicPlaying && Settings.IsMusicEnabled)
            {
                musicPlayer.Play(MusicPlayer.GetFullMusicPath("Undertale_Ruins"), 0.12f);
                isMusicPlaying = true;
            }
            
            Console.Clear();
            Console.WriteLine("╔════════════════════════════╗");
            Console.WriteLine("║        HOW TO PLAY?        ║");
            Console.WriteLine("╠════════════════════════════╣");
            Console.WriteLine("║ 1. RULES                   ║");
            Console.WriteLine("║ 2. CONTROLS                ║");
            Console.WriteLine("╠════════════════════════════╣");
            Console.WriteLine("║ 3. BACK TO MAIN MENU       ║");
            Console.WriteLine("╚════════════════════════════╝");

            while (true)
            {
                ConsoleKey key = Console.ReadKey(true).Key;
                if (key == ConsoleKey.D1 || key == ConsoleKey.NumPad1)
                {
                    Console.Clear();
                    Console.WriteLine("╔═══════════════════════════════════════════════════════════════════╗");
                    Console.WriteLine("║                           **  RULES  **                           ║");
                    Console.WriteLine("╠═══════════════════════════════════════════════════════════════════╣");
                    Console.WriteLine("║ 1. You are the player represented by the character 'P'.           ║");
                    Console.WriteLine("║ 2. You need to reach the exit represented by the character 'E'.   ║");
                    Console.WriteLine("║ 3. Avoid the monster represented by the character 'C'.            ║");
                    Console.WriteLine("║ 4. If you collide with the monster, you lose health.              ║");
                    Console.WriteLine($"║ 5. You have {Settings.StartingHealth} health points. If you lose all health points, the   ║");
                    Console.WriteLine("║    game is over.                                                  ║");
                    Console.WriteLine("║ 6. You can move up, down, left, and right using the arrow keys.   ║");
                    Console.WriteLine("╠═══════════════════════════════════════════════════════════════════╣");
                    Console.WriteLine("║ [!] Press any key to go back to the How To Play menu.             ║");
                    Console.WriteLine("╚═══════════════════════════════════════════════════════════════════╝");
                    Console.ReadKey();
                    Show();
                }
                else if (key == ConsoleKey.D2 || key == ConsoleKey.NumPad2)
                {
                    Console.Clear();
                    Console.WriteLine("╔═══════════════════════════════════════════════════════════════════╗");
                    Console.WriteLine("║                           **  CONTROLS  **                        ║");
                    Console.WriteLine("╠═══════════════════════════════════════════════════════════════════╣");
                    Console.WriteLine("║ Use the arrow keys to move the player:                            ║");
                    Console.WriteLine("║ [UP KEY]     -  Move Up                                           ║");
                    Console.WriteLine("║ [DOWN KEY]   -  Move Down                                         ║");
                    Console.WriteLine("║ [LEFT KEY]   -  Move Left                                         ║");
                    Console.WriteLine("║ [RIGHT KEY]  -  Move Right                                        ║");
                    Console.WriteLine("╠═══════════════════════════════════════════════════════════════════╣");
                    Console.WriteLine("║ [!] Press any key to go back to the How To Play menu.             ║");
                    Console.WriteLine("╚═══════════════════════════════════════════════════════════════════╝");
                    Console.ReadKey();
                    Show();
                }
                else if (key == ConsoleKey.D3 || key == ConsoleKey.NumPad3)
                {
                    musicPlayer.Stop();
                    isMusicPlaying = false;
                    MainMenu.Show();
                }
                else if (key == ConsoleKey.Escape)
                {
                    Environment.Exit(0);
                }
            }
        }
    }
}
