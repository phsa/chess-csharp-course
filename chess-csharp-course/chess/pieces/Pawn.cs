using board;
using System;

namespace chess.pieces
{
    class Pawn : Piece
    {
        public Pawn(Board board, Color color) : base(board, color)
        {
        }

        public override bool[,] AvailableMovements()
        {
            bool[,] moves = new bool[Board.Rows, Board.Columns];
            Position pos = new Position(0, 0);

            if (Color == Color.White)
            {
                // NORMAL
                pos.Update(Position.Row - 1, Position.Column);
                if(CanMoveTo(pos))
                {
                    moves[pos.Row, pos.Column] = true;
                }

                // FIRST
                pos.Update(Position.Row - 2, Position.Column);
                if (CanMoveTo(pos) && NumOfMovements == 0)
                {
                    moves[pos.Row, pos.Column] = true;
                }

                // CAPTURE RIGHT
                pos.Update(Position.Row - 1, Position.Column + 1);
                if (CanMoveTo(pos) && ThereIsEnemyPiece(pos))
                {
                    moves[pos.Row, pos.Column] = true;
                }

                // CAPTURE LEFT
                pos.Update(Position.Row - 1, Position.Column - 1);
                if (CanMoveTo(pos) && ThereIsEnemyPiece(pos))
                {
                    moves[pos.Row, pos.Column] = true;
                }
            }
            else
            {
                // NORMAL
                pos.Update(Position.Row + 1, Position.Column);
                if (CanMoveTo(pos))
                {
                    moves[pos.Row, pos.Column] = true;
                }

                // FIRST
                pos.Update(Position.Row + 2, Position.Column);
                if (CanMoveTo(pos) && NumOfMovements == 0)
                {
                    moves[pos.Row, pos.Column] = true;
                }

                // CAPTURE RIGHT
                pos.Update(Position.Row + 1, Position.Column + 1);
                if (CanMoveTo(pos) && ThereIsEnemyPiece(pos))
                {
                    moves[pos.Row, pos.Column] = true;
                }

                // CAPTURE LEFT
                pos.Update(Position.Row + 1, Position.Column - 1);
                if (CanMoveTo(pos) && ThereIsEnemyPiece(pos))
                {
                    moves[pos.Row, pos.Column] = true;
                }
            }

            return moves;
        }

        private bool CanMoveTo(Position pos)
        {
            try
            {
                return Board.PieceAt(pos) == null;
            }
            catch
            {
                return false;
            }
        }

        private bool ThereIsEnemyPiece(Position pos)
        {
            try
            {
                Piece p = Board.PieceAt(pos);
                return p != null || Color != p.Color;
            }
            catch
            {
                return false;
            }
        }

        public override string ToString()
        {
            return "P";
        }
    }
}
