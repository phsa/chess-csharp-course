using board;

namespace chess.pieces
{
    class Knight : Piece
    {
        public Knight(Board board, Color color) : base(board, color)
        {
        }

        public override bool[,] AvailableMovements()
        {

            bool[,] moves = new bool[Board.Rows, Board.Columns];
            Position pos = new Position(0, 0);

            // UP-RIGHT
            pos.Update(Position.Row - 2, Position.Column + 1);
            if (CanMoveTo(pos))
            {
                moves[pos.Row, pos.Column] = true;
            }

            // UP-LEFT
            pos.Update(Position.Row - 2, Position.Column - 1);
            if (CanMoveTo(pos))
            {
                moves[pos.Row, pos.Column] = true;
            }

            // RIGHT-UP
            pos.Update(Position.Row - 1, Position.Column + 2);
            if (CanMoveTo(pos))
            {
                moves[pos.Row, pos.Column] = true;
            }

            // RIGHT-DOWN
            pos.Update(Position.Row + 1, Position.Column + 2);
            if (CanMoveTo(pos))
            {
                moves[pos.Row, pos.Column] = true;
            }

            // DOWN-RIGHT
            pos.Update(Position.Row + 2, Position.Column + 1);
            if (CanMoveTo(pos))
            {
                moves[pos.Row, pos.Column] = true;
            }

            // DOWN-LEFT
            pos.Update(Position.Row + 2, Position.Column - 1);
            if (CanMoveTo(pos))
            {
                moves[pos.Row, pos.Column] = true;
            }

            // LEFT-DOWN
            pos.Update(Position.Row + 1, Position.Column - 2);
            if (CanMoveTo(pos))
            {
                moves[pos.Row, pos.Column] = true;
            }

            // LEFT-DOWN
            pos.Update(Position.Row - 1, Position.Column - 2);
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
            return "N";
        }
    }
}
