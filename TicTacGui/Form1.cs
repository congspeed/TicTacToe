using BoardLogic;
using System;
using System.Windows.Forms;

namespace TicTacGui
{
    public partial class Form1 : Form
    {
        Board game = new Board();
        Button[] buttons = new Button[9];
        Random rand = new Random(); 

        public Form1()
        {
            InitializeComponent();
            game = new Board();

            buttons[0] = button1;
            buttons[1] = button2;
            buttons[2] = button3;
            buttons[3] = button4;
            buttons[4] = button5;
            buttons[5] = button6;
            buttons[6] = button7;
            buttons[7] = button8;
            buttons[8] = button9;

            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].Click += handleButtonclick;
                buttons[i].Tag = i;
            }
        }

        private void handleButtonclick(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            int gameSquareNumber = (int)clickedButton.Tag;

            if (game.Grid[gameSquareNumber] == 0) 
            {
                game.Grid[gameSquareNumber] = 1; 

                updateBoard();

                if (checkWinner(1))
                {
                    MessageBox.Show("You WIN!");
                    resetGame();
                    return;
                }

                computerChoose();
            }
        }

        private void computerChoose()
        {
            int computerMove;
            do
            {
                computerMove = rand.Next(0, 9); 
            }
            while (game.Grid[computerMove] != 0); 

            game.Grid[computerMove] = 2; 

            updateBoard();

            if (checkWinner(2))
            {
                MessageBox.Show("Computer WINS!");
                resetGame();
            }
        }

        private bool checkWinner(int player)
        {
            int[,] winningCombinations = new int[,]
            {
                { 0, 1, 2 }, { 3, 4, 5 }, { 6, 7, 8 }, 
                { 0, 3, 6 }, { 1, 4, 7 }, { 2, 5, 8 }, 
                { 0, 4, 8 }, { 2, 4, 6 }              
            };

            for (int i = 0; i < winningCombinations.GetLength(0); i++)
            {
                if (game.Grid[winningCombinations[i, 0]] == player &&
                    game.Grid[winningCombinations[i, 1]] == player &&
                    game.Grid[winningCombinations[i, 2]] == player)
                {
                    return true;
                }
            }

            return false;
        }

        private void resetGame()
        {
            game = new Board(); 
            updateBoard();      
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            updateBoard();
        }

        private void updateBoard()
        {
            for (int i = 0; i < game.Grid.Length; i++)
            {
                if (game.Grid[i] == 0)
                {
                    buttons[i].Text = "";
                }
                else if (game.Grid[i] == 1)
                {
                    buttons[i].Text = "X";
                }
                else if (game.Grid[i] == 2)
                {
                    buttons[i].Text = "O";
                }
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            resetGame(); 
        }
    }
}
