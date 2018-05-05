using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sudoku {
    public partial class RecordsTable : Form {

        void PrintTable(StringCollection list) {
            if (list == null) {
                richTextBox1.Text = "Пока рекордов нет";
                return;
            }
            if (list.Count == 0) {
                richTextBox1.Text = "Пока рекордов нет";
                return;
            }
                
            for (int i = 0; i < list.Count; i++) {
                richTextBox1.Text += list[i] + "\n";
            }
        }

        public RecordsTable(int diff) {
            InitializeComponent();

            richTextBox1.SelectionAlignment = HorizontalAlignment.Center;
            if (diff == Properties.Settings.Default.easydiff) {
                Text = "Лёгкий уровень";
                PrintTable(Properties.Settings.Default.EasyRecords);
            } else if (diff == Properties.Settings.Default.mediumdiff) {
                Text = "Средний уровень";
                PrintTable(Properties.Settings.Default.MediumRecords);
            } else if (diff == Properties.Settings.Default.diffdiff) {
                Text = "Сложный уровень";
                PrintTable(Properties.Settings.Default.DifficultRecords);
            } else if (diff == Properties.Settings.Default.evildiff) {
                Text = "Ооооочень сложный уровень";
                PrintTable(Properties.Settings.Default.EvilRecords);
            }
        }

        private void RecordsTable_FormClosing(object sender, FormClosingEventArgs e) {
            DialogResult = DialogResult.Cancel;
        }
    }
}
