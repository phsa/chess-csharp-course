using System;
using board;
using chess;

namespace chess_csharp_course
{
    class Program
    {
        static void Main(string[] args)
        {
            Board board = new Board(8, 8);
            board.InsertPiece(new Rook(board, Color.Branca), new Position(0, 0));
            board.InsertPiece(new Rook(board, Color.Branca), new Position(1, 3));
            Screen.PrintBoard(board);
            Console.ReadLine();
        }
    }
}
