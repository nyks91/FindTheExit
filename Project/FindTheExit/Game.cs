using System;
using System.Threading;
using NAudio.Wave;

namespace FindTheExit
{
    class Game
    {
        private Maze maze;
        private Player player;
        private Monster monster;
        private MusicPlayer musicPlayer;

        public Game()
        {
            // currentLevel = 1;
            // playerHealth = 2;
            musicPlayer = new MusicPlayer();
            // InitializeLevel(currentLevel);
        }

        public int CurrentLevel { get; set; } = 1;
        public int PlayerHealth { get; set; } = 2;
        public Monster Monster { get { return monster; } }

        private static bool isMusicPlaying = false;


        public void InitializeLevel(int level)
        {
            // isMusicPlaying = false;
            string filePath = @$"levels\Level{level}.txt";
            maze = Maze.ParseFileToArray(filePath);
            player = new Player(1, 1, this);
            if (level == 1)
            {
                isMusicPlaying = false;
                if (!isMusicPlaying && Settings.IsMusicEnabled)
                {
                    musicPlayer.Play(MusicPlayer.GetFullMusicPath("Undertale_Level1-2"), 0.09f);
                    isMusicPlaying = true;
                }
                monster = new Monster(1, 5); 
            }
            else if (level == 2)
            {
                isMusicPlaying = false;
                if (!isMusicPlaying && Settings.IsMusicEnabled)
                {
                    musicPlayer.Play(MusicPlayer.GetFullMusicPath("Undertale_Level1-2"), 0.09f);
                    isMusicPlaying = true;
                }
                monster = new Monster(4, 9);
            } else if (level == 3)
            {
                isMusicPlaying = false;
                if (!isMusicPlaying && Settings.IsMusicEnabled)
                {
                    musicPlayer.Play(MusicPlayer.GetFullMusicPath("Undertale_Level3"), 0.09f);
                    isMusicPlaying = true;
                }
                monster = new Monster(8, 10);
            } else if (level == 4)
            {
                isMusicPlaying = false;
                if (!isMusicPlaying && Settings.IsMusicEnabled)
                {
                    musicPlayer.Play(MusicPlayer.GetFullMusicPath("Undertale_Level4"), 0.09f);
                    isMusicPlaying = true;
                }
                monster = new Monster(20, 11);
            } else if (level == 5)
            {
                isMusicPlaying = false;
                if (!isMusicPlaying && Settings.IsMusicEnabled)
                {
                    musicPlayer.Play(MusicPlayer.GetFullMusicPath("Undertale_Level5"), 0.09f);
                    isMusicPlaying = true;
                }
                monster = new Monster(18, 9);
            }
            else
            {
                musicPlayer.Play(MusicPlayer.GetFullMusicPath("Undertale_Ruins"), 0.09f);
                monster = null; 
            }
        }

        public void Run()
        {
            InitializeLevel(CurrentLevel);
            while (true)
            {
                Console.Clear();
                maze.PrintMaze(player.X, player.Y, monster?.X ?? -1, monster?.Y ?? -1);
                HealthPrinter.PrintPlayerHealth(PlayerHealth);

                HealthPrinter.PrintPlayerHealth(PlayerHealth);

                if (PlayerHealth == 1)
                {
                    Console.WriteLine(HealthPrinter.Health1);
                }
                else if (PlayerHealth == 2)
                {
                    Console.WriteLine(HealthPrinter.Health2);
                }
                else if (PlayerHealth == 3)
                {
                    Console.WriteLine(HealthPrinter.Health3);
                } else if (PlayerHealth == 4)
                {
                    Console.WriteLine(HealthPrinter.Health4);
                } else if (PlayerHealth == 5)
                {
                    Console.WriteLine(HealthPrinter.Health5);
                }

                if (player.IsAtExit(maze))
                {
                    if (CurrentLevel == 5)
                    {
                        if (isMusicPlaying)
                        {
                            musicPlayer.Play(MusicPlayer.GetFullMusicPath("FNAF_Yeey"), 0.11f);
                        }
                        FinishScreen.ShowFinish();
                        MainMenu.Show();
                        // break;
                    }
                    else {
                        CurrentLevel++;
                        musicPlayer.Stop();
                        isMusicPlaying = false;
                        InitializeLevel(CurrentLevel);
                        continue;
                    }
                    
                }

                ConsoleKey key = Console.ReadKey(true).Key;
                player.Move(key, maze);

                if (monster != null)
                {
                    monster.Move(maze); 
                }

                CheckCollision(); 
            }
        }

