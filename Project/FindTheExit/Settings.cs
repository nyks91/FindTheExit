using System;

namespace FindTheExit
{
    class Settings
    {
        private static MusicPlayer musicPlayer = new MusicPlayer();
        private static bool isMusicPlaying = false;
        public static int StartingLevel { get; private set; } = 1;
        public static int StartingHealth { get; private set; } = 2;
        public static bool IsMusicEnabled { get; private set; } = true;

        public static void Show()
        {
            if (!isMusicPlaying && IsMusicEnabled)
            {
                musicPlayer.Play(MusicPlayer.GetFullMusicPath("Undertale_YourBestFriend"), 0.09f);
                isMusicPlaying = true;
            }

            if (!IsMusicEnabled)
            {
                musicPlayer.Stop();
                isMusicPlaying = false;
            }
            
            Console.Clear();
            Console.WriteLine("╔════════════════════════════╗");
            Console.WriteLine("║          SETTINGS          ║");
            Console.WriteLine("╠════════════════════════════╣");
            Console.WriteLine("║ 1. MUSIC SETTINGS          ║");
            Console.WriteLine("║ 2. GAME OPTIONS            ║");
            Console.WriteLine("╠════════════════════════════╣");
            Console.WriteLine("║ 3. BACK TO MAIN MENU       ║");
            Console.WriteLine("╚════════════════════════════╝");

            while (true)
            {
                ConsoleKey key = Console.ReadKey(true).Key;
                if (key == ConsoleKey.D1 || key == ConsoleKey.NumPad1)
                {
                    Console.Clear();
                    Console.WriteLine("╔════════════════════════════╗");
                    Console.WriteLine("║       MUSIC SETTINGS       ║");
                    Console.WriteLine("╠════════════════════════════╣");
                    Console.WriteLine("║ 1. PLAY/PAUSE              ║");
                    Console.WriteLine("║ 2. ENABLE/DISABLE MUSIC    ║");
                    Console.WriteLine("╠════════════════════════════╣");
                    Console.WriteLine("║ 3. BACK TO SETTINGS MENU   ║");
                    Console.WriteLine("╚════════════════════════════╝");
                    while (true)
                    {
                        ConsoleKey musicKey = Console.ReadKey(true).Key;
                        if (musicKey == ConsoleKey.D1 || musicKey == ConsoleKey.NumPad1)
                        {
                            if (isMusicPlaying)
                            {
                                musicPlayer.Pause();
                                isMusicPlaying = false;
                                Console.WriteLine("╔════════════════════════════╗");
                                Console.WriteLine("║        MUSIC PAUSED        ║");
                                Console.WriteLine("╚════════════════════════════╝");
                            }
                            else
                            {
                                musicPlayer.Resume();
                                isMusicPlaying = true;
                                Console.WriteLine("╔════════════════════════════╗");
                                Console.WriteLine("║        MUSIC RESUMED       ║");
                                Console.WriteLine("╚════════════════════════════╝");
                            }
                        }
                        else if (musicKey == ConsoleKey.D2 || musicKey == ConsoleKey.NumPad2)
                        {
                            IsMusicEnabled = !IsMusicEnabled;
                            if (!IsMusicEnabled)
                            {
                                musicPlayer.Stop();
                                isMusicPlaying = false;
                                Console.WriteLine("╔════════════════════════════╗");
                                Console.WriteLine("║       MUSIC DISABLED       ║");
                                Console.WriteLine("╚════════════════════════════╝");
                            } 
                            else
                            {
                                musicPlayer.Play(MusicPlayer.GetFullMusicPath("Undertale_YourBestFriend"), 0.09f);
                                isMusicPlaying = true;
                                Console.WriteLine("╔════════════════════════════╗");
                                Console.WriteLine("║        MUSIC ENABLED       ║");
                                Console.WriteLine("╚════════════════════════════╝");
                            }
                        }
                        else if (musicKey == ConsoleKey.D3 || musicKey == ConsoleKey.NumPad4)
                        {
                            Show();
                        }
                    }
                }
                else if (key == ConsoleKey.D2 || key == ConsoleKey.NumPad2)
                {
                    Console.Clear();
                    Console.WriteLine("╔════════════════════════════╗");
                    Console.WriteLine("║        GAME OPTIONS        ║");
                    Console.WriteLine("╠════════════════════════════╣");
                    Console.WriteLine("║ 1. CHANGE STARTING LEVEL   ║");
                    Console.WriteLine("║ 2. CHANGE STARTING HEALTH  ║");
                    Console.WriteLine("╠════════════════════════════╣");
                    Console.WriteLine("║ 3. BACK TO SETTINGS MENU   ║");
                    Console.WriteLine("╚════════════════════════════╝");
                    while (true)
                    {
                        ConsoleKey gameKey = Console.ReadKey(true).Key;
                        if (gameKey == ConsoleKey.D1 || gameKey == ConsoleKey.NumPad1)
                        {
                            Console.Clear();
                            Console.WriteLine("╔════════════════════════════════════════════════════╗");
                            Console.WriteLine("║                    CHANGE LEVEL                    ║");
                            Console.WriteLine("╠════════════════════════════════════════════════════╣");
                            Console.WriteLine("║ Enter the level you want to start the game with:   ║");
                            Console.WriteLine("║ 1. Easy (Level 1)                                  ║");
                            Console.WriteLine("║ 2. Medium (Level 2)                                ║");
                            Console.WriteLine("║ 3. Hard (Level 3)                                  ║");
                            Console.WriteLine("║ 4. Very Hard (Level 4)                             ║");
                            Console.WriteLine("║ 5. Impossible (Level 5)                            ║");
                            Console.WriteLine("╠════════════════════════════════════════════════════╣");
                            Console.WriteLine("║ 6. BACK TO GAME OPTIONS MENU                       ║");
                            Console.WriteLine("╚════════════════════════════════════════════════════╝");
                            while (true) {
                                ConsoleKey levelKey = Console.ReadKey(true).Key;
                                if (levelKey == ConsoleKey.D1 || levelKey == ConsoleKey.NumPad1)
                                {
                                    StartingLevel = 1;
                                    Console.WriteLine();
                                    Console.WriteLine("╔════════════════════════════════════════════════════╗");
                                    Console.WriteLine("║ Game level set to Easy (Level 1).                  ║");
                                    Console.WriteLine("╚════════════════════════════════════════════════════╝");
                                }
                                else if (levelKey == ConsoleKey.D2 || levelKey == ConsoleKey.NumPad2)
                                {
                                    StartingLevel = 2;
                                    Console.WriteLine();
                                    Console.WriteLine("╔════════════════════════════════════════════════════╗");
                                    Console.WriteLine("║ Game level set to Medium (Level 2).                ║");
                                    Console.WriteLine("╚════════════════════════════════════════════════════╝");
                                }
                                else if (levelKey == ConsoleKey.D3 || levelKey == ConsoleKey.NumPad3)
                                {
                                    StartingLevel = 3;
                                    Console.WriteLine();
                                    Console.WriteLine("╔════════════════════════════════════════════════════╗");
                                    Console.WriteLine("║ Game level set to Hard (Level 3).                  ║");
                                    Console.WriteLine("╚════════════════════════════════════════════════════╝");
                                }
                                else if (levelKey == ConsoleKey.D4 || levelKey == ConsoleKey.NumPad4)
                                {
                                    StartingLevel = 4;
                                    Console.WriteLine();
                                    Console.WriteLine("╔════════════════════════════════════════════════════╗");
                                    Console.WriteLine("║ Game level set to Very Hard (Level 4).             ║");
                                    Console.WriteLine("║ This level is very hard to complete.               ║");
                                    Console.WriteLine("║ You will need a lot of luck to complete it.        ║");
                                    Console.WriteLine("╚════════════════════════════════════════════════════╝");
                                }
                                else if (levelKey == ConsoleKey.D5 || levelKey == ConsoleKey.NumPad5)
                                {
                                    StartingLevel = 5;
                                    Console.WriteLine();
                                    Console.WriteLine("╔════════════════════════════════════════════════════╗");
                                    Console.WriteLine("║ Game level set to Impossible (Level 5).            ║");
                                    Console.WriteLine("║ This level is impossible to complete.              ║");
                                    Console.WriteLine("║ Good luck :)                                       ║");
                                    Console.WriteLine("╚════════════════════════════════════════════════════╝");
                                }
                                else if (levelKey == ConsoleKey.D6 || levelKey == ConsoleKey.NumPad6)
                                {
                                    Show();
                                }
                            }
                        }
                        else if (gameKey == ConsoleKey.D2 || gameKey == ConsoleKey.NumPad2)
                        {
                            Console.Clear();
                            Console.WriteLine("╔════════════════════════════════════════════════════╗");
                            Console.WriteLine("║                    CHANGE HEALTH                   ║");
                            Console.WriteLine("╠════════════════════════════════════════════════════╣");
                            Console.WriteLine("║ Enter the health you want to start the game with:  ║");
                            Console.WriteLine("║ 1. 1 Health                                        ║");
                            Console.WriteLine("║ 2. 2 Health                                        ║");
                            Console.WriteLine("║ 3. 3 Health                                        ║");
                            Console.WriteLine("║ 4. 4 Health                                        ║");
                            Console.WriteLine("║ 5. 5 Health                                        ║");
                            Console.WriteLine("╠════════════════════════════════════════════════════╣");
                            Console.WriteLine("║ 6. BACK TO GAME OPTIONS MENU                       ║");
                            Console.WriteLine("╚════════════════════════════════════════════════════╝");
                            while (true) {
                                ConsoleKey healthKey = Console.ReadKey(true).Key;
                                if (healthKey == ConsoleKey.D1 || healthKey == ConsoleKey.NumPad1)
                                {
                                    StartingHealth = 1;
                                    Console.WriteLine();
                                    Console.WriteLine("╔════════════════════════════════════════════════════╗");
                                    Console.WriteLine("║ Starting health set to 1 Health.                   ║");
                                    Console.WriteLine("║ You will have only one chance to complete the game.║");
                                    Console.WriteLine("║ Good luck :)                                       ║");
                                    Console.WriteLine("╚════════════════════════════════════════════════════╝");
                                } else if (healthKey == ConsoleKey.D2 || healthKey == ConsoleKey.NumPad2)
                                {
                                    StartingHealth = 2;
                                    Console.WriteLine();
                                    Console.WriteLine("╔════════════════════════════════════════════════════╗");
                                    Console.WriteLine("║ Starting health set to 2 Health.                   ║");
                                    Console.WriteLine("╚════════════════════════════════════════════════════╝");
                                } else if (healthKey == ConsoleKey.D3 || healthKey == ConsoleKey.NumPad3)
                                {
                                    StartingHealth = 3;
                                    Console.WriteLine();
                                    Console.WriteLine("╔════════════════════════════════════════════════════╗");
                                    Console.WriteLine("║ Starting health set to 3 Health.                   ║");
                                    Console.WriteLine("╚════════════════════════════════════════════════════╝");
                                } else if (healthKey == ConsoleKey.D4 || healthKey == ConsoleKey.NumPad4)
                                {
                                    StartingHealth = 4;
                                    Console.WriteLine();
                                    Console.WriteLine("╔════════════════════════════════════════════════════╗");
                                    Console.WriteLine("║ Starting health set to 4 Health.                   ║");
                                    Console.WriteLine("╚════════════════════════════════════════════════════╝");
                                } else if (healthKey == ConsoleKey.D5 || healthKey == ConsoleKey.NumPad5)
                                {
                                    StartingHealth = 5;
                                    Console.WriteLine();
                                    Console.WriteLine("╔════════════════════════════════════════════════════╗");
                                    Console.WriteLine("║ Starting health set to 5 Health.                   ║");
                                    Console.WriteLine("║ It will be easier to complete the game with this.  ║");
                                    Console.WriteLine("║ You so bad :)                                      ║");
                                    Console.WriteLine("╚════════════════════════════════════════════════════╝");
                                } else if (healthKey == ConsoleKey.D6 || healthKey == ConsoleKey.NumPad6)
                                {
                                    Show();
                                }
                            }
                        }
                        else if (gameKey == ConsoleKey.D3 || gameKey == ConsoleKey.NumPad3)
                        {
                            Show();
                        }
                    }
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
