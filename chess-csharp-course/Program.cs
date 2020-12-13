using System;
using board;
using board.exceptions;
using chess;

namespace chess_csharp_course
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ChessMatch match = new ChessMatch();

                while (!match.Finished())
                {
                    Console.Clear();
                    Screen.PrintBoard(match.Board);

                    Console.WriteLine();
                    Console.Write("Source: ");

                    ChessPosition sourceChessPos = ReadChessPosition();

                    bool[,] possible = match.Board.PieceAt(sourceChessPos.ToPosition()).PossibleMovements();
                    Console.Clear();
                    Screen.PrintBoard(match.Board, possible);

                    Console.WriteLine();
                    Console.WriteLine("Source: " + sourceChessPos);

                    Console.Write("Target: ");
                    ChessPosition targetChessPos = ReadChessPosition();

                    match.MovePiece(sourceChessPos.ToPosition(), targetChessPos.ToPosition());
                }
            }
            catch (BoardException e)
            {
                Console.WriteLine("Board Error: " + e.Message);
            }
            Console.ReadLine();
        }

        private static ChessPosition ReadChessPosition()
        {
            string s = Console.ReadLine();
            char column = s[0];
            int row = int.Parse(s[1].ToString());
            return new ChessPosition(column, row);
        }
    }
}
