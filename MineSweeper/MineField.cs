using System;
using System.Drawing;
using System.Windows.Forms;
using MineSweeper.Properties;

namespace MineSweeper
{
    class MineField : DataGridView
    {
        private static readonly Bitmap _1_Mine              = Resources._1_Mine;
        private static readonly Bitmap _2_Mine              = Resources._2_Mine;
        private static readonly Bitmap _3_Mine              = Resources._3_Mine;
        private static readonly Bitmap _4_Mine              = Resources._4_Mine;
        private static readonly Bitmap _5_Mine              = Resources._5_Mine;
        private static readonly Bitmap _6_Mine              = Resources._6_Mine;
        private static readonly Bitmap _7_Mine              = Resources._7_Mine;
        private static readonly Bitmap _8_Mine              = Resources._8_Mine;
        public static readonly Bitmap EmptyCell            = Resources.EmptyCell;
        private static readonly Bitmap ExplodedMine         = Resources.ExplodedMine;
        public static readonly Bitmap HiddenCell           = Resources.HiddenCell;
        private static readonly Bitmap Mine                 = Resources.Mine;
        private static readonly Bitmap PointedCell          = Resources.PointedCell;
        private static readonly Bitmap PushedCell           = Resources.PushedCell;
        private static readonly Bitmap RightPointedMine     = Resources.RightPointedMine;
        private static readonly Bitmap UnknownCell          = Resources.UnknownCell;
        private static readonly Bitmap WrongPointedMine     = Resources.WrongPointedMine;

        public int MineCount { get; private set; }
        public bool right { get; private set; }
        public bool left { get; private set; }
        private bool _initializedField;
        public MineButtonCell EnteredCell { get; private set; }

        public delegate void MineFieldCellEventHandler(MineButtonCell cell);
        
        public event MineFieldCellEventHandler OnCellOpen;
        public event MineFieldCellEventHandler OnCellPoint;
        public event MineFieldCellEventHandler OnCellUnPoint;
        public event MineFieldCellEventHandler OnMineExplotion;

        public MineField() : this(9, 9, 10) { }
        public MineField(int rowCount, int colCount, int mineCount)
        {
            _initializedField = false;

            if (rowCount < 9) rowCount = 9;
            if (colCount < 9) colCount = 9;
            if (mineCount > rowCount * colCount) mineCount = rowCount * colCount;

            MineCount = mineCount;
            
        }

        new public MineButtonCell this[int rowIndex, int colIndex]
        {
            get
            {
                if ((rowIndex >= 0) && (rowIndex < RowCount) &&
                    (colIndex >= 0) && (colIndex < ColumnCount))
                    return (MineButtonCell)base[colIndex, rowIndex];
                throw new IndexOutOfRangeException();
            }
            set
            {
                if ((rowIndex >= 0) && (rowIndex < RowCount) &&
                    (colIndex >= 0) && (colIndex < ColumnCount))
                    base[colIndex, rowIndex] = value;
            }
        }

        private void InitializeField(MineButtonCell emptyCell)
        {
            int[] minePositions = new int[MineCount];

            Random rnd = new Random();

            int num = 0;
            while (num < MineCount)
            {
                int position = rnd.Next(0, RowCount * ColumnCount);

                int row = position / ColumnCount;
                int col = position % ColumnCount;

                //if mineCount lower 50% then cells count,
                //then first sel might be empty
                if ((MineCount < RowCount * ColumnCount / 2) &&
                (Math.Abs(emptyCell.RowIndex - row) <= 1) &&
                (Math.Abs(emptyCell.ColumnIndex - col) <= 1))
                    continue;

                MineButtonCell cell = this[row, col];

                if (!cell.Mined)
                {
                    cell.Mined = true;
                    for (int i = -1; i <= 1; i++)
                        for (int j = -1; j <= 1; j++)
                        {
                            if ((i == 0) && (j == 0)) continue;

                            if ((row + i >= 0) && (row + i < RowCount) &&
                                (col + j >= 0) && (col + j < ColumnCount))
                                this[row + i, col + j].NeighborMineCount++;
                        }
                    num++;
                }
            }

            _initializedField = true;
        }
               
