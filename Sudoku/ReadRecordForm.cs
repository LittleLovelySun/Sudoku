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
    public partial class ReadRecordForm : Form {

        public string RecordName {
            get {
                return textBox1.Text;
            }
        }

        public ReadRecordForm() {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) {
            Close();
        }
    }
}
