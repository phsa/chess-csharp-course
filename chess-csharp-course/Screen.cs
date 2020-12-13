using System;
using board;

namespace chess_csharp_course
{
    class Screen
    {

        public static void PrintBoard(Board board)
        {
            for (int i = 0; i < board.Rows; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < board.Columns; j++)
                {
                    Position position = new Position(i, j);
                    if (board.PieceAt(position) != null)
                    {
                        printPiece(board.PieceAt(position));
                        Console.Write(" ");
                    }
                    else
                    {
                        Console.Write("- ");
                    }
                }
                Console.WriteLine();
            }
            Console.Write("  a b c d e f g h");
            Console.WriteLine();
        }

        private static void printPiece(Piece piece)
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
        }
    }
}
