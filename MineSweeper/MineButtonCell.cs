using System.Windows.Forms;

namespace MineSweeper
{
    class MineButtonCell : DataGridViewImageCell
    {
        public bool Mined;
        public MineCellState CellState;
        public int NeighborMineCount;

        public MineButtonCell()
        {
            Mined = false;
            CellState = MineCellState.Hidden;
            NeighborMineCount = 0;
        }

    }
}