        protected override void OnCellClick(DataGridViewCellEventArgs e)
        {
            if (!((left) && (right)))
            {
                MineButtonCell cell = this[e.RowIndex, e.ColumnIndex];
                if (cell.CellState != MineCellState.Pointed)
                    OpenCell(cell);
            }
        }
        protected override void OnMouseDown(MouseEventArgs e)
        {
            MineButtonCell cell = EnteredCell;

            if (e.Button == MouseButtons.Left)
                left = true;
            else if (e.Button == MouseButtons.Right)
                right = true;

            if ((left) && (right))
            {
                DownEnteredCell();
                base.OnMouseDown(e);
            }
            else if (cell != null)
            {

                if (e.Button == MouseButtons.Right)
                {
                    if (cell.CellState == MineCellState.Hidden)
                    {
                        cell.CellState = MineCellState.Pointed;
                        cell.Value = PointedCell;
                        OnCellPoint(cell);
                    }
                    else if (cell.CellState == MineCellState.Pointed)
                    {
                        cell.CellState = MineCellState.Unknown;
                        cell.Value = UnknownCell;
                        OnCellUnPoint(cell);
                    }
                    else if (cell.CellState == MineCellState.Unknown)
                    {
                        cell.CellState = MineCellState.Hidden;
                        cell.Value = HiddenCell;
                    }                    
                }
                else if ((e.Button == MouseButtons.Left) &&
                    ((cell.CellState == MineCellState.Hidden) || (cell.CellState == MineCellState.Unknown)))
                {
                    cell.Value = EmptyCell;
                }

            }            
        }
        protected override void OnMouseUp(MouseEventArgs e)
        {
            if(EnteredCell!=null)
                UpEnteredCell(EnteredCell);

            if (e.Button == MouseButtons.Left)
                left = false;
            else if (e.Button == MouseButtons.Right)
                right = false;

        }
        protected override void OnCellMouseEnter(DataGridViewCellEventArgs e)
        {
            base.OnCellMouseEnter(e);

            EnteredCell = this[e.RowIndex, e.ColumnIndex];

            if ((right) && (left))
            {
                DownEnteredCell();
            }
            else if ((left) && ((EnteredCell.CellState == MineCellState.Hidden) || (EnteredCell.CellState == MineCellState.Unknown)))
                EnteredCell.Value = EmptyCell;
            else if (EnteredCell.CellState == MineCellState.Hidden)
                EnteredCell.Value = PushedCell;

        }
        protected override void OnCellMouseLeave(DataGridViewCellEventArgs e)
        {
            base.OnCellMouseLeave(e);

            EnteredCell = null;

            MineButtonCell cell = this[e.RowIndex, e.ColumnIndex];

            if ((right) && (left))
                UpEnteredCell(this[e.RowIndex, e.ColumnIndex]);
            else if (cell.CellState == MineCellState.Hidden)
                cell.Value = GetCellValueByState(cell);
        }

        public Bitmap GetCellValue(MineButtonCell cell)
        {
            Bitmap result = null;

            if (cell.Mined)
            {
                result = Mine;
            }
            else
                switch (cell.NeighborMineCount)
                {
                    case 0:
                        {
                            result = EmptyCell;
                            break;
                        }
                    case 1:
                        {
                            result = _1_Mine;
                            break;
                        }
                    case 2:
                        {
                            result = _2_Mine;
                            break;
                        }
                    case 3:
                        {
                            result = _3_Mine;
                            break;
                        }
                    case 4:
                        {
                            result = _4_Mine;
                            break;
                        }
                    case 5:
                        {
                            result = _5_Mine;
                            break;
                        }
                    case 6:
                        {
                            result = _6_Mine;
                            break;
                        }
                    case 7:
                        {
                            result = _7_Mine;
                            break;
                        }
                    case 8:
                        {
                            result = _8_Mine;
                            break;
                        }
                }

            return result;
        }
        public Bitmap GetCellValueByState(MineButtonCell cell)
        {
            Bitmap result = null;

            switch (cell.CellState)
            {
                case MineCellState.Hidden:
                    {
                        result = HiddenCell;
                        break;
                    }
                case MineCellState.Pointed:
                    {
                        result = PointedCell;
                        break;
                    }
                case MineCellState.Unknown:
                    {
                        result = UnknownCell;
                        break;
                    }
                case MineCellState.Opened:
                    {
                        result = GetCellValue(cell);
                        break;
                    }
            }

            return result;
        }
        
