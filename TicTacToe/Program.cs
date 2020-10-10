using System;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            TicTacToeGame ticTacToeGame = new TicTacToeGame();
            char[] boardMoves = ticTacToeGame.CreateBoard();
            ticTacToeGame.ShowBoard(boardMoves);
            char playerMove = ticTacToeGame.SelectMove();
            TicTacToeGame.Player player = ticTacToeGame.PlayerToss();
            boardMoves = ticTacToeGame.FillPosition(boardMoves, playerMove);
            ticTacToeGame.ShowBoard(boardMoves);
            Console.WriteLine("Winning staus : " + ticTacToeGame.DeclareWinner(boardMoves, playerMove));
        }
    }

    public class TicTacToeGame
    {
        public const int IS_HEAD = 1;
        public const int IS_TAIL = 2;
        public char[] board = new char[10];
        public char[] boardCopy = new char[10];
        public char userMove = ' ';
        public char cpuMove = ' ';
        public enum Player { USER, COMPUTER };
        public char[] CreateBoard()
        {
            for (int i = 1; i <= board.Length; i++)
            {


                board[i - 1] = ' ';
            }
            return board;
        }

        //Tossing and deciding who playes first
        public Player PlayerToss()
        {
            Console.WriteLine("Wait for the toss results:");
            Random random = new Random();
            int toss = random.Next(0, 2);

            if (toss == IS_HEAD)
            {
                Console.WriteLine("User moves first");
                return Player.USER;

            }
            else
            {
                Console.WriteLine("Computer moves first");
                return Player.COMPUTER;

            }
        }
        //Selecting move for the user
        public char SelectMove()
        {

            Console.WriteLine("Select your move X or O");
            userMove = Convert.ToChar(Console.ReadLine().ToUpper());
            return userMove;
        }
        public char GetComputerMove(char userMove)
        {
            char cpuMove = ' ';
            if (userMove == 'X')
            {
                cpuMove = 'O';
            }
            else if (userMove == 'O')
            {
                cpuMove = 'X';
            }
            return cpuMove;
        }

        //Showing the board
        public void ShowBoard(char[] board)
        {
            Console.WriteLine("___|___|___");
            Console.WriteLine(" " + board[1] + " | " + board[2] + " | " + board[3]);
            Console.WriteLine("___|___|___");
            Console.WriteLine(" " + board[4] + " | " + board[5] + " | " + board[6]);
            Console.WriteLine("___|___|___");
            Console.WriteLine(" " + board[7] + " | " + board[8] + " | " + board[9]);
        }
        //Getting a copy of the gameboard
        public char[] GetBoardCopy(char[] board)
        {
            Array.Copy(board, 0, boardCopy, 0, 10);
            return boardCopy;
        }

        //User playing the game
        public char[] FillPosition(char[] board, char userMove)
        {
            char[] boardNew = GetBoardCopy(board);
            Console.WriteLine("Choose your desired index from 1 to 9");
            int index = Convert.ToInt32((Console.ReadLine()));
            if(boardNew[index] == ' ')
            {
                boardNew[index] = userMove;

            }
            return boardNew;
        }

        //Computer playing the game
        public char[] ComputerPlays(char[] board, char cpuMove)
        {
            char move = GetComputerMove(userMove);
            char[] boardNew = GetBoardCopy(board);
            for (int i = 1; i < board.Length; i++)
            {
                if (boardNew[i] != ' ')
                {
                    boardNew[i] = move;
                }
            }
            return boardNew;

        }

        //Checking the winning condition
        public bool DeclareWinner(char[] board ,char move) {
            return ((board[1] == move && board[2] == move && board[3] == move) ||
                    (board[4] == move && board[5] == move && board[6] == move) ||
                    (board[7] == move && board[8] == move && board[9] == move) ||
                    (board[1] == move && board[4] == move && board[7] == move) ||
                    (board[2] == move && board[5] == move && board[8] == move) ||
                    (board[3] == move && board[6] == move && board[9] == move) ||
                    (board[1] == move && board[5] == move && board[9] == move) ||
                    (board[3] == move && board[5] == move && board[7] == move));
        }
    }
}
