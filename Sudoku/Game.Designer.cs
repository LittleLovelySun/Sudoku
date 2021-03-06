﻿namespace Sudoku {
    partial class Game {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Game));
            this.GameField = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.OptionItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NewGameMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EasyMod = new System.Windows.Forms.ToolStripMenuItem();
            this.MediumMod = new System.Windows.Forms.ToolStripMenuItem();
            this.DiffMod = new System.Windows.Forms.ToolStripMenuItem();
            this.EvilMod = new System.Windows.Forms.ToolStripMenuItem();
            this.RecordsTable = new System.Windows.Forms.ToolStripMenuItem();
            this.SelectionMod = new System.Windows.Forms.ToolStripMenuItem();
            this.BackToMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.ExitItem = new System.Windows.Forms.ToolStripMenuItem();
            this.текущаяИграToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ClearMod = new System.Windows.Forms.ToolStripMenuItem();
            this.IsCorrectItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.GameField)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // GameField
            // 
            this.GameField.AllowUserToAddRows = false;
            this.GameField.AllowUserToDeleteRows = false;
            this.GameField.AllowUserToResizeColumns = false;
            this.GameField.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GameField.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.GameField.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.GameField.Location = new System.Drawing.Point(12, 81);
            this.GameField.Name = "GameField";
            this.GameField.RowTemplate.Height = 40;
            this.GameField.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.GameField.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.GameField.Size = new System.Drawing.Size(363, 363);
            this.GameField.TabIndex = 1;
            this.GameField.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GameField_CellClick);
            this.GameField.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.GameField_CellValueChanged);
            this.GameField.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.GameField_EditingControlShowing);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Symbol", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.label1.Location = new System.Drawing.Point(270, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 34);
            this.label1.TabIndex = 4;
            this.label1.Text = "label1";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OptionItem,
            this.текущаяИграToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(387, 24);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // OptionItem
            // 
            this.OptionItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NewGameMenuItem,
            this.RecordsTable,
            this.SelectionMod,
            this.BackToMenu,
            this.ExitItem});
            this.OptionItem.Name = "OptionItem";
            this.OptionItem.Size = new System.Drawing.Size(56, 20);
            this.OptionItem.Text = "Опции";
            // 
            // NewGameMenuItem
            // 
            this.NewGameMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.EasyMod,
            this.MediumMod,
            this.DiffMod,
            this.EvilMod});
            this.NewGameMenuItem.Name = "NewGameMenuItem";
            this.NewGameMenuItem.Size = new System.Drawing.Size(192, 22);
            this.NewGameMenuItem.Text = "Новая игра";
            // 
            // EasyMod
            // 
            this.EasyMod.Name = "EasyMod";
            this.EasyMod.Size = new System.Drawing.Size(179, 22);
            this.EasyMod.Text = "Легко";
            this.EasyMod.Click += new System.EventHandler(this.EasyMod_Click);
            // 
            // MediumMod
            // 
            this.MediumMod.Name = "MediumMod";
            this.MediumMod.Size = new System.Drawing.Size(179, 22);
            this.MediumMod.Text = "Умеренно";
            this.MediumMod.Click += new System.EventHandler(this.MediumMod_Click);
            // 
            // DiffMod
            // 
            this.DiffMod.Name = "DiffMod";
            this.DiffMod.Size = new System.Drawing.Size(179, 22);
            this.DiffMod.Text = "Сложно";
            this.DiffMod.Click += new System.EventHandler(this.DiffMod_Click);
            // 
            // EvilMod
            // 
            this.EvilMod.Name = "EvilMod";
            this.EvilMod.Size = new System.Drawing.Size(179, 22);
            this.EvilMod.Text = "О-о-очень сложно";
            this.EvilMod.Click += new System.EventHandler(this.EvilMod_Click);
            // 
            // RecordsTable
            // 
            this.RecordsTable.Name = "RecordsTable";
            this.RecordsTable.Size = new System.Drawing.Size(192, 22);
            this.RecordsTable.Text = "Таблица рекордов";
            this.RecordsTable.Click += new System.EventHandler(this.RecordsTable_Click);
            // 
            // SelectionMod
            // 
            this.SelectionMod.Name = "SelectionMod";
            this.SelectionMod.Size = new System.Drawing.Size(192, 22);
            this.SelectionMod.Text = "Включить выделение";
            this.SelectionMod.Click += new System.EventHandler(this.SelectionMod_Click);
            // 
            // BackToMenu
            // 
            this.BackToMenu.Name = "BackToMenu";
            this.BackToMenu.Size = new System.Drawing.Size(192, 22);
            this.BackToMenu.Text = "Выйти в меню";
            this.BackToMenu.Click += new System.EventHandler(this.BackToMenu_Click);
            // 
            // ExitItem
            // 
            this.ExitItem.Name = "ExitItem";
            this.ExitItem.Size = new System.Drawing.Size(192, 22);
            this.ExitItem.Text = "Выйти";
            this.ExitItem.Click += new System.EventHandler(this.ExitItem_Click);
            // 
            // текущаяИграToolStripMenuItem
            // 
            this.текущаяИграToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ClearMod,
            this.IsCorrectItem});
            this.текущаяИграToolStripMenuItem.Name = "текущаяИграToolStripMenuItem";
            this.текущаяИграToolStripMenuItem.Size = new System.Drawing.Size(95, 20);
            this.текущаяИграToolStripMenuItem.Text = "Текущая игра";
            // 
            // ClearMod
            // 
            this.ClearMod.Name = "ClearMod";
            this.ClearMod.Size = new System.Drawing.Size(212, 22);
            this.ClearMod.Text = "Сбросить ввод";
            this.ClearMod.Click += new System.EventHandler(this.ClearToCorrect_Click);
            // 
            // IsCorrectItem
            // 
            this.IsCorrectItem.Name = "IsCorrectItem";
            this.IsCorrectItem.Size = new System.Drawing.Size(212, 22);
            this.IsCorrectItem.Text = "Проверить корректность";
            this.IsCorrectItem.Click += new System.EventHandler(this.IsCorrectItem_Click);
            // 
            // Game
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(387, 457);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.GameField);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Game";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Судоку";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Game_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.GameField)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView GameField;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem OptionItem;
        private System.Windows.Forms.ToolStripMenuItem NewGameMenuItem;
        private System.Windows.Forms.ToolStripMenuItem BackToMenu;
        private System.Windows.Forms.ToolStripMenuItem текущаяИграToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ClearMod;
        private System.Windows.Forms.ToolStripMenuItem IsCorrectItem;
        private System.Windows.Forms.ToolStripMenuItem ExitItem;
        private System.Windows.Forms.ToolStripMenuItem RecordsTable;
        private System.Windows.Forms.ToolStripMenuItem SelectionMod;
        private System.Windows.Forms.ToolStripMenuItem EasyMod;
        private System.Windows.Forms.ToolStripMenuItem MediumMod;
        private System.Windows.Forms.ToolStripMenuItem DiffMod;
        private System.Windows.Forms.ToolStripMenuItem EvilMod;
    }
}