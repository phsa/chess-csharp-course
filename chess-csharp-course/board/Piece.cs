

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

        public void DecreaseMovementCount()
        {
            NumOfMovements--;
        }

        public bool AreThereAvailableMovements()
        {
            bool[,] possibilities = AvailableMovements();
            for (int i = 0; i < Board.Rows; i++)
            {
                for (int j = 0; j < Board.Columns; j++)
                {
                    if(possibilities[i, j])
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool CanMoveTo(Position pos)
        {
            return AvailableMovements()[pos.Row, pos.Column];
        }

        public abstract bool[,] AvailableMovements();
    }
}
