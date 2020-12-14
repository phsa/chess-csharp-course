using System;
using System.Collections.Generic;
using board;
using chess;

namespace chess_csharp_course
{
    class Screen
    {

        public static void PrintMatch(ChessMatch match)
        {
            PrintBoard(match.Board);

            Console.WriteLine();
            PrintCapturedPieces(match);
            Console.WriteLine();
            Console.WriteLine("Turn: " + match.Turn);

            if (match.Finished)
            {
                Console.WriteLine("CHECKMATE!");
                Console.WriteLine("Winner: " + match.CurrentPlayer);
            }
            else
            {
                Console.WriteLine("Waiting the move: " + match.CurrentPlayer);
                if (match.InCheck)
                {
                    Console.WriteLine("CHECK!");
                }
            }
        }

        private static void PrintCapturedPieces(ChessMatch match)
        {
            Console.WriteLine("Captured pieces: ");
            Console.Write("White: ");
            PrintSet(match.CapturedPieces(Color.White));
            Console.WriteLine();
            Console.Write("Black: ");
            ConsoleColor originalColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            PrintSet(match.CapturedPieces(Color.Black));
            Console.ForegroundColor = originalColor;
            Console.WriteLine();
        }

        private static void PrintSet(HashSet<Piece> pieces)
        {
            Console.Write("[");
            foreach (Piece piece in pieces)
            {
                Console.Write(piece + " ");
            }
            Console.Write("]");
        }

        public static void PrintBoard(Board board)
        {
            for (int i = 0; i < board.Rows; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < board.Columns; j++)
                {
                    PrintPiece(board.PieceAt(new Position(i, j)));
                }
                Console.WriteLine();
            }
            Console.Write("  a b c d e f g h");
            Console.WriteLine();
        }

        public static void PrintBoard(Board board, bool[,] possibleMovements)
        {

            ConsoleColor originalColor = Console.BackgroundColor;
            ConsoleColor changedBackground = ConsoleColor.DarkGray;

            for (int i = 0; i < board.Rows; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < board.Columns; j++)
                {
                    if (possibleMovements[i, j])
                    {
                        Console.BackgroundColor = changedBackground;
                    }
                    PrintPiece(board.PieceAt(new Position(i, j)));
                    Console.BackgroundColor = originalColor;
                }
                Console.WriteLine();
            }
            Console.Write("  a b c d e f g h");
            Console.WriteLine();
        }

        private static void PrintPiece(Piece piece)
        {
            if (piece != null)
            {
                if (piece.Color == Color.White)
                {
                    Console.Write(piece);
                }
                else
                {
                    ConsoleColor originalColor = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(piece);
                    Console.ForegroundColor = originalColor;
                }
                Console.Write(" ");
            }
            else
            {
                Console.Write("- ");
            }

        }
    }
}
