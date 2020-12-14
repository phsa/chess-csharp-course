using board;

namespace chess.pieces
{
    class King : Piece
    {
        public King(Board board, Color color) : base(board, color)
        {
        }

        public override bool[,] AvailableMovements()
        {
            bool[,] moves = new bool[Board.Rows, Board.Columns];
            Position pos = new Position(0, 0);

            // UP
            pos.Update(Position.Row - 1, Position.Column);
            if (CanMoveTo(pos))
            {
                moves[pos.Row, pos.Column] = true;
            }

            // RIGHT-UP
            pos.Update(Position.Row - 1, Position.Column + 1);
            if (CanMoveTo(pos))
            {
                moves[pos.Row, pos.Column] = true;
            }

            // RIGHT
            pos.Update(Position.Row, Position.Column + 1);
            if (CanMoveTo(pos))
            {
                moves[pos.Row, pos.Column] = true;
            }

            // RIGHT-DOWN
            pos.Update(Position.Row + 1, Position.Column + 1);
            if (CanMoveTo(pos))
            {
                moves[pos.Row, pos.Column] = true;
            }

            // DOWN
            pos.Update(Position.Row + 1, Position.Column);
            if (CanMoveTo(pos))
            {
                moves[pos.Row, pos.Column] = true;
            }

            // LEFT-DOWN
            pos.Update(Position.Row + 1, Position.Column - 1);
            if (CanMoveTo(pos))
            {
                moves[pos.Row, pos.Column] = true;
            }

            // LEFT
            pos.Update(Position.Row, Position.Column - 1);
            if (CanMoveTo(pos))
            {
                moves[pos.Row, pos.Column] = true;
            }

            // LEFT-UP
            pos.Update(Position.Row - 1, Position.Column - 1);
            if (CanMoveTo(pos))
            {
                moves[pos.Row, pos.Column] = true;
            }

            return moves;
        }

        private bool CanMoveTo(Position pos)
        {
            try
            {
                Piece p = Board.PieceAt(pos);
                return p == null || Color != p.Color;
            }
            catch
            {
                return false;
            }
        }

        public override string ToString()
        {
            return "K";
        }
    }
}
