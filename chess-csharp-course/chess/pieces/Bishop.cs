using board;

namespace chess.pieces
{
    class Bishop : Piece
    {
        public Bishop(Board board, Color color) : base(board, color)
        {
        }

        public override bool[,] AvailableMovements()
        {
            bool[,] moves = new bool[Board.Rows, Board.Columns];
            Position pos = new Position(0, 0);

            // RIGHT-UP
            pos.Update(Position.Row - 1, Position.Column + 1);
            while (CanMoveTo(pos))
            {
                moves[pos.Row, pos.Column] = true;
                if (Board.PieceAt(pos) != null && Color != Board.PieceAt(pos).Color)
                {
                    break;
                }
                pos.Row--;
                pos.Column++;
            }

            // RIGHT-DOWN
            pos.Update(Position.Row + 1, Position.Column + 1);
            while (CanMoveTo(pos))
            {
                moves[pos.Row, pos.Column] = true;
                if (Board.PieceAt(pos) != null && Color != Board.PieceAt(pos).Color)
                {
                    break;
                }
                pos.Row++;
                pos.Column++;
            }

            // LEFT-DOWN
            pos.Update(Position.Row + 1, Position.Column - 1);
            while (CanMoveTo(pos))
            {
                moves[pos.Row, pos.Column] = true;
                if (Board.PieceAt(pos) != null && Color != Board.PieceAt(pos).Color)
                {
                    break;
                }
                pos.Row++;
                pos.Column++;
            }

            // LEFT-UP
            pos.Update(Position.Row - 1, Position.Column - 1);
            while (CanMoveTo(pos))
            {
                moves[pos.Row, pos.Column] = true;
                if (Board.PieceAt(pos) != null && Color != Board.PieceAt(pos).Color)
                {
                    break;
                }
                pos.Row--;
                pos.Column--;
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
            return "B";
        }
    }
}
