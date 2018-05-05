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
        const int n0 = 3;
        const int n = n0 * n0;
        const int cellSize = 40;

        Color selectUnchangedCell = Color.FromArgb(195, 230, 226);
        Color selectChangedCell = Color.FromArgb(123, 200, 194);
        Color selectDigitCell = Color.FromArgb(210, 214, 239);
        Color backColor1 = Color.White;
        Color backColor2 = Color.WhiteSmoke;


        List<Field> SolutionList = new List<Field>();
        int ListIndex = 0;

        StartForm startForm;

        void printMatrix(int[,,] mat, DataGridView data, bool readOnly = false) {
            InitGrid(DataSolvation);
            for (int i = 0; i < n; i++) {
                for (int j = 0; j < n; j++) {
                    if (mat[i, j, 0] != 0) {
                        data[j, i].Value = mat[i, j, 0];
                        data[j, i].ReadOnly = readOnly;
                        if (readOnly)
                            data[j, i].Style.Font = new Font("Arial", 12, FontStyle.Bold);
                    }
                }
            }

            data.Update();
        }

        public Form1(StartForm startForm) {
            InitializeComponent();
            InitGrid(DataField);
            InitGrid(DataSolvation);
            backbtn.Visible = false;
            forwardbtn.Visible = false;
            Clearbtn.Visible = false;

            this.startForm = startForm;
            DataField.CellClick += cellClick;
            DataSolvation.CellClick += cellClick;
        }


        private void cellClick(object sender, DataGridViewCellEventArgs e) {
            DataGridView grid = (DataGridView)sender;
            grid.ClearSelection();

            string value = "";

            if (grid[e.ColumnIndex, e.RowIndex].Value != null)
                value = grid[e.ColumnIndex, e.RowIndex].Value.ToString();

            for (int j = 0; j < n; j++) {
                grid[j, e.RowIndex].Selected = true;
                grid[j, e.RowIndex].Style.SelectionBackColor = selectUnchangedCell;
            }
            for (int i = 0; i < n; i++) {
                grid[e.ColumnIndex, i].Selected = true;
                grid[e.ColumnIndex, i].Style.SelectionBackColor = selectUnchangedCell;
            }

            if (value != "") {
                for (int j = 0; j < n; j++) {
                    for (int i = 0; i < n; i++) {
                        if (grid[j, i].Value == null)
                            continue;

                        if (grid[j, i].Value.ToString() == value) {
                            grid[j, i].Selected = true;
                            grid[j, i].Style.SelectionBackColor = selectDigitCell;
                        }
                    }
                }
            }
            else {
                grid.CurrentCell = grid[e.ColumnIndex, e.RowIndex];
                grid.BeginEdit(true);
            }
            
            grid[e.ColumnIndex, e.RowIndex].Style.SelectionBackColor = selectChangedCell;
        }

        private void InitGrid(DataGridView data) {
            data.Rows.Clear();
            data.Columns.Clear();

            for (int i = 0; i < n; i++) {
                data.Columns.Add(i.ToString(), i.ToString());
                data.Columns[i].Width = cellSize;
                data.RowTemplate.Height = cellSize;
            }

            data.Rows.Add(n);

            for (int i = 0; i < n; i++) {
                for (int j = 0; j < n; j++) {
                    if (i / n0 != 1) {
                        if (j / n0 == 1)
                            data[j, i].Style.BackColor = backColor1;
                        else
                            data[j, i].Style.BackColor = backColor2;
                    } else {
                        if (j / n0 == 1)
                            data[j, i].Style.BackColor = backColor2;
                        else
                            data[j, i].Style.BackColor = backColor1;
                    }

                    data[j, i].Style.SelectionForeColor = Color.Black;
                    data[j, i].Style.Font = new Font("Arial", 12);
                    data[j, i].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    data[j, i].Style.SelectionBackColor = selectChangedCell;
                }
            }

            data.RowHeadersVisible = false; //скрыть заголовки строк
            data.ColumnHeadersVisible = false; //скрыть заголовки столбцов
            data.ClearSelection();

        }

        private void ClearDataGrid(DataGridView data) {
            for (int i = 0; i < n; i++) 
                for (int j = 0; j < n; j++) {
                    data[j, i].Value = "";
                }
        }

        void Reset() {
            ClearDataGrid(DataField);
            ClearDataGrid(DataSolvation);
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

            SolutionList = a.Solve();
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

            Reset();

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

        private void GenerateItem_Click(object sender, EventArgs e) {
            Reset();
            Field field = new Field().Generate();
            printMatrix(field.matrix, DataField, true);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e) {
            startForm.Show();

        }

        private void BackToMenu_Click(object sender, EventArgs e) {
            if (MessageBox.Show("Вы уверены, что хотите выйти в меню?", "Требуется подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes) {
                Close();
            }
        }

        private void Exit_Click(object sender, EventArgs e) {
            if (MessageBox.Show("Вы уверены, что хотите выйти?", "Требуется подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes) {
                startForm.Close();
            }
        }
    }
}


