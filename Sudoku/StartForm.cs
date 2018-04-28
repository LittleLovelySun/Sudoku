using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sudoku {
    public partial class StartForm : Form {
        public StartForm() {
            InitializeComponent();
        }

        private void Gamebtn_Click(object sender, EventArgs e) {
            this.Hide();
            Game game = new Game(this);
            game.ShowDialog();
        }

        private void Solvebtn_Click(object sender, EventArgs e) {
            this.Hide();
            Form1 solve = new Form1();
            solve.ShowDialog();
        }        
    }
}
