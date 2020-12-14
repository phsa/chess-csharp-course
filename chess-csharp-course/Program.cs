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

                while (!match.Finished)
                {
                    try
                    {
                        Console.Clear();
                        Screen.PrintMatch(match);

                        Console.WriteLine();
                        Console.Write("Source: ");
                        Position sourcePos = ReadChessPosition().ToPosition();

                        match.ValidateSourcePosition(sourcePos);

                        bool[,] possible = match.Board.PieceAt(sourcePos).AvailableMovements();
                        Console.Clear();
                        Screen.PrintBoard(match.Board, possible);

                        Console.WriteLine();
                        Console.Write("Target: ");
                        Position targetPos = ReadChessPosition().ToPosition();

                        match.ValidateTargetPosition(sourcePos, targetPos);

                        match.PerformMove(sourcePos, targetPos);
                    }
                    catch (BoardException e)
                    {
                        Console.WriteLine(e.Message);
                        Console.ReadLine();
                    }
                }

                Console.Clear();
                Screen.PrintMatch(match);
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
