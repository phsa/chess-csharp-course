using board;
using chess.pieces;

namespace chess
{
    class ChessMatch
    {

        private int _round;
        private Color _currentPlayer;
        public Board Board { get; private set; }

        public ChessMatch()
        {
            Board = new Board(8, 8);
            _round = 1;
            _currentPlayer = Color.White;
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
    }
}
