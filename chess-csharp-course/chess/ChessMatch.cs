using board;
using board.exceptions;
using chess.pieces;
using System.Collections.Generic;

namespace chess
{
    class ChessMatch
    {

        private HashSet<Piece> _pieces;
        private HashSet<Piece> _capturedPieces;

        public Board Board { get; private set; }
        public Color CurrentPlayer { get; private set; }
        public int Turn { get; private set; }
        public bool InCheck { get; private set; }
        public bool Finished { get; private set; }

        public ChessMatch()
        {
            Board = new Board(8, 8);
            Turn = 1;
            CurrentPlayer = Color.White;
            _pieces = new HashSet<Piece>();
            _capturedPieces = new HashSet<Piece>();
            InitialSetting();
        }


        private void InitialSetting()
        {
            InsertNewPiece('a', 1, new Rook(Board, Color.White));
            InsertNewPiece('b', 1, new Knight(Board, Color.White));
            InsertNewPiece('c', 1, new Bishop(Board, Color.White));
            InsertNewPiece('d', 1, new Queen(Board, Color.White));
            InsertNewPiece('e', 1, new King(Board, Color.White, this));
            InsertNewPiece('f', 1, new Bishop(Board, Color.White));
            InsertNewPiece('g', 1, new Knight(Board, Color.White));
            InsertNewPiece('h', 1, new Rook(Board, Color.White));
            InsertNewPiece('a', 2, new Pawn(Board, Color.White));
            InsertNewPiece('b', 2, new Pawn(Board, Color.White));
            InsertNewPiece('c', 2, new Pawn(Board, Color.White));
            InsertNewPiece('d', 2, new Pawn(Board, Color.White));
            InsertNewPiece('e', 2, new Pawn(Board, Color.White));
            InsertNewPiece('f', 2, new Pawn(Board, Color.White));
            InsertNewPiece('g', 2, new Pawn(Board, Color.White));
            InsertNewPiece('h', 2, new Pawn(Board, Color.White));

            InsertNewPiece('a', 8, new Rook(Board, Color.Black));
            InsertNewPiece('b', 8, new Knight(Board, Color.Black));
            InsertNewPiece('c', 8, new Bishop(Board, Color.Black));
            InsertNewPiece('d', 8, new Queen(Board, Color.Black));
            InsertNewPiece('e', 8, new King(Board, Color.Black, this));
            InsertNewPiece('f', 8, new Bishop(Board, Color.Black));
            InsertNewPiece('g', 8, new Knight(Board, Color.Black));
            InsertNewPiece('h', 8, new Rook(Board, Color.Black));
            InsertNewPiece('a', 7, new Pawn(Board, Color.Black));
            InsertNewPiece('b', 7, new Pawn(Board, Color.Black));
            InsertNewPiece('c', 7, new Pawn(Board, Color.Black));
            InsertNewPiece('d', 7, new Pawn(Board, Color.Black));
            InsertNewPiece('e', 7, new Pawn(Board, Color.Black));
            InsertNewPiece('f', 7, new Pawn(Board, Color.Black));
            InsertNewPiece('g', 7, new Pawn(Board, Color.Black));
            InsertNewPiece('h', 7, new Pawn(Board, Color.Black));
        }

        public void InsertNewPiece(char column, int row, Piece newPiece)
        {
            Board.InsertPiece(newPiece, new ChessPosition(column, row).ToPosition());
            _pieces.Add(newPiece);

        }

        public HashSet<Piece> CapturedPieces(Color color)
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach (Piece piece in _capturedPieces)
            {
                if (piece.Color == color)
                {
                    aux.Add(piece);
                }
            }
            return aux;
        }

