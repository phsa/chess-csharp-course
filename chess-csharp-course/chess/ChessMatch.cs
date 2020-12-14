using board;
using board.exceptions;
using chess.pieces;

namespace chess
{
    class ChessMatch
    {

        public Board Board { get; private set; }
        public Color CurrentPlayer { get; private set; }
        public int Round { get; private set; }

        public ChessMatch()
        {
            Board = new Board(8, 8);
            Round = 1;
            CurrentPlayer = Color.White;
            InitialSetting();
        }


        private void InitialSetting()
        {
            Board.InsertPiece(new King(Board, Color.White), new ChessPosition('d', 1).ToPosition());
            Board.InsertPiece(new Queen(Board, Color.White), new ChessPosition('e', 1).ToPosition());
            Board.InsertPiece(new Pawn(Board, Color.Black), new ChessPosition('b', 3).ToPosition());
            Board.InsertPiece(new Queen(Board, Color.Black), new ChessPosition('d', 8).ToPosition());
            Board.InsertPiece(new King(Board, Color.Black), new ChessPosition('e', 8).ToPosition());
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
            Round++;
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