        protected void DownEnteredCell()
        {
            if ((left) && (right)
                && (EnteredCell != null))
            {
                int row = EnteredCell.RowIndex;
                int col = EnteredCell.ColumnIndex;

                for (int i = -1; i <= 1; i++)
                    for (int j = -1; j <= 1; j++)
                    {
                        if ((row + i < 0) || (row + i >= RowCount) ||
                        (col + j < 0) || (col + j >= ColumnCount)
                            || (this[row + i, col + j].CellState == MineCellState.Opened)
                            || (this[row + i, col + j].CellState == MineCellState.Pointed))
                            continue;

                        this[row + i, col + j].Value = EmptyCell;
                    }
            }
        }
        protected void UpEnteredCell(MineButtonCell cell)
        {
            int row = cell.RowIndex;
            int col = cell.ColumnIndex;

            if ((left) && (right))
            {
                int? pointedCellsCount = null;

                if ((EnteredCell != null) && (EnteredCell.CellState == MineCellState.Opened))
                {

                    pointedCellsCount = 0;

                    for (int i = -1; i <= 1; i++)
                        for (int j = -1; j <= 1; j++)
                        {
                            if ((row + i < 0) || (row + i >= RowCount) ||
                            (col + j < 0) || (col + j >= ColumnCount)
                                || (this[row + i, col + j].CellState == MineCellState.Opened))
                                continue;

                            if (this[row + i, col + j].CellState == MineCellState.Pointed)
                                pointedCellsCount++;
                        }
                }

                for (int i = -1; i <= 1; i++)
                    for (int j = -1; j <= 1; j++)
                    {
                        if ((row + i < 0) || (row + i >= RowCount) ||
                        (col + j < 0) || (col + j >= ColumnCount)
                            || (this[row + i, col + j].CellState == MineCellState.Opened)
                            || (this[row + i, col + j].CellState == MineCellState.Pointed))
                            continue;
                        if ((pointedCellsCount != null) && (pointedCellsCount == EnteredCell.NeighborMineCount))
                        {
                            OpenCell(this[row + i, col + j]);
                        }
                        else
                        {
                            this[row + i, col + j].Value = GetCellValueByState(this[row + i, col + j]);
                        }
                    }
            }
            else if (!(right) && (left))
            {
                OpenCell(cell);
            }
        }
        public void OpenCell(MineButtonCell cell)
        {
            if (!_initializedField)
                InitializeField(cell);

            if ((cell.CellState != MineCellState.Opened)
                && ((cell.CellState != MineCellState.Pointed)))
            {
                if (cell.Mined)
                {
                    cell.CellState = MineCellState.Opened;
                    cell.Value = ExplodedMine;
                    OnMineExplotion(cell);
                    OpenField();
                }
                else
                {
                    cell.CellState = MineCellState.Opened;
                    cell.Value = GetCellValue(cell);

                    if (cell.NeighborMineCount == 0)
                        for (int i = -1; i <= 1; i++)
                            for (int j = -1; j <= 1; j++)
                            {
                                if (!((i == 0) && (j == 0)) &&
                                    (cell.RowIndex + i >= 0) && (cell.RowIndex + i < RowCount) &&
                                    (cell.ColumnIndex + j >= 0) && (cell.ColumnIndex + j < ColumnCount))
                                {

                                    OpenCell(this[cell.RowIndex + i, cell.ColumnIndex + j]);
                                }
                            }


                }
            }

            OnCellOpen(cell);
        }
        public void OpenField()
        {
            for (int i = 0; i < RowCount; i++)
                for (int j = 0; j < ColumnCount; j++)
                    if ((this[i, j].CellState != MineCellState.Opened)
                        && ((this[i, j].Mined) || this[i, j].CellState == MineCellState.Pointed))
                    {
                        if (this[i, j].CellState == MineCellState.Pointed)
                            if (this[i, j].Mined)
                                this[i, j].Value = RightPointedMine;
                            else
                                this[i, j].Value = WrongPointedMine;
                        else
                            this[i, j].Value = GetCellValue(this[i, j]);
                        this[i, j].CellState = MineCellState.Opened;
                    }
        }
        public bool AllMinesSweeped()
        {
            int hiddenCellsCount = 0;
            MineButtonCell cell;

            for (int i = 0; i < RowCount; i++)
                for (int j = 0; j < ColumnCount; j++)
                {
                    cell = this[i, j];
                    if (cell.CellState != MineCellState.Opened)
                        hiddenCellsCount++;

                    if (hiddenCellsCount > MineCount)
                        return false;
                }

            return true;
        }
    }
}
