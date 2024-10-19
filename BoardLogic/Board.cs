using System;

namespace BoardLogic
{
    public class Board
    {
        public int[] Grid { get; set; }

        public Board()
        {
            Grid = new int[9];  
            for (int i = 0; i < 9; i++)
            {
                Grid[i] = 0; 
            }
        }


        public bool IsBoardFull()
        {
            return !Array.Exists(Grid, element => element == 0);
        }

        public int CheckWinner()
        {
            int[,] winningCombinations = new int[,]
            {
                { 0, 1, 2 }, { 3, 4, 5 }, { 6, 7, 8 }, 
                { 0, 3, 6 }, { 1, 4, 7 }, { 2, 5, 8 }, 
                { 0, 4, 8 }, { 2, 4, 6 } 
            };

            for (int i = 0; i < winningCombinations.GetLength(0); i++)
            {
                int a = winningCombinations[i, 0];
                int b = winningCombinations[i, 1];
                int c = winningCombinations[i, 2];

                if (Grid[a] == Grid[b] && Grid[b] == Grid[c] && Grid[a] != 0)
                {
                    return Grid[a];
                }
            }

            return 0;
        }
    }
}
