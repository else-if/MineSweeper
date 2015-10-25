using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace MineSweeper
{
    public partial class MainForm : Form
    {
        private int _rowCount = 9;
        private int _colCount = 9;
        private int _mineCount = 10;

        private int _minesCountLeft;
        private int _elapsedTime;
        private MineField _gameField;
        private bool _gameStarted;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MineSweeper_Load(object sender, EventArgs e)
        {
            InitializeGameField();            
        }

        private void InitializeGameField()
        {
            SuspendLayout();
            if (_gameField != null)
            {
                _gameField.Dispose();
                Controls.Remove(_gameField);
            }
            _gameField = new MineField(_rowCount, _colCount, _mineCount);

            ((ISupportInitialize)(_gameField)).BeginInit();

            _gameField.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            _gameField.ColumnHeadersVisible = false;
            _gameField.Location = new Point(4, 28);
            _gameField.Margin = new Padding(0);
            _gameField.MultiSelect = false;
            _gameField.Name = "GameField";
            _gameField.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            _gameField.RowHeadersVisible = false;
            _gameField.RowsDefaultCellStyle = new DataGridViewCellStyle();
            _gameField.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _gameField.RowTemplate.Resizable = DataGridViewTriState.False;
            _gameField.SelectionMode = DataGridViewSelectionMode.CellSelect;
            _gameField.TabIndex = 0;

            ((ISupportInitialize)(_gameField)).EndInit();

            int columnWidth = 16;

            _gameField.Columns.Clear();
            _gameField.CellBorderStyle = DataGridViewCellBorderStyle.None;
            _gameField.ColumnHeadersVisible = false;
            _gameField.RowHeadersVisible = false;

            DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle
            {
                Alignment = DataGridViewContentAlignment.MiddleCenter
            };

            for (int i = 0; i < _colCount; i++)
            {
                DataGridViewButtonColumn column = new DataGridViewButtonColumn
                {
                    DefaultCellStyle = dataGridViewCellStyle,
                    HeaderText = "",
                    MinimumWidth = columnWidth,
                    Resizable = DataGridViewTriState.False,
                    Width = columnWidth
                };
                _gameField.Columns.Add(column);
            }

            _gameField.RowCount = _rowCount;
            foreach (DataGridViewRow row in _gameField.Rows)
                row.Height = columnWidth;

            _gameField.Width = columnWidth * _colCount + 2;
            _gameField.Height = columnWidth * _rowCount + 2;
            
            Controls.Add(_gameField);
            ResumeLayout();

            FillGameField();

            ClientSize = new Size(_gameField.Right + _gameField.Left, _gameField.Bottom + _gameField.Left + 40);

            _gameField.OnCellOpen += OnCellOpen;
            _gameField.OnCellPoint += OnCellPoint;
            _gameField.OnCellUnPoint += OnCellUnPoint;
            _gameField.OnMineExplotion += OnMineExplotion;

            TimeSpent.Top = _gameField.Bottom + _gameField.Left + 10;
            TimeSpent.Left = ClientSize.Width / 4 - TimeSpent.Width / 2;

            MinesLeft.Top = _gameField.Bottom + _gameField.Left + 10;
            MinesLeft.Left = ClientSize.Width * 3 / 4 - MinesLeft.Width / 2;

            _minesCountLeft = _mineCount;
            _elapsedTime = 0;

            UpdateMineCountLabel();
            UpdateTimeSpentLabel();

            TimeController.Enabled = false;

            _gameStarted = false;

        }
        private void FillGameField()
        {
            for (var i = 0; i < _rowCount; i++)
            {
                for (var j = 0; j < _colCount; j++)
                {
                    _gameField[i, j] = new MineButtonCell
                    {
                        Selected = false,
                        Value = MineField.HiddenCell
                    };
                }                
            }
        }

        private void OnCellOpen(MineButtonCell cell)
        {
            if (!_gameStarted)
            {
                TimeController.Enabled = true;
                _gameStarted = true;
            }

            if (!_gameField.AllMinesSweeped()) return;
            _gameField.OpenField();
            TimeController.Enabled = false;
        }
        private void OnCellPoint(MineButtonCell cell)
        {
            _minesCountLeft--;
            UpdateMineCountLabel();
        }
        private void OnCellUnPoint(MineButtonCell cell)
        {
            _minesCountLeft++;
            UpdateMineCountLabel();
        }
        private void OnMineExplotion(MineButtonCell cell)
        {
            TimeController.Enabled = false;
        }

        private void UpdateMineCountLabel()
        {
            MinesLeft.Text = _minesCountLeft.ToString();
        }
        private void UpdateTimeSpentLabel()
        {
            TimeSpent.Text = _elapsedTime.ToString();
        }

        private void newGameF2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InitializeGameField();
        }
        private void beginnerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _rowCount = 9;
            _colCount = 9;
            _mineCount = 10;
            InitializeGameField();
        }
        private void mediumToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _rowCount = 16;
            _colCount = 16;
            _mineCount = 40;
            InitializeGameField();
        }
        private void expertToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _rowCount = 16;
            _colCount = 30;
            _mineCount = 99;
            InitializeGameField();
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void TimeController_Tick(object sender, EventArgs e)
        {
            _elapsedTime++;
            UpdateTimeSpentLabel();
        }
        
    }
}
