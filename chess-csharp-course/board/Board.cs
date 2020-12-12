using board.exceptions;
using System;

namespace board
{
    class Board
    {
        public int Rows { get; set; }
        public int Columns { get; set; }
        private Piece[,] _pieces;

        public Board(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;
            _pieces = new Piece[rows, columns];
        }

        public Piece PieceAt(Position pos)
        {

            // Check values => 0 <= i < Rows and 0 <= j < Columns
            return _pieces[pos.Row, pos.Column];
        }

        public void InsertPiece(Piece piece, Position pos)
        {
            if (IsAValidPosition(pos))
            {
                if (PieceAt(pos) == null)
                {
                    _pieces[pos.Row, pos.Column] = piece;
                    piece.Position = pos;
                }
                else
                {
                    throw new BoardException("There is already a piece in that position!");
                }
            }
            else
            {
                throw new BoardException("Invalid Position!");
            }
        }

        private bool IsAValidPosition(Position pos)
        {
            return 0 <= pos.Row && pos.Row < Rows && 0 <= pos.Column && pos.Column < Columns;
        }
    }
}