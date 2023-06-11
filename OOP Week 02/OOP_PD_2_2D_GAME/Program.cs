using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using EZInput;

namespace OOP_PD_1_Game
{
    class Program
    {
        public static char[,] Maze = {
            {'#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#'},
            {'#',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','#',' ',' ',' ',' ',' ',' ',' ','#'},
            {'#',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','#',' ',' ',' ',' ',' ',' ',' ','#'},
            {'#',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','#',' ',' ',' ',' ',' ',' ',' ','#'},
            {'#',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','#',' ',' ',' ',' ',' ',' ',' ','#'},
            {'#',' ',' ',' ',' ',' ',' ',' ','#','#','#','#','#',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','#'},
            {'#',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','#'},
            {'#',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','#'},
            {'#',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','#','#',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','#'},
            {'#',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','#',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','#'},
            {'#',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','#',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','#'},
            {'#',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','#',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','#'},
            {'#',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','#','#','#','#','#','#',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','#'},
            {'#',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','#','#','#','#','#','#','#','#','#','#','#','#','#','#',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','#'},
            {'#',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','#'},
            {'#',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','#'},
            {'#',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','#',' ',' ',' ',' ',' ',' ',' ',' ',' ','#'},
            {'#',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','#',' ',' ',' ',' ',' ',' ',' ',' ',' ','#'},
            {'#',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','#',' ',' ',' ',' ',' ',' ',' ',' ',' ','#'},
            {'#',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','#',' ',' ',' ',' ',' ',' ',' ',' ',' ','#'},
            {'#',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','#'},
            {'#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#'}};
        // Player character
        public static char box = (char)166;
        public static char arrowHead = (char)31;
        public static char[,] fighter = {
                                         {' ', arrowHead, ' '},
                                         {box, box, box}
                                        };

        // Player coordinates
        public static int TankX = 10;
        public static int TankY = 15;

        // Player Bullet coordinates
        public static int BulletCount = 0;
        public static int[] BulletX = new int[100];
        public static int[] BulletY = new int[100];
        public static bool[] isBulletActive = new bool[100];

        // EnemyA Coordinates
        public static int EnemyAX = 3;
        public static int EnemyAY = 3;

        // Enemy A charachter
        public static char[,] EnemyA = {
            {'O', ' ', ' ', 'O'},
            {' ', 'O', 'O', ' '},
            {' ', 'O', 'O', ' '},
            {'O', ' ', ' ', 'O'}};
        public static string EnemyADirection = "right";
        public static int score = 0;

        // Enemy B coordinates
        public static int EnemyBX = 91;
        public static int EnemyBY = 3;
        // Enemy B charachter
        public static char[,] EnemyB = {
                             {'/', '-', '\\'},
                             {'|', '@', '|'},
                             {'\\', '-', '/'}};

        public static string EnemyBDirection = "up";

        // EnemyC Coordinates
        public static int EnemyCX = 3;
        public static int EnemyCY = 8;
        // Enemy C charachter
        public static char[,] EnemyC = {
            {'O', '-', 'O'},
            {'<', '*', '>'},
            {'<', '+', '>'},
            {'@', '-', '@'}};

        public static string EnemyCDirection;
        static public void Main(string[] args)
        {
            Game();
            Console.ReadKey();
        }
        public static void Code()
        {
            for (int x = 0; x < 256; x++)
            {
                Console.WriteLine("{0} {1}", x, (char)x);
            }
        }
        public static void Game()
        {
            while (true)
            {
                int option = DisplayWelcome();
                if (option == 1)
                {
                    BulletCount = 0;
                    score = 0;
                    Console.Clear();
                    printMaze();
                    printSpaceFighter();
                    printEnemyA();
                    printEnemyB();
                    printEnemyC();
                    while (true)
                    {
                        moveBullet();
                        printScore();
                        if (Keyboard.IsKeyPressed(Key.LeftArrow))
                        {
                            char next = GetCharatxy(TankX - 1, TankY);
                            char next2 = GetCharatxy(TankX - 1, TankY + 1);
                            if (next == ' ' && next2 == ' ')
                            {
                                erasePlayer();
                                TankX--;
                                printSpaceFighter();
                            }
                        }
                        if (Keyboard.IsKeyPressed(Key.RightArrow))
                        {
                            char next = GetCharatxy(TankX + 3, TankY);
                            char next2 = GetCharatxy(TankX + 3, TankY + 1);
                            if (next == ' ' && next2 == ' ')
                            {
                                erasePlayer();
                                TankX++;
                                printSpaceFighter();
                            }
                        }
                        if (Keyboard.IsKeyPressed(Key.UpArrow))
                        {
                            char next = GetCharatxy(TankX + 1, TankY - 1);
                            char next2 = GetCharatxy(TankX, TankY - 1);
                            char next3 = GetCharatxy(TankX + 2, TankY - 1);
                            if (next == ' ' && next2 == ' ' && next3 == ' ')
                            {
                                erasePlayer();
                                TankY--;
                                printSpaceFighter();
                            }
                        }
                        if (Keyboard.IsKeyPressed(Key.DownArrow))
                        {
                            char next = GetCharatxy(TankX, TankY + 2);
                            char next2 = GetCharatxy(TankX + 1, TankY + 2);
                            char next3 = GetCharatxy(TankX + 2, TankY + 2);
                            if (next == ' ' && next2 == ' ' && next3 == ' ')
                            {
                                erasePlayer();
                                TankY++;
                                printSpaceFighter();
                            }
                        }
                        if (Keyboard.IsKeyPressed(Key.Space))
                        {
                            generateBullet();
                        }
                        moveEnemyA();
                        moveEnemyB();
                        moveEnemyC();
                        enemyCollisionWithBullet();
                        enemyBCollissionWithBullet();
                        enemyCCollissionWithBullet();
                        Thread.Sleep(200);
                        if (BulletCount == 99)
                        {
                            break;
                        }
                    }
                    Console.SetCursorPosition(50, 35);
                    if (score >= 50)
                    {
                        Console.Write("Congrats! You have Succeeded.....");
                        Console.ReadKey();
                        Thread.Sleep(2000);
                    }
                    else
                    {
                        Console.Write("Nah! Better Luck next time.....");
                        Console.ReadKey();
                        Thread.Sleep(2000);
                    }
                    Console.SetCursorPosition(50, 36);
                    Console.WriteLine("Press any key to continue>>>");
                    Console.ReadKey();
                }
                else if (option == 2)
                {
                    char love = (char)3;
                    Console.Clear();
                    Console.SetCursorPosition(40, 10);
                    Console.Write("Welcome! Space invaders is a shooting game. In this Game there are 3 enemies. You have to");
                    Console.SetCursorPosition(40, 11);
                    Console.Write("shoot the enemies by pressing space bar. You have to make sure that your score is more   ");
                    Console.SetCursorPosition(40, 12);
                    Console.Write("50. Shooting Enemy once increases your score by 1. You can move your Player by using     ");
                    Console.SetCursorPosition(40, 13);
                    Console.Write("arrow key. The Enemies move horizontally, vertically and randomly.Best of luck and also  ");
                    Console.SetCursorPosition(40, 14);
                    Console.Write("like this game, As it is my first game and is build with a lot of effort.");
                    Console.SetCursorPosition(48, 15);
                    Console.Write("Thank You so much " + love);
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.SetCursorPosition(40, 17);
                    Console.Write("Press any key to continue>");
                    Console.ReadKey();
                }
                else if (option == 3)
                {
                    Console.Clear();
                    break;
                }
                else
                {
                    Console.WriteLine("Enter valid option!!!!!.");
                    Console.WriteLine("Press any key to continue>>>>");
                    Console.ReadKey();
                }
            }
        }

        public static int DisplayWelcome()
        {
            int option;
            char box = (char)166;
            Console.Clear();
            Console.WriteLine("  ####   ####        #             ####     #########");
            Console.WriteLine("##   ##   #   #     # #          ##    ##   #      # ");
            Console.WriteLine(" ##       #    #   #   #       ##           #        ");
            Console.WriteLine("   ##     #   #   #     #     ##            #        ");
            Console.WriteLine("    ##    ###    #########    ##            ####     ");
            Console.WriteLine(" #   ##   @     #         #    ##           #        ");
            Console.WriteLine("##  ##    #    #           #     ##    ##   #      # ");
            Console.WriteLine(" ####     #   #             #      ####     ######## ");
            Console.WriteLine(" * * * * * * * * * * * * * * * * * * * * * * * * * * ");
            Console.WriteLine("* * * * * * * * * * * * * * * * * * * * * * * * * * *");
            Console.WriteLine("                  #######  #     # #         #     #      ###      ######## ###      ####   ");
            Console.WriteLine("                     #     ##    # #         #    # #      #  ##   #     #   #  #   #     # ");
            Console.WriteLine("                     #     # #   #  #       #    #   #     #    ## #         #   #   #      ");
            Console.WriteLine("                     #     #  #  #   #     #    #######    #     # #####     ####      #    ");
            Console.WriteLine("                     #     #   # #    #   #    #       #   #    ## #         # #         #  ");
            Console.WriteLine("                     #     #    ##     # #    #         #  #  ##   #         #  #   #     # ");
            Console.WriteLine("                  ######## #     #      #    #           # ###     ########  #   #   #####  ");
            Console.WriteLine("                  * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * ");
            Console.WriteLine("                   * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *");
            Thread.Sleep(250);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("                               Loading:  ");
            for (int count = 1; count < 20; count++)
            {
                Console.Write(box);
                Thread.Sleep(100);
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("1. New Game");
            Console.WriteLine("2. Help");
            Console.WriteLine("3. Exit");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Enter any option to continue>>>>");
            option = int.Parse(Console.ReadLine());
            return option;
        }
        public static char GetCharatxy(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            ConsoleKeyInfo keyInfo = Console.ReadKey(intercept: true);
            char character = keyInfo.KeyChar;
            return character;
        }
        public static void erasePlayer()
        {
            Console.SetCursorPosition(TankX, TankY);
            for (int row = 0; row < 2; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    Console.Write(" ");
                }
                TankY++;
                Console.SetCursorPosition(TankX, TankY);
            }
            TankY -= 2;
        }
        public static void printSpaceFighter()
        {
            Console.SetCursorPosition(TankX, TankY);
            for (int row = 0; row < 2; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    Console.Write(fighter[row, col]);
                }
                TankY++;
                Console.SetCursorPosition(TankX, TankY);
            }
            TankY -= 2;
        }
        public static void printMaze()
        {
            Console.WriteLine();
            Console.WriteLine();
            for (int row = 0; row < Maze.GetLength(0); row++)
            {
                for (int col = 0; col < Maze.GetLength(1); col++)
                {
                    Console.Write(Maze[row, col]);
                }
                Console.WriteLine();
            }

        }
        public static void generateBullet()
        {
            char next = GetCharatxy(TankX + 1, TankY - 1);
            if (next != '#')
            {
                BulletX[BulletCount] = TankX + 1;
                BulletY[BulletCount] = TankY - 1;
                isBulletActive[BulletCount] = true;
                Console.SetCursorPosition(TankX + 1, TankY - 1);
                Console.Write(".");
                BulletCount++;
            }
        }
        public static void moveBullet()
        {
            for (int index = 0; index < BulletCount; index++)
            {
                if (isBulletActive[index] == true)
                {
                    char next = GetCharatxy(BulletX[index], BulletY[index] - 1);
                    if (next != ' ')
                    {
                        eraseBullet(BulletX[index], BulletY[index]);
                        makeBulletInactive(index);
                    }
                    else
                    {
                        eraseBullet(BulletX[index], BulletY[index]);
                        BulletY[index] = BulletY[index] - 1;
                        printBullet(BulletX[index], BulletY[index]);
                    }
                }
            }
        }
        public static void eraseBullet(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(" ");
        }
        public static void printBullet(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(".");
        }
        public static void makeBulletInactive(int index)
        {
            isBulletActive[index] = false;
        }
        public static void enemyCollisionWithBullet()
        {
            for (int index = 0; index < BulletCount; index++)
            {
                if (isBulletActive[index] == true)
                {
                    if (BulletX[index] == EnemyAX && BulletY[index] - 1 == EnemyAY + 3)
                    {
                        addScore();
                    }
                    if (BulletX[index] == EnemyAX + 1 && BulletY[index] - 1 == EnemyAY + 2)
                    {
                        addScore();
                    }
                    if (BulletX[index] == EnemyAX + 2 && BulletY[index] - 1 == EnemyAY + 2)
                    {
                        addScore();
                    }
                    if (BulletX[index] == EnemyAX + 3 && BulletY[index] - 1 == EnemyAY + 3)
                    {
                        addScore();
                    }
                }
            }
        }
        public static void printEnemyA()
        {
            Console.SetCursorPosition(EnemyAX, EnemyAY);
            for (int row = 0; row < 4; row++)
            {
                for (int col = 0; col < 4; col++)
                {
                    Console.Write(EnemyA[col, row]);
                }
                EnemyAY++;
                Console.SetCursorPosition(EnemyAX, EnemyAY);
            }
            EnemyAY = EnemyAY - 4;
        }
        public static void moveEnemyA()
        {
            if (EnemyADirection == "right")
            {
                char next = GetCharatxy(EnemyAX + 4, EnemyAY);
                if (next == ' ')
                {
                    EraseEnemyA();
                    EnemyAX++;
                    printEnemyA();
                }
                if (next == '#')
                {
                    EraseEnemyA();
                    EnemyADirection = "left";
                }
            }
            if (EnemyADirection == "left")
            {
                char next = GetCharatxy(EnemyAX - 1, EnemyAY);
                if (next == ' ')
                {
                    EraseEnemyA();
                    EnemyAX--;
                    printEnemyA();
                }
                if (next == '#')
                {
                    EraseEnemyA();
                    EnemyADirection = "right";
                }
            }
        }
        public static void EraseEnemyA()
        {
            Console.SetCursorPosition(EnemyAX, EnemyAY);
            for (int row = 0; row < 4; row++)
            {
                for (int col = 0; col < 4; col++)
                {
                    Console.Write(" ");
                }
                EnemyAY++;
                Console.SetCursorPosition(EnemyAX, EnemyAY);
            }
            EnemyAY -= 4;
        }
        public static void printEnemyB()
        {
            Console.SetCursorPosition(EnemyBX, EnemyBY);
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    Console.Write(EnemyB[row, col]);
                }
                EnemyBY++;
                Console.SetCursorPosition(EnemyBX, EnemyBY);
            }
            EnemyBY -= 3;
        }
        public static void moveEnemyB()
        {
            if (EnemyBDirection == "up")
            {
                char next = GetCharatxy(EnemyBX, EnemyBY - 1);
                if (next == ' ')
                {
                    EraseEnemyB();
                    EnemyBY--;
                    printEnemyB();
                }
                if (next == '#')
                {
                    EraseEnemyB();
                    EnemyBDirection = "down";
                }
            }
            if (EnemyBDirection == "down")
            {
                char next = GetCharatxy(EnemyBX, EnemyBY + 3);
                if (next == ' ')
                {
                    EraseEnemyB();
                    EnemyBY++;
                    printEnemyB();
                }
                if (next == '#')
                {
                    EraseEnemyB();
                    EnemyBDirection = "up";
                }
            }
        }
        public static void EraseEnemyB()
        {
            Console.SetCursorPosition(EnemyBX, EnemyBY);
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    Console.Write(" ");
                }
                EnemyBY++;
                Console.SetCursorPosition(EnemyBX, EnemyBY);
            }
            EnemyBY -= 3;
        }
        public static void addScore()
        {
            score++;
        }
        public static void printScore()
        {
            Console.SetCursorPosition(110, 20);
            Console.Write("Score : " + score);
        }
        public static void printEnemyC()
        {
            Console.SetCursorPosition(EnemyCX, EnemyCY);
            for (int row = 0; row < 4; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    Console.Write(EnemyC[row, col]);
                }
                EnemyCY++;
                Console.SetCursorPosition(EnemyCX, EnemyCY);
            }
            EnemyCY -= 4;
        }
        public static void moveEnemyC()
        {
            Random rnd = new Random();
            int RandomNumber = rnd.Next();
            int rem = RandomNumber % 4;
            if (rem == 0)
            {
                EnemyCDirection = "up";
            }
            else if (rem == 1)
            {
                EnemyCDirection = "down";
            }
            else if (rem == 2)
            {
                EnemyCDirection = "left";
            }
            else if (rem == 3)
            {
                EnemyCDirection = "right";
            }

            if (EnemyCDirection == "up")
            {
                char next = GetCharatxy(EnemyCX, EnemyCY - 1);
                if (next == ' ')
                {
                    EraseEnemyC();
                    EnemyCY--;
                    printEnemyC();
                }
            }
            if (EnemyCDirection == "down")
            {
                char next = GetCharatxy(EnemyCX, EnemyCY + 4);
                if (next == ' ')
                {
                    EraseEnemyC();
                    EnemyCY++;
                    printEnemyC();
                }
            }
            if (EnemyCDirection == "right")
            {
                char next = GetCharatxy(EnemyCX + 3, EnemyCY);
                if (next == ' ')
                {
                    EraseEnemyC();
                    EnemyCX++;
                    printEnemyC();
                }
            }
            if (EnemyCDirection == "left")
            {
                char next = GetCharatxy(EnemyCX - 1, EnemyCY);
                if (next == ' ')
                {
                    EraseEnemyC();
                    EnemyCX--;
                    printEnemyC();
                }
            }
        }
        public static void EraseEnemyC()
        {
            Console.SetCursorPosition(EnemyCX, EnemyCY);
            for (int row = 0; row < 4; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    Console.Write(" ");
                }
                EnemyCY++;
                Console.SetCursorPosition(EnemyCX, EnemyCY);
            }
            EnemyCY -= 4;
        }
        public static void enemyBCollissionWithBullet()
        {
            for (int index = 0; index < BulletCount; index++)
            {
                if (isBulletActive[index] == true)
                {
                    if (BulletX[index] == EnemyBX && BulletY[index] - 1 == EnemyBY + 3)
                    {
                        addScore();
                        addScore();
                    }
                    if (BulletX[index] == EnemyBX + 1 && BulletY[index] - 1 == EnemyBY + 3)
                    {
                        addScore();
                        addScore();
                    }
                    if (BulletX[index] == EnemyBX + 2 && BulletY[index] - 1 == EnemyBY + 3)
                    {
                        addScore();
                        addScore();
                    }
                }
            }
        }
        public static void enemyCCollissionWithBullet()
        {
            for (int index = 0; index < BulletCount; index++)
            {
                if (isBulletActive[index] == true)
                {
                    if (BulletX[index] == EnemyCX && BulletY[index] - 1 == EnemyCY + 4)
                    {
                        addScore();
                    }
                    if (BulletX[index] == EnemyCX + 1 && BulletY[index] - 1 == EnemyCY + 4)
                    {
                        addScore();
                    }
                    if (BulletX[index] == EnemyCX + 2 && BulletY[index] - 1 == EnemyCY + 4)
                    {
                        addScore();
                    }
                }
            }
        }
    }
}