        public void CheckCollision()
        {
            if (monster != null && player.X == monster.X && player.Y == monster.Y)
            {
                PlayerHealth--;
                if (PlayerHealth >= 1)
                {
                    Console.Clear();
                    Console.WriteLine("╔═══════════════════════════════════════════════════════════════════╗");
                    Console.WriteLine("║                        **  INFORMATION  **                        ║");
                    Console.WriteLine("╠═══════════════════════════════════════════════════════════════════╣");
                    Console.WriteLine("║ You have been caught by a monster!                                ║");
                    Console.WriteLine($"║ You have {PlayerHealth} health points left.                                    ║");
                    Console.WriteLine("║ If you lose all health points, the game is over.                  ║");
                    Console.WriteLine("╠═══════════════════════════════════════════════════════════════════╣");
                    Console.WriteLine("║ [!] Press any key to continue...                                  ║");
                    Console.WriteLine("╚═══════════════════════════════════════════════════════════════════╝");
                    Console.ReadKey();
                } else if (PlayerHealth < 1)
                {
                    if (isMusicPlaying)
                    {
                        
                        
                    }
                    System.Threading.Thread.Sleep(1000);
                    Console.WriteLine();
                    Console.WriteLine("╔═══════════════════════════════════════════════════════════════════╗");
                    Console.WriteLine("║                        **  GAME OVER  **                          ║");
                    Console.WriteLine("╠═══════════════════════════════════════════════════════════════════╣");
                    Console.WriteLine("║ You have been captured by the monster! You return to Level 1...   ║");
                    Console.WriteLine("║                                                                   ║");
                    Console.WriteLine("║ [!] If you want to play again, press Q to continue...             ║");
                    Console.WriteLine("║ [!] If you want to return to the main menu, press M...            ║");
                    Console.WriteLine("╚═══════════════════════════════════════════════════════════════════╝");
                    if (isMusicPlaying) {
                        musicPlayer.Stop();
                        musicPlayer.Play(MusicPlayer.GetFullMusicPath("Undertale_GameOver"), 0.12f);
                        isMusicPlaying = false;
                    }

                    while (true)
                    {
                        ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                        if (keyInfo.Key == ConsoleKey.Q)
                        {
                            CurrentLevel = 1;
                            PlayerHealth = Settings.StartingHealth;
                            isMusicPlaying = false;
                            break;
                        } else if (keyInfo.Key == ConsoleKey.M)
                        {
                            musicPlayer.Stop();
                            isMusicPlaying = false;
                            MainMenu.Show();
                            break;
                        }
                    }
                }
                InitializeLevel(CurrentLevel);
                // isMusicPlaying = false;
            }
            else if (monster != null && player.MoveCount == monster.MoveCount)
            {
                if (player.X == monster.X && player.Y == monster.Y)
                {
                    PlayerHealth--; 
                    if (PlayerHealth >= 1)
                    {
                        Console.Clear();
                        Console.WriteLine("╔═══════════════════════════════════════════════════════════════════╗");
                        Console.WriteLine("║                        **  INFORMATION  **                        ║");
                        Console.WriteLine("╠═══════════════════════════════════════════════════════════════════╣");
                        Console.WriteLine("║ You have been caught by a monster!                                ║");
                        Console.WriteLine($"║ You have {PlayerHealth} health points left.                                    ║");
                        Console.WriteLine("║ If you lose all health points, the game is over.                  ║");
                        Console.WriteLine("╠═══════════════════════════════════════════════════════════════════╣");
                        Console.WriteLine("║ [!] Press any key to continue...                                  ║");
                        Console.WriteLine("╚═══════════════════════════════════════════════════════════════════╝");
                        Console.ReadKey();
                    } else if (PlayerHealth < 1)
                    {
                        if (isMusicPlaying)
                        {
                            musicPlayer.Stop();
                            isMusicPlaying = false;
                        }
                        System.Threading.Thread.Sleep(1000);
                        Console.WriteLine();
                        Console.WriteLine("╔═══════════════════════════════════════════════════════════════════╗");
                        Console.WriteLine("║                        **  GAME OVER  **                          ║");
                        Console.WriteLine("╠═══════════════════════════════════════════════════════════════════╣");
                        Console.WriteLine("║ You have been captured by the monster! You return to Level 1...   ║");
                        Console.WriteLine("║                                                                   ║");
                        Console.WriteLine("║ [!] If you want to play again, press Q to continue...             ║");
                        Console.WriteLine("║ [!] If you want to return to the main menu, press M...            ║");
                        Console.WriteLine("╚═══════════════════════════════════════════════════════════════════╝");
                        musicPlayer.Play(MusicPlayer.GetFullMusicPath("Undertale_GameOver"), 0.12f);
                        while (true)
                        {
                            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                            if (keyInfo.Key == ConsoleKey.Q)
                            {
                                CurrentLevel = 1;
                                PlayerHealth = Settings.StartingHealth;
                                isMusicPlaying = false;
                                break;
                            } else if (keyInfo.Key == ConsoleKey.M)
                            {
                                musicPlayer.Stop();
                                isMusicPlaying = false;
                                MainMenu.Show();
                                break;
                            }
                        }
                    }
                    InitializeLevel(CurrentLevel);
                }
            }
        }
    }
}
