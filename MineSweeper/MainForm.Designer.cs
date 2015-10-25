using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using MineSweeper.Properties;

namespace MineSweeper
{
    partial class MainForm
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.MainMenu = new System.Windows.Forms.MenuStrip();
            this.gameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newGameF2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.beginnerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.intermediateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.expertToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.customToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TimeSpent = new System.Windows.Forms.Label();
            this.MinesLeft = new System.Windows.Forms.Label();
            this.TimeController = new System.Windows.Forms.Timer(this.components);
            this.MainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainMenu
            // 
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gameToolStripMenuItem});
            this.MainMenu.Location = new System.Drawing.Point(0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Size = new System.Drawing.Size(661, 24);
            this.MainMenu.TabIndex = 0;
            this.MainMenu.Text = "menuStrip1";
            // 
            // gameToolStripMenuItem
            // 
            this.gameToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newGameF2ToolStripMenuItem,
            this.toolStripSeparator1,
            this.beginnerToolStripMenuItem,
            this.intermediateToolStripMenuItem,
            this.expertToolStripMenuItem,
            this.customToolStripMenuItem,
            this.toolStripSeparator2,
            this.exitToolStripMenuItem});
            this.gameToolStripMenuItem.Name = "gameToolStripMenuItem";
            this.gameToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.gameToolStripMenuItem.Text = "Game";
            // 
            // newGameF2ToolStripMenuItem
            // 
            this.newGameF2ToolStripMenuItem.Name = "newGameF2ToolStripMenuItem";
            this.newGameF2ToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.newGameF2ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.newGameF2ToolStripMenuItem.Text = "New game";
            this.newGameF2ToolStripMenuItem.Click += new System.EventHandler(this.newGameF2ToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(149, 6);
            // 
            // beginnerToolStripMenuItem
            // 
            this.beginnerToolStripMenuItem.Name = "beginnerToolStripMenuItem";
            this.beginnerToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.beginnerToolStripMenuItem.Text = "Beginner";
            this.beginnerToolStripMenuItem.Click += new System.EventHandler(this.beginnerToolStripMenuItem_Click);
            // 
            // intermediateToolStripMenuItem
            // 
            this.intermediateToolStripMenuItem.Name = "intermediateToolStripMenuItem";
            this.intermediateToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.intermediateToolStripMenuItem.Text = "Medium";
            this.intermediateToolStripMenuItem.Click += new System.EventHandler(this.mediumToolStripMenuItem_Click);
            // 
            // expertToolStripMenuItem
            // 
            this.expertToolStripMenuItem.Name = "expertToolStripMenuItem";
            this.expertToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.expertToolStripMenuItem.Text = "Expert";
            this.expertToolStripMenuItem.Click += new System.EventHandler(this.expertToolStripMenuItem_Click);
            // 
            // customToolStripMenuItem
            // 
            this.customToolStripMenuItem.Name = "customToolStripMenuItem";
            this.customToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.customToolStripMenuItem.Text = "Custom...";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(149, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // TimeSpent
            // 
            this.TimeSpent.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.TimeSpent.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.TimeSpent.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TimeSpent.Image = global::MineSweeper.Properties.Resources.Clock;
            this.TimeSpent.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.TimeSpent.Location = new System.Drawing.Point(51, 398);
            this.TimeSpent.Name = "TimeSpent";
            this.TimeSpent.Size = new System.Drawing.Size(60, 20);
            this.TimeSpent.TabIndex = 1;
            this.TimeSpent.Text = "0";
            this.TimeSpent.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // MinesLeft
            // 
            this.MinesLeft.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.MinesLeft.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.MinesLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MinesLeft.Image = global::MineSweeper.Properties.Resources.PointedCell;
            this.MinesLeft.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.MinesLeft.Location = new System.Drawing.Point(193, 398);
            this.MinesLeft.Name = "MinesLeft";
            this.MinesLeft.Size = new System.Drawing.Size(60, 20);
            this.MinesLeft.TabIndex = 2;
            this.MinesLeft.Text = "0";
            this.MinesLeft.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // TimeController
            // 
            this.TimeController.Interval = 1000;
            this.TimeController.Tick += new System.EventHandler(this.TimeController_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(661, 430);
            this.Controls.Add(this.MinesLeft);
            this.Controls.Add(this.TimeSpent);
            this.Controls.Add(this.MainMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Text = "Mine sweeper";
            this.Load += new System.EventHandler(this.MineSweeper_Load);
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MenuStrip MainMenu;
        private ToolStripMenuItem gameToolStripMenuItem;
        private ToolStripMenuItem newGameF2ToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem beginnerToolStripMenuItem;
        private ToolStripMenuItem intermediateToolStripMenuItem;
        private ToolStripMenuItem expertToolStripMenuItem;
        private ToolStripMenuItem customToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem exitToolStripMenuItem;
        private Label TimeSpent;
        private Label MinesLeft;
        private Timer TimeController;
    }
}

