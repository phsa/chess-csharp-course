

namespace board
{
    abstract class Piece
    {

        public Position Position { get; set; }
        public Color Color { get; protected set; }
        public int NumOfMovements { get; protected set; }
        public Board Board { get; protected set; }

        public Piece(Board board, Color color)
        {
            Color = color;
            Board = board;
            NumOfMovements = 0;
        }

        public void IncreaseMovementCount()
        {
            NumOfMovements++;
        }

        public abstract bool[,] PossibleMovements();
    }
}
