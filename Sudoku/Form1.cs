using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Sudoku {
    public partial class Form1 : Form {
        const int width = 40;
        const int n = 9;
        List<Field> SolutionList = new List<Field>();
        int ListIndex = 0;

        void printMatrix(int[,,] mat, DataGridView data) {
            InitGrid(DataSolvation);
            for (int i = 0; i < n; i++) {
                for (int j = 0; j < n; j++) {
                    if (mat[i, j, 0] != 0)
                        data[j, i].Value = mat[i, j, 0];
                }
            }
        }

        public Form1() {
            InitializeComponent();
            InitGrid(DataField);
            InitGrid(DataSolvation);
            backbtn.Visible = false;
            forwardbtn.Visible = false;
            Clearbtn.Visible = false;
        }

        private void InitGrid(DataGridView data) {
            data.Rows.Clear();
            data.Columns.Clear();

            for (int i = 0; i < n; i++) {
                data.Columns.Add(i.ToString(), i.ToString());
                data.Columns[i].Width = width;
            }

            data.Rows.Add(n);

            for (int i = 0; i < n; i++) {
                for (int j = 0; j < n; j++) {
                    if (i / 3 != 1) {
                        if (j / 3 == 1)
                            data[j, i].Style.BackColor = Color.White;
                        else
                            data[j, i].Style.BackColor = Color.WhiteSmoke;
                    } else {
                        if (j / 3 == 1)
                            data[j, i].Style.BackColor = Color.WhiteSmoke;
                        else
                            data[j, i].Style.BackColor = Color.White;
                    }

                    data[j, i].Style.Font = new Font("Arial", 12);
                    data[j, i].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    data[j, i].Style.SelectionBackColor = Color.Silver;
                }
            }

            data.RowHeadersVisible = false; //скрыть заголовки строк
            data.ColumnHeadersVisible = false; //скрыть заголовки столбцов
        }    
        
        void Reset() {
            InitGrid(DataField);
            InitGrid(DataSolvation);
            Clearbtn.Visible = false;
            backbtn.Visible = false;
            forwardbtn.Visible = false;
        }

        private void Solve_Click(object sender, EventArgs e) {
            SolutionList.Clear();
            backbtn.Visible = false;
            forwardbtn.Visible = false;
            Field a = new Field();
            a.read(DataField);

            SolutionList = a.Solve(DataSolvation);
            if (SolutionList.Count == 0) {
                MessageBox.Show("Нет решений!");
                return;
            }

            printMatrix(SolutionList[0].matrix, DataSolvation);
            Clearbtn.Visible = true;

            if (SolutionList.Count > 1) {
                backbtn.Visible = true;
                forwardbtn.Visible = true;
                backbtn.Enabled = false;
                forwardbtn.Enabled = true;
                ListIndex = 0;
            }        
        }

        private void forwardbtn_Click(object sender, EventArgs e) {
            ListIndex++;
            backbtn.Enabled = true;
            if (ListIndex == SolutionList.Count - 1)
                forwardbtn.Enabled = false;
            printMatrix(SolutionList[ListIndex].matrix, DataSolvation);
        }

        private void backbtn_Click(object sender, EventArgs e) {
            ListIndex--;
            forwardbtn.Enabled = true;
            if (ListIndex == 0)
                backbtn.Enabled = false;
            printMatrix(SolutionList[ListIndex].matrix, DataSolvation);
        }

        private void Clearbtn_Click(object sender, EventArgs e) {
            Reset();
        }

        private void InsertFromFileItem_Click(object sender, EventArgs e) {
            OpenFileDialog dialog = new OpenFileDialog();

            dialog.Filter = "txt files (*.txt)|*.txt";
            dialog.RestoreDirectory = true;

            if (dialog.ShowDialog() != DialogResult.OK) {
                return;
            }

            InitGrid(DataField);
            InitGrid(DataSolvation);

            string[] lines = File.ReadAllLines(dialog.FileName);

            if (lines.Length < n) {
                MessageBox.Show("Некорректный файл");
                return;
            }

            for (int i = 0; i < n; i++) {
                string[] line = lines[i].Split(' ');
                for (int j = 0; j < n; j++) {
                    if (!char.IsDigit(line[j][0])) {
                        MessageBox.Show("Некорректный файл");
                        return;
                    }
                    if (line[j] != "0") {
                        DataField[j, i].Value = line[j];
                        DataField[j, i].Style.Font = new Font("Arial", 12, FontStyle.Bold);
                    }
                }
            }
        }

        bool IsEmpty(DataGridView data) {
            for (int j = 0; j < n; j++)
                for (int i = 0; i < n; i++) 
                    if (data[j, i].Value != null)
                        if (data[j, i].Value.ToString() != "")
                            return false;
            return true;
        }

        private void DataField_CellValueChanged(object sender, DataGridViewCellEventArgs e) {
            Clearbtn.Visible = !IsEmpty(DataField) || !IsEmpty(DataSolvation);
        }
    }
}


