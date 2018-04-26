namespace Sudoku {
    partial class Form1 {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent() {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.DataField = new System.Windows.Forms.DataGridView();
            this.Solve = new System.Windows.Forms.Button();
            this.DataSolvation = new System.Windows.Forms.DataGridView();
            this.backbtn = new System.Windows.Forms.Button();
            this.forwardbtn = new System.Windows.Forms.Button();
            this.Clearbtn = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.InsertFromFileItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.DataField)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSolvation)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // DataField
            // 
            this.DataField.AllowUserToAddRows = false;
            this.DataField.AllowUserToDeleteRows = false;
            this.DataField.AllowUserToResizeColumns = false;
            this.DataField.AllowUserToResizeRows = false;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataField.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.DataField.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DataField.Location = new System.Drawing.Point(12, 47);
            this.DataField.Name = "DataField";
            this.DataField.RowTemplate.Height = 40;
            this.DataField.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.DataField.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.DataField.Size = new System.Drawing.Size(363, 363);
            this.DataField.TabIndex = 0;
            this.DataField.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataField_CellValueChanged);
            // 
            // Solve
            // 
            this.Solve.Location = new System.Drawing.Point(300, 437);
            this.Solve.Name = "Solve";
            this.Solve.Size = new System.Drawing.Size(75, 23);
            this.Solve.TabIndex = 2;
            this.Solve.Text = "Решить";
            this.Solve.UseVisualStyleBackColor = true;
            this.Solve.Click += new System.EventHandler(this.Solve_Click);
            // 
            // DataSolvation
            // 
            this.DataSolvation.AllowUserToAddRows = false;
            this.DataSolvation.AllowUserToDeleteRows = false;
            this.DataSolvation.AllowUserToResizeColumns = false;
            this.DataSolvation.AllowUserToResizeRows = false;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataSolvation.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.DataSolvation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DataSolvation.Location = new System.Drawing.Point(426, 47);
            this.DataSolvation.Name = "DataSolvation";
            this.DataSolvation.RowTemplate.Height = 40;
            this.DataSolvation.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.DataSolvation.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.DataSolvation.Size = new System.Drawing.Size(363, 363);
            this.DataSolvation.TabIndex = 3;
            // 
            // backbtn
            // 
            this.backbtn.Location = new System.Drawing.Point(426, 437);
            this.backbtn.Name = "backbtn";
            this.backbtn.Size = new System.Drawing.Size(75, 23);
            this.backbtn.TabIndex = 4;
            this.backbtn.Text = "Назад";
            this.backbtn.UseVisualStyleBackColor = true;
            this.backbtn.Click += new System.EventHandler(this.backbtn_Click);
            // 
            // forwardbtn
            // 
            this.forwardbtn.Location = new System.Drawing.Point(714, 437);
            this.forwardbtn.Name = "forwardbtn";
            this.forwardbtn.Size = new System.Drawing.Size(75, 23);
            this.forwardbtn.TabIndex = 5;
            this.forwardbtn.Text = "Вперёд";
            this.forwardbtn.UseVisualStyleBackColor = true;
            this.forwardbtn.Click += new System.EventHandler(this.forwardbtn_Click);
            // 
            // Clearbtn
            // 
            this.Clearbtn.Location = new System.Drawing.Point(12, 437);
            this.Clearbtn.Name = "Clearbtn";
            this.Clearbtn.Size = new System.Drawing.Size(75, 23);
            this.Clearbtn.TabIndex = 6;
            this.Clearbtn.Text = "Очистить";
            this.Clearbtn.UseVisualStyleBackColor = true;
            this.Clearbtn.Click += new System.EventHandler(this.Clearbtn_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.InsertFromFileItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(812, 24);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // InsertFromFileItem
            // 
            this.InsertFromFileItem.Name = "InsertFromFileItem";
            this.InsertFromFileItem.Size = new System.Drawing.Size(120, 20);
            this.InsertFromFileItem.Text = "Вставить из файла";
            this.InsertFromFileItem.Click += new System.EventHandler(this.InsertFromFileItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(812, 481);
            this.Controls.Add(this.Clearbtn);
            this.Controls.Add(this.forwardbtn);
            this.Controls.Add(this.backbtn);
            this.Controls.Add(this.DataSolvation);
            this.Controls.Add(this.Solve);
            this.Controls.Add(this.DataField);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Судоку";
            ((System.ComponentModel.ISupportInitialize)(this.DataField)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSolvation)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DataField;
        private System.Windows.Forms.Button Solve;
        private System.Windows.Forms.DataGridView DataSolvation;
        private System.Windows.Forms.Button backbtn;
        private System.Windows.Forms.Button forwardbtn;
        private System.Windows.Forms.Button Clearbtn;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem InsertFromFileItem;
    }
}

