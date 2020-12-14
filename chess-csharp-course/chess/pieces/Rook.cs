using board;

namespace chess.pieces
{
    class Rook : Piece
    {
        public Rook(Board board, Color color) : base(board, color)
        {
        }

        private bool ItIsAPossibleMove(Position pos)
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

        public override bool[,] AvailableMovements()
        {
            bool[,] moves = new bool[Board.Rows, Board.Columns];
            Position pos = new Position(Position.Row - 1, Position.Column);

            //UP
            while (ItIsAPossibleMove(pos))
            {
                moves[pos.Row, pos.Column] = true;
                if (Board.PieceAt(pos) != null && Color != Board.PieceAt(pos).Color)
                {
                    break;
                }
                pos.Row--;
            }

            //RIGHT
            pos.Update(Position.Row, Position.Column + 1);
            while (ItIsAPossibleMove(pos))
            {
                moves[pos.Row, pos.Column] = true;
                if (Board.PieceAt(pos) != null && Color != Board.PieceAt(pos).Color)
                {
                    break;
                }
                pos.Column++;
            }

            //DOWN
            pos.Update(Position.Row + 1, Position.Column);
            while (ItIsAPossibleMove(pos))
            {
                moves[pos.Row, pos.Column] = true;
                if (Board.PieceAt(pos) != null && Color != Board.PieceAt(pos).Color)
                {
                    break;
                }
                pos.Row++;
            }

            //LEFT
            pos.Update(Position.Row, Position.Column - 1);
            while (ItIsAPossibleMove(pos))
            {
                moves[pos.Row, pos.Column] = true;
                if (Board.PieceAt(pos) != null && Color != Board.PieceAt(pos).Color)
                {
                    break;
                }
                pos.Column--;
            }

            return moves;
        }

        public override string ToString()
        {
            return "R";
        }
    }
}
