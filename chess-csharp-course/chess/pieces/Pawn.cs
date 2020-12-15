using board;
using System;

namespace chess.pieces
{
    class Pawn : Piece
    {
        private ChessMatch _match;

        public Pawn(Board board, Color color, ChessMatch match) : base(board, color)
        {
            _match = match;
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
                if (ThereIsEnemyPiece(pos))
                {
                    moves[pos.Row, pos.Column] = true;
                }

                // CAPTURE LEFT
                pos.Update(Position.Row - 1, Position.Column - 1);
                if (ThereIsEnemyPiece(pos))
                {
                    moves[pos.Row, pos.Column] = true;
                }


                //#SPECIALMOVE: EN PASSANT
                if (Position.Row == 3)
                {
                    Position atLeft = new Position(Position.Row, Position.Column - 1);
                    if (ThereIsEnemyPiece(atLeft) && Board.PieceAt(atLeft) == _match.EnPassantVulnerable)
                    {
                        moves[atLeft.Row - 1, atLeft.Column] = true;
                    }

                    Position atRight = new Position(Position.Row, Position.Column + 1);
                    if (ThereIsEnemyPiece(atRight) && Board.PieceAt(atRight) == _match.EnPassantVulnerable)
                    {
                        moves[atRight.Row - 1, atRight.Column] = true;
                    }
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
                if (ThereIsEnemyPiece(pos))
                {
                    moves[pos.Row, pos.Column] = true;
                }

                // CAPTURE LEFT
                pos.Update(Position.Row + 1, Position.Column - 1);
                if (ThereIsEnemyPiece(pos))
                {
                    moves[pos.Row, pos.Column] = true;
                }


                //#SPECIALMOVE: EN PASSANT
                if (Position.Row == 4)
                {
                    Position atLeft = new Position(Position.Row, Position.Column - 1);
                    if (ThereIsEnemyPiece(atLeft) && Board.PieceAt(atLeft) == _match.EnPassantVulnerable)
                    {
                        moves[atLeft.Row + 1, atLeft.Column] = true;
                    }

                    Position atRight = new Position(Position.Row, Position.Column + 1);
                    if (ThereIsEnemyPiece(atRight) && Board.PieceAt(atRight) == _match.EnPassantVulnerable)
                    {
                        moves[atRight.Row + 1, atRight.Column] = true;
                    }
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
                return p != null && Color != p.Color;
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
