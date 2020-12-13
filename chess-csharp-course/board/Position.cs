
namespace board
{
    class Position
    {

        public int Row { get; set; }
        public int Column { get; set; }

        public Position(int row, int column)
        {
            Row = row;
            Column = column;
        }

        public void Update(int row, int column)
        {
            Row = row;
            Column = column;
        }

        public override string ToString()
        {
            return Row
                + ", "
                + Column;
        }
    }
}
