using System;
using System.Threading;
using EZInput;
using game.BL;

namespace game
{
    class Program
    {
        static void Main(string[] args)
        {
            character tom = new character();
             string[,] pattern = new string[24, 1] {
            {" _________________________________________________________________________________________________________________" },
            {"|                                                                                                                 |" },
            {"|                                                                                                                 |" },
            {"|                                                                                                                 |" },
            {"|                                                                                                                 |" },
            {"|                                                                                                                 |" },
            {"|                                                                                                                 |" },
            {"|                                                                                                                 |" },
            {"|                                                                                                                 |" },
            {"|                                                                                                                 |" },
            {"|                                                                                                                 |" },
            {"|                                                                                                                 |" },
            {"|                                                                                                                 |" },
            {"|                                                                                                                 |" },
            {"|                                                                                                                 |" },
            {"|                                                                                                                 |" },
            {"|                                                                                                                 |" },
            {"|                                                                                                                 |" },
            {"|                                                                                                                 |" },
            {"|                                                                                                                 |" },
            {"|                                                                                                                 |" },
            {"|                                                                                                                 |" },
            {"|                                                                                                                 |" },
            {" _________________________________________________________________________________________________________________" }
            };
            int enemyX = 4;
            int enemyY = 10;

            int[] bulletX = new int[100];
            int[] bulletY = new int[100];
            int bulletCount = 0;

            int score = 0;
            int lives = 3;

            string enemyDirection = "Right";

            int timer = 0;


            int[] fruitsX = { 10, 50, 65, 35, 100 };
            int[] fruitsY = { 5, 20, 15, 18, 1 };

            char[] tom1 = { ' ', ' ', '_', ' ', ' ', ' ', ',', '_', ',', ' ', ' ', ' ', '_', ' ', ' ' };
            char[] tom2 = { ' ', '/', ' ', '`', '\'', '=', ')', ' ', '(', '=', '\'', '`', ' ', '\\', ' ' };
            char[] tom3 = { '/', '.', '-', '.', '-', '.', '\\', ' ', '/', '.', '-', '.', '-', '.', '\\' };
            char[] tom4 = { ' ', ' ', ' ', ' ', ' ', ' ', ' ', '\'', ' ', ' ', ' ', ' ', ' ', ' ', ' ' };

            char[] cheetah1 = { ',', '-', '-', '-', '-', '-', ',', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' };
            char[] cheetah2 = { ',', '-', '-', '\'', '-', '-', '-', ':', '-', '-', '-', '`', '-', '-', ',' };
            char[] cheetah3 = { '=', '=', '(', 'o', ')', '-', '-', '-', '-', '-', '(', 'o', ')', '=', '=', 'J' };


            Console.Clear();
            road(pattern);
            generatefruits(fruitsX, fruitsY);
            printFruits(fruitsX, fruitsY);
            printCheetah(enemyX, enemyY, cheetah1, cheetah2, cheetah3);
            printTom(tom, tom1, tom2, tom3, tom4);

            while (true)
            {
                if (Keyboard.IsKeyPressed(Key.LeftArrow))
                {
                    moveTomLeft(tom, tom1, tom2, tom3, tom4, lives, pattern);
                }
                if (Keyboard.IsKeyPressed(Key.RightArrow))
                {
                    moveTomRight(tom, tom1, tom2, tom3, tom4, lives, pattern);
                }
                if (Keyboard.IsKeyPressed(Key.UpArrow))
                {
                    moveTomUp(tom, tom1, tom2, tom3, tom4, lives, pattern);
                }
                if (Keyboard.IsKeyPressed(Key.DownArrow))
                {
                    moveTomDown(tom, tom1, tom2, tom3, tom4, lives, pattern);
                }
                if (Keyboard.IsKeyPressed(Key.Space))
                {
                    generateBullet(bulletX, bulletCount, bulletY, tom);
                }
                printFruits(fruitsX, fruitsY);
                moveBullet(bulletCount, bulletX, bulletY, score, enemyY, fruitsX, fruitsY, pattern);
                printScore(score, lives);
                if (timer == 1)
                {
                    moveCheetah(enemyDirection, enemyX, enemyY, cheetah1, cheetah2, cheetah3, pattern);
                    timer = 0;
                }

                timer++;
                Thread.Sleep(30);
                if (lives <= 0)
                {
                    break;
                }
            }
            Console.Clear();
            Console.Write("Your Total Score is {0}", score);
        }

        static void road(string[,] pattern)
        {
            for (int i = 0; i < 24; i++)
            {
                for (int j = 0; j < 1; j++)
                {
                    Console.WriteLine(pattern[i, j]);
                }
            }
        }
        static void removeBulletFromArray(int index, int bulletCount, int[] bulletX, int[] bulletY)
        {
            for (int x = index; x < bulletCount - 1; x++)
            {
                bulletX[x] = bulletX[x + 1];
                bulletY[x] = bulletY[x + 1];
            }
            bulletCount--;
        }

        static void printBullet(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write("`");
        }
        static void eraseBullet(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(" ");
        }

        static void generatefruits(int[] fruitsX, int[] fruitsY)
        {
            Random r = new Random();
            int value = r.Next();
            for (int i = 0; i < 5; i++)
            {
                fruitsX[i] = value % 100;
            }
            Random p = new Random();
            int value1 = p.Next();
            for (int i = 0; i < 5; i++)
            {
                fruitsY[i] = value1 % 100;
            }
        }

        static void printFruits(int[] fruitsX, int[] fruitsY)
        {
            for (int i = 0; i < 5; i++)
            {
                Console.SetCursorPosition(fruitsX[i] + 5, fruitsY[i] + 1);
                Console.Write("@");
            }
        }

        static void removeFruits(int[] fruitsX, int[] fruitsY)
        {
            for (int i = 0; i < 5; i++)
            {
                Console.SetCursorPosition(fruitsX[i] + 5, fruitsY[i] + 1);
                Console.Write(" ");
            }
        }

        static void printScore(int score, int lives)
        {
            Console.SetCursorPosition(1, 25);
            Console.Write(" Score: {0}", score);
            Console.Write("\t Lives:{0}", lives);
        }
        static void moveBullet(int bulletCount, int[] bulletX, int[] bulletY, int score, int enemyY, int[] fruitsX, int[] fruitsY, string[,] pattern)
        {
            for (int x = 0; x < bulletCount; x++)
            {
                string next = pattern[bulletX[x], bulletY[x] - 1];
                if (next !=  " ")
                {
                    eraseBullet(bulletX[x], bulletY[x]);
                    removeBulletFromArray(x, bulletCount, bulletX, bulletY);
                    if (next == "@")
                    {
                        score++;
                        removeFruits(fruitsX, fruitsY);
                        generateFruits();
                        if (score % 10 == 0)
                        {
                            srand(time(0));
                            eraseCheetah(enemyX, enemyY);

                            enemyY = 5 + rand() % 10;

                        }
                    }
                }
                else
                {
                    eraseBullet(bulletX[x], bulletY[x]);
                    bulletY[x] = bulletY[x] - 1;
                    printBullet(bulletX[x], bulletY[x]);
                }
            }
        }
        static void generateBullet(int[] bulletX, int bulletCount, int[] bulletY, character tom)
        {
            bulletX[bulletCount] = tom.tomX + 7;
            bulletY[bulletCount] = tom.tomY;
            Console.SetCursorPosition(tom.tomX + 7, tom.tomY);
            Console.Write(".");
            bulletCount++;
        }
        static void eraseTom(character tom)
        {
            Console.SetCursorPosition(tom.tomX, tom.tomY);
            for (int index = 0; index < 15; index++)
            {
                Console.Write(" ");
            }
            Console.SetCursorPosition(tom.tomX, tom.tomY + 1);
            for (int index = 0; index < 15; index++)
            {
                Console.Write(" ");
            }
            Console.SetCursorPosition(tom.tomX, tom.tomY + 2);
            for (int index = 0; index < 15; index++)
            {
                Console.Write(" ");
            }
            Console.SetCursorPosition(tom.tomX, tom.tomY + 3);
            for (int index = 0; index < 15; index++)
            {
                Console.Write(" ");
            }
        }
        static void printTom(character tom, char[] tom1, char[] tom2, char[] tom3, char[] tom4)
        {
            Console.SetCursorPosition(tom.tomX, tom.tomY);
            for (int index = 0; index < 15; index++)
            {
                Console.Write(tom1[index]);
            }
            Console.SetCursorPosition(tom.tomX, tom.tomY + 1);
            for (int index = 0; index < 15; index++)
            {
                Console.Write(tom2[index]);
            }
            Console.SetCursorPosition(tom.tomX, tom.tomY + 2);
            for (int index = 0; index < 15; index++)
            {
                Console.Write(tom3[index]);
            }
            Console.SetCursorPosition(tom.tomX, tom.tomY + 2);
            for (int index = 0; index < 15; index++)
            {
                Console.Write(tom4[index]);
            }
        }
        static void moveTomDown(character tom, char[] tom1, char[] tom2, char[] tom3, char[] tom4, int lives, string [,] pattern)
        {
            string next = pattern[tom.tomX + 9, tom.tomY + 4];
            if (next == " ")
            {
                eraseTom(tom);
                tom.tomY = tom.tomY + 1;
                printTom(tom, tom1, tom2, tom3, tom4);
            }
            else
            {
                eraseTom(tom);
                printTom(tom, tom1, tom2, tom3, tom4);
                if (next != " ")
                {
                    eraseTom(tom);
                    lives--;
                    tom.tomY = 18;
                }
            }
        }
        static void moveTomUp(character tom, char[] tom1, char[] tom2, char[] tom3, char[] tom4, int lives, string[,] pattern)
        {
            string next = pattern[tom.tomX, tom.tomY - 1];
            if (next == " ")
            {
                eraseTom(tom);
                tom.tomY = tom.tomY - 1;
                printTom(tom , tom1, tom2, tom3, tom4);
            }
            else
            {
                eraseTom(tom);
                printTom(tom, tom1, tom2, tom3, tom4);
                if (next != " ")
                {
                    eraseTom(tom);
                    lives--;
                    tom.tomY = 18;
                }
            }

        }
        static void moveTomRight(character tom, char[] tom1, char[] tom2, char[] tom3, char[] tom4, int lives, string[,] pattern)
        {
            string next = pattern[tom.tomX + 17, tom.tomY];
            if (next == " ")
            {
                eraseTom(tom);
                tom.tomX = tom.tomX + 1;
                printTom(tom, tom1, tom2, tom3, tom4);
            }
            else
            {
                eraseTom(tom);
                printTom(tom, tom1, tom2, tom3, tom4);
                if (next != "|")
                {
                    eraseTom(tom);
                    lives--;
                    tom.tomY = 18;
                }
            }

        }
        static void moveTomLeft(character tom, char[] tom1, char[] tom2, char[] tom3, char[] tom4, int lives, string[,] pattern)
        {
            string next = pattern[tom.tomX - 1, tom.tomY];
            if (next == " ")
            {
                eraseTom(tom);
                tom.tomX = tom.tomX - 1;
                printTom(tom, tom1, tom2, tom3, tom4);
            }
            else
            {
                eraseTom(tom);
                printTom(tom, tom1, tom2, tom3, tom4);
                if (next != "|")
                {
                    eraseTom(tom);
                    lives--;
                    tom.tomY = 18;
                }

            }
        }
        static void printCheetah(int enemyX, int enemyY, char[] cheetah1, char[] cheetah2, char[] cheetah3)
        {
            Console.SetCursorPosition(enemyX, enemyY);
            for (int index = 0; index < 16; index++)
            {
                Console.Write(cheetah1[index]);
            }
            Console.SetCursorPosition(enemyX, enemyY + 1);
            for (int index = 0; index < 16; index++)
            {
                Console.Write(cheetah2[index]);
            }
            Console.SetCursorPosition(enemyX, enemyY + 2);
            for (int index = 0; index < 16; index++)
            {
                Console.Write(cheetah3[index]);
            }
        }
        static void eraseCheetah(int enemyX, int enemyY)
        {
            Console.SetCursorPosition(enemyX, enemyY);
            for (int index = 0; index < 16; index++)
            {
                Console.Write(" ");
            }
            Console.SetCursorPosition(enemyX, enemyY + 1);
            for (int index = 0; index < 16; index++)
            {
                Console.Write(" ");
            }
            Console.SetCursorPosition(enemyX, enemyY + 2);
            for (int index = 0; index < 16; index++)
            {
                Console.Write(" ");
            }
        }
        static void moveCheetah(string enemyDirection, int enemyX, int enemyY, char[] cheetah1, char[] cheetah2, char[] cheetah3, string[,] pattern)
        {

            if (enemyDirection == "Left")
            {
                string next = pattern[enemyX - 1, enemyY];
                if (next == " " || next == "@")
                {
                    eraseCheetah(enemyX, enemyY);
                    enemyX--;
                    printCheetah(enemyX, enemyY, cheetah1, cheetah2, cheetah3);
                }
                if (next == "|")
                {
                    enemyDirection = "Right";
                }
            }
            if (enemyDirection == "Right")
            {
                string next = pattern[enemyX + 16, enemyY];
                if (next == " " || next == "@")
                {
                    eraseCheetah(enemyX, enemyY);
                    enemyX++;
                    printCheetah(enemyX, enemyY, cheetah1, cheetah2, cheetah3);
                }
                if (next == "|")
                {
                    enemyDirection = "Left";
                }
            }
        }
        
    }
}
        

    
        
    

