namespace Sudoku {
    partial class StartForm {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StartForm));
            this.Gamebtn = new System.Windows.Forms.Button();
            this.Solvebtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Gamebtn
            // 
            this.Gamebtn.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Gamebtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Gamebtn.Font = new System.Drawing.Font("Perpetua Titling MT", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Gamebtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.Gamebtn.Location = new System.Drawing.Point(12, 239);
            this.Gamebtn.Name = "Gamebtn";
            this.Gamebtn.Size = new System.Drawing.Size(106, 48);
            this.Gamebtn.TabIndex = 0;
            this.Gamebtn.Text = "Играть";
            this.Gamebtn.UseVisualStyleBackColor = false;
            this.Gamebtn.Click += new System.EventHandler(this.Gamebtn_Click);
            // 
            // Solvebtn
            // 
            this.Solvebtn.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Solvebtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Solvebtn.Font = new System.Drawing.Font("Perpetua Titling MT", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Solvebtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.Solvebtn.Location = new System.Drawing.Point(183, 239);
            this.Solvebtn.Name = "Solvebtn";
            this.Solvebtn.Size = new System.Drawing.Size(112, 48);
            this.Solvebtn.TabIndex = 1;
            this.Solvebtn.Text = "Решить";
            this.Solvebtn.UseVisualStyleBackColor = false;
            this.Solvebtn.Click += new System.EventHandler(this.Solvebtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Proxima Nova Lt", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(56, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(188, 23);
            this.label1.TabIndex = 2;
            this.label1.Text = "Что хотите сделать?";
            // 
            // StartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(307, 310);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Solvebtn);
            this.Controls.Add(this.Gamebtn);
            this.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "StartForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Судоку";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Gamebtn;
        private System.Windows.Forms.Button Solvebtn;
        private System.Windows.Forms.Label label1;
    }
}