using board.exceptions;

namespace board
{
    class Board
    {
        private Piece[,] _pieces;
        public int Rows { get; set; }
        public int Columns { get; set; }

        public Board(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;
            _pieces = new Piece[rows, columns];
        }

        public Piece PieceAt(Position pos)
        {

            if (IsAValidPosition(pos))
            {
                return _pieces[pos.Row, pos.Column];
            }
            else
            {
                throw new BoardException("Invalid Position!");
            }
        }

        public void InsertPiece(Piece piece, Position pos)
        {

            if (PieceAt(pos) == null)
            {
                _pieces[pos.Row, pos.Column] = piece;
                piece.Position = pos;
            }
            else
            {
                throw new BoardException("There is already a piece in this position!");
            }
        }


        public Piece RemovePiece(Position pos)
        {
            Piece p = PieceAt(pos);
            _pieces[pos.Row, pos.Column] = null;
            return p;
        }

        public bool IsAValidPosition(Position pos)
        {
            return 0 <= pos.Row && pos.Row < Rows && 0 <= pos.Column && pos.Column < Columns;
        }
    }
}