        public HashSet<Piece> PiecesInPlay(Color color)
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach (Piece piece in _pieces)
            {
                if (piece.Color == color)
                {
                    aux.Add(piece);
                }
            }
            aux.ExceptWith(CapturedPieces(color));
            return aux;
        }

        public void PerformMove(Position source, Position target)
        {
            Piece capturedPiece = MovePiece(source, target);

            if (IsInCheck(CurrentPlayer))
            {
                UndoMove(source, target, capturedPiece);
                throw new BoardException("You can not put yourself in check!");
            }

            InCheck = IsInCheck(Oponente(CurrentPlayer));

            if (Checkmating(Oponente(CurrentPlayer))) {
                Finished = true;
            }
            else
            {
                Turn++;
                ChangeCurrentPlayer();
            }

        }

        public Piece MovePiece(Position source, Position target)
        {
            Piece movedPiece = Board.RemovePiece(source);
            movedPiece.IncreaseMovementCount();
            Piece capturedPiece = Board.RemovePiece(target);
            Board.InsertPiece(movedPiece, target);
            if (capturedPiece != null)
            {
                _capturedPieces.Add(capturedPiece);
            }

            // #SPECIALMOVE: CASTLING SHORT
            if (movedPiece is King && target.Column == source.Column + 2)
            {
                Position originalRookPos = new Position(source.Row, source.Column + 3);
                Position newRookPos = new Position(source.Row, source.Column + 1);
                Piece rook = Board.RemovePiece(originalRookPos);
                rook.IncreaseMovementCount();
                Board.InsertPiece(rook, newRookPos);
            }

            // #SPECIALMOVE: CASTLING LONG
            if (movedPiece is King && target.Column == source.Column - 2)
            {
                Position originalRookPos = new Position(source.Row, source.Column - 4);
                Position newRookPos = new Position(source.Row, source.Column - 1);
                Piece rook = Board.RemovePiece(originalRookPos);
                rook.IncreaseMovementCount();
                Board.InsertPiece(rook, newRookPos);
            }

            return capturedPiece;
        }

        public void UndoMove(Position source, Position target, Piece capturedPiece)
        {
            Piece restoredPiece = Board.RemovePiece(target);
            restoredPiece.DecreaseMovementCount();
            if (capturedPiece != null)
            {
                Board.InsertPiece(capturedPiece, target);
                _capturedPieces.Remove(capturedPiece);
            }
            Board.InsertPiece(restoredPiece, source);



            // #SPECIALMOVE: CASTLING SHORT
            if (restoredPiece is King && target.Column == source.Column + 2)
            {
                Position originalRookPos = new Position(source.Row, restoredPiece.Position.Column + 3);
                Position newRookPos = new Position(source.Row, restoredPiece.Position.Column + 1);
                Piece rook = Board.RemovePiece(newRookPos);
                rook.DecreaseMovementCount();
                Board.InsertPiece(rook, originalRookPos);
            }

            // #SPECIALMOVE: CASTLING LONG
            if (restoredPiece is King && target.Column == source.Column - 2)
            {
                Position originalRookPos = new Position(source.Row, restoredPiece.Position.Column - 4);
                Position newRookPos = new Position(source.Row, restoredPiece.Position.Column - 1);
                Piece rook = Board.RemovePiece(newRookPos);
                rook.IncreaseMovementCount();
                Board.InsertPiece(rook, originalRookPos);
            }
        }


        public bool IsInCheck(Color color)
        {
            Piece king = King(color);

            foreach (Piece piece in PiecesInPlay(Oponente(color)))
            {
                bool[,] available = piece.AvailableMovements();
                if (available[king.Position.Row, king.Position.Column])
                {
                    return true;
                }
            }
            return false;
        }

        public Piece King(Color color)
        {
            foreach (Piece piece in PiecesInPlay(color))
            {
                if (piece is King)
                {
                    return piece;
                }
            }
            throw new BoardException("There is no " + color + " king on board!");
        }


        public bool Checkmating(Color color)
        {
            if (!IsInCheck(color))
            {
                return false;
            }

            foreach (Piece piece in PiecesInPlay(color))
            {
                bool[,] available = piece.AvailableMovements();
                for (int i = 0; i < Board.Rows; i++)
                {
                    for (int j = 0; j < Board.Columns; j++)
                    {
                        if (available[i, j])
                        {
                            Position source = piece.Position;
                            Position target = new Position(i, j);
                            Piece capturedPiece = MovePiece(source, target);
                            bool stillInCheck = IsInCheck(color);
                            UndoMove(source, target, capturedPiece);
                            if (!stillInCheck)
                            {
                                return false;
                            }
                        }
                    }
                }
            }

            return true;
        }

        private void ChangeCurrentPlayer()
        {
            CurrentPlayer = Oponente(CurrentPlayer);
        }

        private Color Oponente(Color color)
        {
            return (color == Color.White) ? Color.Black : Color.White;
        }


        public void ValidateSourcePosition(Position pos)
        {
            Piece pieceAt = Board.PieceAt(pos);
            if (pieceAt == null)
            {
                throw new BoardException("There is no piece at the selected source position!");
            }
            if (CurrentPlayer != pieceAt.Color)
            {
                throw new BoardException("The selected piece doesn't belongs to you!");
            }
            if (!pieceAt.AreThereAvailableMovements())
            {
                throw new BoardException("The selected piece has no movements available!");
            }
        }

        public void ValidateTargetPosition(Position source, Position target)
        {
            if (!Board.PieceAt(source).IsAnAvailbleMovement(target))
            {
                throw new BoardException("Invalid target position!");
            }
        }
    }
}
