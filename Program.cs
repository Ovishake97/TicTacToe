using System;
using System.Text;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            TicTacToeGame ticTacToeGame = new TicTacToeGame();
            char[] board = ticTacToeGame.CreateBoard();
            char computerMove= ticTacToeGame.SelectMove();
            ticTacToeGame.ShowBoard();
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

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public char SelectMove()
        {
            char cpuMove= ' ';
            Console.WriteLine("Select your move X or O");
            char userMove = Convert.ToChar(Console.ReadLine().ToUpper());
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
            return cpuMove;
        }

        public void ShowBoard() {
            Console.WriteLine("___||___||___");
            Console.WriteLine("___||___||___");
            Console.WriteLine("___||___||___");
        }

    }
}


