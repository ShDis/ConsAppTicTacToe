using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsAppTicTacToe
{
    class TicTacToe
    {
        public enum CellState
        {
            Empty,
            X,
            O
        }

        private CellState[,] board = new CellState[3, 3];
        private int boardSize = 3;
        private CellState currentTurnSign = CellState.X;
        private int turn = 0;

        private void Help()
        {
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("--------------------\nquit\nhelp\nplace <row> <column>\n--------------------");
            Console.BackgroundColor = ConsoleColor.Black;
        }

        public void Launch()
        {
            Help();
            RestartGame();
            while (true)
            {
                try
                {
                    Console.WriteLine("Player " + (currentTurnSign == CellState.X ? "1" : "2")
                                    + " (" + currentTurnSign.ToString() + ")" + " turn:");
                    string[] cmd = Console.ReadLine().ToLower().Split();
                    switch (cmd[0])
                    {
                        case "quit":
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.WriteLine("Game closed");
                            Console.BackgroundColor = ConsoleColor.Black;
                            return;
                        case "help":
                            Help();
                            break;
                        case "place":
                            string reg = "^[0-2]$";
                            if (!Regex.IsMatch(cmd[1], @reg) || !Regex.IsMatch(cmd[2], @reg))
                                throw new Exception("Not enough args");
                            bool success = PlaceSign(currentTurnSign, Convert.ToInt32(cmd[1]), Convert.ToInt32(cmd[2]));
                            if (!success)
                                throw new Exception("Place not empty");
                            turn += 1;
                            DrawBoard();
                            if (CheckVictory(currentTurnSign))
                            {
                                //print winner
                                Console.BackgroundColor = ConsoleColor.Green;
                                Console.WriteLine("Player " + (currentTurnSign == CellState.X ? "1" : "2")
                                    + " (" + currentTurnSign.ToString() + ")" + " wins");
                                Console.BackgroundColor = ConsoleColor.Black;
                                //reset game
                                RestartGame();
                                break;
                            }
                            if (turn == boardSize * boardSize)
                            {
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine("Game ended with draw");
                                Console.ForegroundColor = ConsoleColor.White;
                                break;
                            }
                            //next turn (switch side)
                            currentTurnSign = (currentTurnSign == CellState.X ? CellState.O : CellState.X);
                            break;
                        default:
                            throw new Exception("No such command");
                    }
                }
                catch (Exception ex)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine(ex.Message);
                    Console.BackgroundColor = ConsoleColor.Black;   
                }
            }
        }

        private void RestartGame()
        {
            currentTurnSign = CellState.X;
            turn = 0;
            ClearBoard();
            DrawBoard();
        }

        private void ClearBoard()
        {
            for (int row = 0; row < boardSize; row++)
                for (int column = 0; column < boardSize; column++)
                    board[row, column] = CellState.Empty;
        }

        private bool PlaceSign(CellState sign, int row, int column, bool check = true)
        {
            if (row >= boardSize || column >= boardSize || row < 0 || column < 0)
                return false;
            if (check)
                if (board[row, column] != CellState.Empty && sign != CellState.Empty)
                    return false;
            board[row, column] = sign;
            return true;
        }

        private void DrawBoard()
        {
            Console.WriteLine("Turn " + (int)turn);
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            for (int row = 0; row < boardSize; row++)
            {
                for (int column = 0; column < boardSize; column++)
                {
                    Console.Write(board[row, column] != CellState.Empty ? board[row, column].ToString() : " ");
                    if (column != boardSize - 1)
                        Console.Write(" ");
                }
                Console.WriteLine();
            }
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
        }

        private bool CheckVictory(CellState sign)
        {
            if (sign != CellState.X && sign != CellState.O)
                return false;
            for (int row = 0; row < boardSize; row++) //check rows
            {
                for (int column = 0; column < boardSize; column++)
                {
                    if (board[row, column] != sign)
                        break;
                    if (column == boardSize - 1)
                        return true;
                }
            }
            for (int column = 0; column < boardSize; column++) //check columns
            {
                for (int row = 0; row < boardSize; row++)
                {
                    if (board[row, column] != sign)
                        break;
                    if (row == boardSize - 1)
                        return true;
                }
            }
            if (board[1,1] == sign) //check center
            {
                if (board[0, 0] == sign && board[2, 2] == sign)
                    return true;
                if (board[2, 0] == sign && board[0, 2] == sign)
                    return true;
            }
            return false;
        }
    }
}
