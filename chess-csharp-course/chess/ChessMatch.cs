using board;
using board.exceptions;
using chess.pieces;

namespace chess
{
    class ChessMatch
    {

        public Board Board { get; private set; }
        public Color CurrentPlayer { get; private set; }
        public int Turn { get; private set; }

        public ChessMatch()
        {
            Board = new Board(8, 8);
            Turn = 1;
            CurrentPlayer = Color.White;
            InitialSetting();
        }


        private void InitialSetting()
        {
            Board.InsertPiece(new Rook(Board, Color.White), new ChessPosition('a', 1).ToPosition());
            Board.InsertPiece(new Knight(Board, Color.White), new ChessPosition('b', 1).ToPosition());
            Board.InsertPiece(new Bishop(Board, Color.White), new ChessPosition('c', 1).ToPosition());
            Board.InsertPiece(new Queen(Board, Color.White), new ChessPosition('d', 1).ToPosition());
            Board.InsertPiece(new King(Board, Color.White), new ChessPosition('e', 1).ToPosition());
            Board.InsertPiece(new Bishop(Board, Color.White), new ChessPosition('f', 1).ToPosition());
            Board.InsertPiece(new Knight(Board, Color.White), new ChessPosition('g', 1).ToPosition());
            Board.InsertPiece(new Rook(Board, Color.White), new ChessPosition('h', 1).ToPosition());
            Board.InsertPiece(new Pawn(Board, Color.White), new ChessPosition('a', 2).ToPosition());
            Board.InsertPiece(new Pawn(Board, Color.White), new ChessPosition('b', 2).ToPosition());
            Board.InsertPiece(new Pawn(Board, Color.White), new ChessPosition('c', 2).ToPosition());
            Board.InsertPiece(new Pawn(Board, Color.White), new ChessPosition('d', 2).ToPosition());
            Board.InsertPiece(new Pawn(Board, Color.White), new ChessPosition('e', 2).ToPosition());
            Board.InsertPiece(new Pawn(Board, Color.White), new ChessPosition('f', 2).ToPosition());
            Board.InsertPiece(new Pawn(Board, Color.White), new ChessPosition('g', 2).ToPosition());
            Board.InsertPiece(new Pawn(Board, Color.White), new ChessPosition('h', 2).ToPosition());

            Board.InsertPiece(new Rook(Board, Color.Black), new ChessPosition('a', 8).ToPosition());
            Board.InsertPiece(new Knight(Board, Color.Black), new ChessPosition('b', 8).ToPosition());
            Board.InsertPiece(new Bishop(Board, Color.Black), new ChessPosition('c', 8).ToPosition());
            Board.InsertPiece(new Queen(Board, Color.Black), new ChessPosition('d', 8).ToPosition());
            Board.InsertPiece(new King(Board, Color.Black), new ChessPosition('e', 8).ToPosition());
            Board.InsertPiece(new Bishop(Board, Color.Black), new ChessPosition('f', 8).ToPosition());
            Board.InsertPiece(new Knight(Board, Color.Black), new ChessPosition('g', 8).ToPosition());
            Board.InsertPiece(new Rook(Board, Color.Black), new ChessPosition('h', 8).ToPosition());
            Board.InsertPiece(new Pawn(Board, Color.Black), new ChessPosition('a', 7).ToPosition());
            Board.InsertPiece(new Pawn(Board, Color.Black), new ChessPosition('b', 7).ToPosition());
            Board.InsertPiece(new Pawn(Board, Color.Black), new ChessPosition('c', 7).ToPosition());
            Board.InsertPiece(new Pawn(Board, Color.Black), new ChessPosition('d', 7).ToPosition());
            Board.InsertPiece(new Pawn(Board, Color.Black), new ChessPosition('e', 7).ToPosition());
            Board.InsertPiece(new Pawn(Board, Color.Black), new ChessPosition('f', 7).ToPosition());
            Board.InsertPiece(new Pawn(Board, Color.Black), new ChessPosition('g', 7).ToPosition());
            Board.InsertPiece(new Pawn(Board, Color.Black), new ChessPosition('h', 7).ToPosition());
        }

        public void MovePiece(Position source, Position target)
        {
            Piece movedPiece = Board.RemovePiece(source);
            movedPiece.IncreaseMovementCount();
            Piece capturedPiece = Board.RemovePiece(source);
            Board.InsertPiece(movedPiece, target);
        }

        public bool Finished()
        {
            return false;
        }

        public void PerformMove(Position source, Position target)
        {
            MovePiece(source, target);
            Turn++;
            ChangeCurrentPlayer();
        }

        private void ChangeCurrentPlayer()
        {
            if (CurrentPlayer == Color.White)
            {
                CurrentPlayer = Color.Black;
            }
            else
            {
                CurrentPlayer = Color.White;
            }
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
            if (!Board.PieceAt(source).CanMoveTo(target))
            {
                throw new BoardException("Invalid target position!");
            }
        }
    }
}
