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
    public partial class Game : Form {
        const int n0 = 3;
        const int n = n0 * n0;
        const int cellSize = 40;
        const int easydiff = 40;
        const int mediumdiff = 35;
        const int diffdiff = 30;
        const int evildiff = 25;

        int diff = mediumdiff;

        Color selectUnchangedCell = Color.FromArgb(195, 230, 226);
        Color selectChangedCell = Color.FromArgb(123, 200, 194);
        Color selectDigitCell = Color.FromArgb(210, 214, 239);
        Color backColor1 = Color.White;
        Color backColor2 = Color.WhiteSmoke;

        long time;
        Timer timer = new Timer();

        Timer timerToCorrectItem = new Timer();
        StartForm startForm = null;

        public Game(StartForm startForm) {
            InitializeComponent();
            InitGrid(GameField);

            this.startForm = startForm;

            timerToCorrectItem.Interval = 60 * 1000;
            timerToCorrectItem.Tick += TimerToCorrectItem_Tick;

            timer.Interval = 1000;
            timer.Tick += sudokuTime;
            timer.Start();
            time = 0;
            label1.Text = "";
            printMatrix((new Field()).Generate(diff).matrix, GameField, true);
        }

        private void TimerToCorrectItem_Tick(object sender, EventArgs e) {
            timerToCorrectItem.Stop();
            IsCorrectItem.Enabled = true;
        }

        private void InitGrid(DataGridView data) {
            for (int i = 0; i < n; i++) {
                data.Columns.Add(new DataGridViewColumn(new DataGridViewTextBoxCell()));
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

        void printMatrix(int[,,] mat, DataGridView data, bool readOnly = false) {
            for (int i = 0; i < n; i++) {
                for (int j = 0; j < n; j++) {
                    if (mat[i, j, 0] != 0) {
                        data[j, i].Value = mat[i, j, 0];
                        data[j, i].ReadOnly = readOnly;
                        if (readOnly)
                            data[j, i].Style.Font = new Font("Arial", 12, FontStyle.Bold);
                    } else {
                        data[j, i].Value = "";
                        data[j, i].ReadOnly = false;
                    }
                }
            }

            data.Update();
        }

        private void sudokuTime(object sender, EventArgs e) {
            time++;
            long hours = time / 3600;
            long minuts = (time % 3600) / 60;
            long secunds = time % 60;

            label1.Text = hours.ToString("00") + ":" + minuts.ToString("00") + ":" + secunds.ToString("00");
        }
        
        private void GameField_CellClick(object sender, DataGridViewCellEventArgs e) {
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
            } else {
                grid.CurrentCell = grid[e.ColumnIndex, e.RowIndex];
                grid.BeginEdit(true);
            }

            grid[e.ColumnIndex, e.RowIndex].Style.SelectionBackColor = selectChangedCell;
        }

        private void ClearToCorrect_Click(object sender, EventArgs e) {
            for (int i = 0; i < n; i++) {
                for (int j = 0; j < n; j++) {
                    GameField.EndEdit();
                    if (!GameField[j, i].ReadOnly)
                        GameField[j, i].Value = "";
                }
            }
        }

        private void Game_FormClosing(object sender, FormClosingEventArgs e) {
            startForm.Show();
        }

        void NewGame(int diff) { 
            DialogResult result = MessageBox.Show("Решить новую судоку? ", "Новая игра", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes) {
                timerToCorrectItem.Stop();
                IsCorrectItem.Enabled = true;
                
                Field field = new Field().Generate(diff);
                printMatrix(field.matrix, GameField, true);
                timer.Start();
                time = 0;
            }
        }
        
        private void EasyMod_Click_1(object sender, EventArgs e) {
            diff = easydiff;
            NewGame(diff);
        }

        private void MediumMod_Click(object sender, EventArgs e) {
            diff = mediumdiff;
            NewGame(diff);
        }

        private void DiffMod_Click(object sender, EventArgs e) {
            diff = diffdiff;
            NewGame(diff);
        }

        private void EvilMod_Click(object sender, EventArgs e) {
            diff = evildiff;
            NewGame(diff);
        }


        private void KeyPress(object sender, KeyPressEventArgs e) {
            TextBox tb = (TextBox)sender;
            if (char.IsControl(e.KeyChar)) return;
            if (e.KeyChar < '1' || e.KeyChar > '9' || tb.Text.Length > 0) {
                e.Handled = true;
            }
        }

        private void GameField_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e) {
            e.Control.KeyPress -= new KeyPressEventHandler(KeyPress);
            TextBox tb = e.Control as TextBox;
            if (tb != null) {
                tb.KeyPress += new KeyPressEventHandler(KeyPress);
                
            }
        }
        
        private void GameField_CellValueChanged(object sender, DataGridViewCellEventArgs e) {
            Field a = new Field();
            a.read(GameField);

            if (a.AllFill()) {
                if (a.IsCorrect()) {
                    DialogResult result = MessageBox.Show("Ураааа! Ты победил!", "Победа");
                    NewGame(diff);
                } else {
                    MessageBox.Show("Упс...Что-то пошло не так");
                }
            }
        }

        private void IsCorrectItem_Click(object sender, EventArgs e) {
            IsCorrectItem.Enabled = false;
            timerToCorrectItem.Start();

            Field field = new Field();
            field.read(GameField);

            MessageBox.Show((field.IsCorrect()) ? "Проверка на корректность успешно пройдена" : "Не пройдена проверка на корректность. Проверьте своё поле!", "Корректно?");
        }

        private void BackToMenu_Click(object sender, EventArgs e) {
            if (MessageBox.Show("Вы уверены, что хотите выйти в меню?", "Требуется подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes) {
                Close();
            }
        }

        private void ExitItem_Click(object sender, EventArgs e) {
            if (MessageBox.Show("Вы уверены, что хотите выйти?", "Требуется подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes) {
                startForm.Close();
            }
        }
    }
}
