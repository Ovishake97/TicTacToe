using System;
using System.Text;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            TicTacToeGame ticTacToeGame = new TicTacToeGame();
            char[] output= ticTacToeGame.CreateBaord();
        }
    }

    public class TicTacToeGame
    {
        public static char[] CreateBoard()
        {
            char[] board = new char[10];
            for (int i = 0; i < board.Length; i++) {
                board[i] = ' ';
            }
            return board;
        }


    }
}


