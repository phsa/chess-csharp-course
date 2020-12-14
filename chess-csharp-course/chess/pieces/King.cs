using board;
using board.exceptions;

namespace chess.pieces
{
    class King : Piece
    {

        private ChessMatch _match;

        public King(Board board, Color color, ChessMatch match) : base(board, color)
        {
            _match = match;
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


            // #SPECIALMOVE: CASTLING
            if (NumOfMovements == 0 && !_match.InCheck)
            {
                // Castling Short
                Position castlingShortRookPos = new Position(Position.Row, Position.Column + 3);
                if (IsRookAbleForCastling(castlingShortRookPos))
                {
                    Position rightNeighbor1 = new Position(Position.Row, Position.Column + 1);
                    Position rightNeighbor2 = new Position(Position.Row, Position.Column + 2);

                    if (Board.PieceAt(rightNeighbor1) == null && Board.PieceAt(rightNeighbor2) == null)
                    {
                        moves[Position.Row, Position.Column + 2] = true;
                    }

                }

                // Castling Long
                Position castlingLongRookPos = new Position(Position.Row, Position.Column - 4);
                if (IsRookAbleForCastling(castlingLongRookPos))
                {
                    Position leftNeighbor1 = new Position(Position.Row, Position.Column - 1);
                    Position leftNeighbor2 = new Position(Position.Row, Position.Column - 2);
                    Position leftNeighbor3 = new Position(Position.Row, Position.Column - 3);

                    if (Board.PieceAt(leftNeighbor1) == null && Board.PieceAt(leftNeighbor2) == null && Board.PieceAt(leftNeighbor3) == null)
                    {
                        moves[Position.Row, Position.Column - 2] = true;
                    }

                }
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

        private bool IsRookAbleForCastling(Position pos)
        {
            try
            {
                Piece p = Board.PieceAt(pos);
                return p != null && p is Rook && p.Color == Color && p.NumOfMovements == 0;
            }
            catch (BoardException)
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
