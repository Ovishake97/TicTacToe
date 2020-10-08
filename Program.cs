using System;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            TicTacToeGame ticTacToeGame = new TicTacToeGame();
            char[] boardMoves = ticTacToeGame.CreateBoard();
            char playerMove= ticTacToeGame.SelectMove();
            ticTacToeGame.ShowBoard(boardMoves);
           boardMoves= ticTacToeGame.FillPosition(boardMoves,playerMove);
            ticTacToeGame.ShowBoard(boardMoves);
        }
    }

    public class TicTacToeGame
    {
        public char[] board = new char[10];
        public char userMove= ' ';
        char cpuMove = ' ';
        public char[] CreateBoard()
        {
            for (int i = 1; i <= board.Length; i++) {

                
                board[i-1] =' ';
            }
            return board;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public char SelectMove()
        {
            
            Console.WriteLine("Select your move X or O");
            userMove = Convert.ToChar(Console.ReadLine().ToUpper());
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
            return userMove;
        }

        public void ShowBoard(char[] board) {
            Console.WriteLine("___|___|___");
            Console.WriteLine(" "+board[1]+" | " +board[2]+ " | " +board[3]);
            Console.WriteLine("___|___|___");
            Console.WriteLine(" " + board[4] + " | " + board[5] + " | " + board[6]);
            Console.WriteLine("___|___|___");
            Console.WriteLine(" " + board[7] + " | " + board[8] + " | " + board[9]);
        }

        public char[] FillPosition(char[] board,char userMove) {
            Console.WriteLine("Choose your desired index");
            int index = Convert.ToInt32((Console.ReadLine()));
            if (board[index] == ' ')
            {
                board[index] = userMove;
            }
            else {
                Console.WriteLine("Position is already filled");
            }
            return board;
        }
    }
}


