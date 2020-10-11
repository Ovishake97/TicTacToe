using System;
using System.Globalization;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the TicTacToe Game");
            TicTacToeGame ticTacToeGame = new TicTacToeGame();
            char[] boardMoves = ticTacToeGame.CreateBoard();
            ticTacToeGame.ShowBoard(boardMoves);
            char playerMove = ticTacToeGame.SelectMove();
            char computerMove = ticTacToeGame.GetComputerMove(playerMove);
            TicTacToeGame.Player player = ticTacToeGame.PlayerToss();
            ticTacToeGame.ShowBoard(boardMoves);
            TicTacToeGame.GameStatus gameStatus;
            bool gameIsPlaying = true;
            while (gameIsPlaying) {
                if (player.Equals(TicTacToeGame.Player.USER))
                {
                    string winningStatement = "User won the game";
                    Console.WriteLine("User's Turn");
                    boardMoves = ticTacToeGame.FillPosition(boardMoves, playerMove);
                    ticTacToeGame.ShowBoard(boardMoves);
                    gameStatus = ticTacToeGame.GetGameStatus(boardMoves, playerMove, winningStatement);
                    player = TicTacToeGame.Player.COMPUTER;
                }
                else {
                    string winningStatement = "Computer won the game";
                    Console.WriteLine("Computer's Turn");
                    boardMoves = ticTacToeGame.ComputerPlays(boardMoves, computerMove);
                    ticTacToeGame.ShowBoard(boardMoves);
                    gameStatus = ticTacToeGame.GetGameStatus(boardMoves, computerMove, winningStatement);
                    player = TicTacToeGame.Player.USER;
                }
                if (gameStatus.Equals(TicTacToeGame.GameStatus.CONTINUE))
                {
                    continue;
                }
                else {
                    gameIsPlaying = false;
                }

                if (gameIsPlaying == false) {
                    Console.WriteLine("Do you want to play again? Write yes or no");
                    string answer = Console.ReadLine().ToLower();
                    if (answer.Equals("yes"))
                    {
                        gameIsPlaying = true;
                    }
                    else {
                        Console.WriteLine("Thank you for playing with us");
                        Console.ReadKey();
                    }
                }
            }

        }
    }
    public class TicTacToeGame
    {
        public const int IS_HEAD = 0;
        public const int IS_TAIL = 1;
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
        
        //User playing the game
        public char[] FillPosition(char[] board, char userMove)
        {
            Console.WriteLine("Choose your desired index from 1 to 9");
            int index = Convert.ToInt32((Console.ReadLine()));
            if (board[index] == ' ')
            {
                board[index] = userMove;

            }
            return board;
        }

        //Computer playing the game
        public char[] ComputerPlays(char[] board, char cpuMove)
        {
            Random rnd = new Random();
            bool flag = true;
            char move = GetComputerMove(userMove);
            while (flag) {
                {
                    int index = rnd.Next(1, 10);   
                    if (board[index] == ' ')
                    {
                        board[index] = move;
                        flag = false;
                    }
                }
            }
            
            return board;

        }

        //Checking the winning condition
        public bool DeclareWinner(char[] board, char move)
        {
            return ((board[1] == move && board[2] == move && board[3] == move) ||
                    (board[4] == move && board[5] == move && board[6] == move) ||
                    (board[7] == move && board[8] == move && board[9] == move) ||
                    (board[1] == move && board[4] == move && board[7] == move) ||
                    (board[2] == move && board[5] == move && board[8] == move) ||
                    (board[3] == move && board[6] == move && board[9] == move) ||
                    (board[1] == move && board[5] == move && board[9] == move) ||
                    (board[3] == move && board[5] == move && board[7] == move));
        }

        
        public enum GameStatus { WON, FULL_BOARD,CONTINUE}
        public GameStatus GetGameStatus(char[] board, char move,string winningStatement) {
            if (DeclareWinner(board, move))
            {
                Console.WriteLine(winningStatement);
                ShowBoard(board);
                return GameStatus.WON;
            }
            else if (TieCondition(board))
            {
                Console.WriteLine("Game is tie");
                ShowBoard(board);
                return GameStatus.FULL_BOARD;
            }
            else {

                return GameStatus.CONTINUE;
            }
        }

        public bool TieCondition(char[] board) {
            int turn = 1;
            foreach (char ch in board) {
                if (ch != ' ') {
                    turn++;
                }
            }
            if (turn == board.Length)
            {
                return true;
            }
            else {
                return false;
            }
        }
    }
}
