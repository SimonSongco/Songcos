using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Net;

namespace Songcos
{
    internal class Program
    {
        static string RandomNumber;
        static string Answer;
        static void RNGMethod()
        {
            Random RNG1 = new Random();
            Random RNG2 = new Random();
            Random RNG3 = new Random();
            int First;
            int Second;
            int Third;

            First = RNG1.Next(1, 6);

            while (true)
            {
                Second = RNG2.Next(1, 6);

                if (First == Second)
                {
                    Second = RNG2.Next(1, 6);
                }
                else { break; }
            }
            while (true)
            {
                Third = RNG3.Next(1, 6);

                if (First == Third || Second == Third)
                {
                    Third = RNG2.Next(1, 6);
                }
                else { break; }
            }
            RandomNumber = $"{First}{Second}{Third}";
        }
        static (int, int) Validation(int CorrectPosition, int CorrectNumber)
        {
            for (int i = 0; i < Answer.Length; i++)
            {
                if (RandomNumber[i] == Answer[i])
                {
                    CorrectPosition++;
                }
                for (int j = 0; j < RandomNumber.Length; j++)
                {
                    if (RandomNumber[i] == Answer[j])
                    {
                        CorrectNumber++;
                    }
                }
            }
            return (CorrectPosition, CorrectNumber);
        }
        static void Game()
        {
            int Attempts = 6;
            bool Game = true;
            while (Game)
            {
                int CorrectNumber = 0;
                int CorrectPosition = 0;

                Console.WriteLine($"Attempts Left: {Attempts}");
                Console.WriteLine();
                Console.Write("Enter Number: ");

                Console.ForegroundColor = ConsoleColor.Cyan;
                Answer = Console.ReadLine();
                Console.ResetColor();
                Console.WriteLine();

                (CorrectPosition, CorrectNumber) = Validation(CorrectPosition, CorrectNumber);

                Console.WriteLine($"Correct Number: {CorrectNumber}");
                Console.WriteLine($"Correct Position: {CorrectPosition}");
                Console.WriteLine("===================");

                Attempts--;

                if (CorrectNumber == 3 && CorrectPosition == 3)
                {
                    Console.WriteLine("You WON!");
                    Console.WriteLine("[1] New Game");
                    Console.WriteLine("[2] Main Menu");
                    string Choice = Console.ReadLine();

                    switch (Choice)
                    {
                        case "1":
                            Console.Clear();
                            RNGMethod();
                            Attempts = 6;
                            continue;
                        case "2":
                            Game = false;
                            break;
                        default:
                            Console.WriteLine("ENTER ONLY THE VALID CHOICE!");
                            Thread.Sleep(1000);
                            break;
                    }
                    continue;
                }

                if (Attempts == 0)
                {
                    Console.WriteLine("No More Attempts Left! Try Again!");
                    Console.WriteLine("[1] New Game");
                    Console.WriteLine("[2] Main Menu");
                    string Choice = Console.ReadLine();

                    switch (Choice)
                    {
                        case "1":
                            Console.Clear();
                            RNGMethod();
                            Attempts = 6;
                            continue;
                        case "2":
                            Game = false;
                            break;
                        default:
                            Console.WriteLine("ENTER ONLY THE VALID CHOICE!");
                            Thread.Sleep(1000);
                            break;
                    }
                    continue;
                }
            }
        }
        static void Main(string[] args)
        {
            while(true)
            {
                RNGMethod();
                Console.WriteLine("WELCOME TO CODE GAME!");
                Console.WriteLine();
                Console.WriteLine("[1] Play");
                Console.WriteLine("[2] Exit");

                string Choice = Console.ReadLine();

                switch (Choice)
                {
                    case "1":
                        Console.Clear();
                        Game();
                        break;
                    case "2":
                        break;
                    default:
                        Console.WriteLine("ENTER ONLY VALID CHOICES");
                        break;
                }
            }
        }
    }
}