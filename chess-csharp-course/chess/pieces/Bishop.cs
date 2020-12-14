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

            // LEFT-UP
            Position pos = new Position(Position.Row - 1, Position.Column - 1);
            while (ItIsAPossibleMove(pos))
            {
                moves[pos.Row, pos.Column] = true;
                if (Board.PieceAt(pos) != null && Color != Board.PieceAt(pos).Color)
                {
                    break;
                }
                pos.Row--;
                pos.Column--;
            }

            // RIGHT-UP
            pos.Update(Position.Row - 1, Position.Column + 1);
            while (ItIsAPossibleMove(pos))
            {
                moves[pos.Row, pos.Column] = true;
                if (Board.PieceAt(pos) != null && Color != Board.PieceAt(pos).Color)
                {
                    break;
                }
                pos.Row--;
                pos.Column++;
            }

            // LEFT-DOWN
            pos.Update(Position.Row + 1, Position.Column - 1);
            while (ItIsAPossibleMove(pos))
            {
                moves[pos.Row, pos.Column] = true;
                if (Board.PieceAt(pos) != null && Color != Board.PieceAt(pos).Color)
                {
                    break;
                }
                pos.Row++;
                pos.Column++;
            }

            // RIGHT-DOWN
            pos.Update(Position.Row + 1, Position.Column + 1);
            while (ItIsAPossibleMove(pos))
            {
                moves[pos.Row, pos.Column] = true;
                if (Board.PieceAt(pos) != null && Color != Board.PieceAt(pos).Color)
                {
                    break;
                }
                pos.Row++;
                pos.Column++;
            }


            // TEST
            for (int i = 0; i < Board.Rows; i++)
            {
                for (int j = 0; j < Board.Columns; j++)
                {
                    if (moves[i, j])
                    {
                        System.Console.Write("X");
                    }
                    else
                    {
                        System.Console.Write("-");
                    }
                }
                System.Console.WriteLine();
            }
            //TEST


            return moves;
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

        public override string ToString()
        {
            return "B";
        }
    }
}
