using System;
using System.Text;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            TicTacToeGame ticTacToeGame = new TicTacToeGame();
            char[] output = ticTacToeGame.CreateBoard();
            ticTacToeGame.SelectMove();
        }
    }

    public class TicTacToeGame
    {
        public char[] CreateBoard()
        {
            char[] board = new char[10];
            for (int i = 0; i < board.Length; i++) {
                board[i] = ' ';
            }
            return board;
        }

        public void SelectMove()
        {
            char cpuMove;
            Console.WriteLine("Select your move");
            char userMove = Convert.ToChar(Console.ReadLine());
            if (userMove == 'X')
            {
                cpuMove = 'O';
            }
            else if (userMove == 'O')
            {
                cpuMove = 'X';
            }
            else {
                Console.WriteLine("Invalid move");
            }
        }


    }
}


