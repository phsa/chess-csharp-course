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
                for (int j = 0; j < board.Columns; j++)
                {
                    Position position = new Position(i, j);
                    if (board.PieceAt(position) != null)
                    {
                        Console.Write(board.PieceAt(position) + " ");
                    }
                    else
                    {
                        Console.Write("- ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
