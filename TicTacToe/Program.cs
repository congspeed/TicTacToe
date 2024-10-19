using System;
using BoardLogic;

namespace TicTacToe
{
    class Program
    {
        static Board game = new Board();
        static Random rand = new Random();

        static void Main(string[] args)
        {
            int userTurn = -1;
            int computerTurn = -1;

            Console.WriteLine("Welcome to Tic-Tac-Toe!");
            printBoard();

            while (game.CheckWinner() == 0 && !game.IsBoardFull())
            {
                userTurn = getUserMove();
                game.Grid[userTurn] = 1;
                Console.WriteLine("You chose position: " + userTurn);
                printBoard();

                if (game.CheckWinner() != 0 || game.IsBoardFull())
                    break;

                computerTurn = getComputerMove();
                game.Grid[computerTurn] = 2;
                Console.WriteLine("Computer chooses position: " + computerTurn);
                printBoard();
            }

            int winner = game.CheckWinner();
            if (winner == 0 && game.IsBoardFull())
            {
                Console.WriteLine("It's a draw!");
            }
            else
            {
                Console.WriteLine("Player " + (winner == 1 ? "X" : "O") + " wins the game!");
            }

            Console.ReadLine();
        }

        private static int getUserMove()
        {
            int userTurn = -1;
            bool validInput = false;

            while (!validInput)
            {
                Console.WriteLine("Please enter a number from 0 to 8:");
                string input = Console.ReadLine();

                if (int.TryParse(input, out userTurn) && userTurn >= 0 && userTurn <= 8 && game.Grid[userTurn] == 0)
                {
                    validInput = true;
                }
                else
                {
                    Console.WriteLine("Invalid input or position already taken. Try again.");
                }
            }

            return userTurn;
        }

        private static int getComputerMove()
        {
            int computerTurn = -1;
            do
            {
                computerTurn = rand.Next(0, 9);
            } while (game.Grid[computerTurn] != 0); 

            return computerTurn;
        }

        private static void printBoard()
        {
            Console.WriteLine("Current Board:");
            for (int i = 0; i < 9; i++)
            {
                if (game.Grid[i] == 0)
                {
                    Console.Write(".");
                }
                else if (game.Grid[i] == 1)
                {
                    Console.Write("X");
                }
                else if (game.Grid[i] == 2)
                {
                    Console.Write("O");
                }

                if (i % 3 == 2)
                {
                    Console.WriteLine();
                }
            }
            Console.WriteLine();
        }
    }
}
