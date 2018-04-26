using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
    
namespace Sudoku {
    class Field {
        public int[,,] matrix;
        const int n = 9;

        void printMatrix(int[,,] mat, DataGridView data) {
            for (int i = 0; i < n; i++) {
                for (int j = 0; j < n; j++) {
                    if (mat[i, j, 0] != 0)
                        data[j, i].Value = mat[i, j, 0];
                }
            }
        }

        public Field() {
            matrix = new int[n, n, n + 1];
            for (int i = 0; i < n; i++) {
                for (int j = 0; j < n; j++) {
                    for (int k = 0; k < n + 1; k++)
                        matrix[i, j, k] = 0;
                }
            }
        }

        public bool AllFill() {
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    if (isEmpty(i, j))
                        return false;
            return true;
        }

        public void read(DataGridView data) {
            for (int i = 0; i < n; i++) {
                for (int j = 0; j < n; j++) {
                    if (data[j, i].Value == null) {
                        matrix[i, j, 0] = 0;
                    } else if (data[j, i].Value.ToString() == "") {
                        matrix[i, j, 0] = 0;
                    } else {
                        int res = int.Parse(data[j, i].Value.ToString());
                        matrix[i, j, 0] = res;
                        Clear(i, j, res);
                    }
                }
            }
        }

        public void Clear(int i, int j, int s) {
            for (int k = 0; k < n; k++)
                if (isEmpty(k, j))
                    matrix[k, j, s] = s;
            for (int k = 0; k < n; k++)
                if (isEmpty(i, k))
                    matrix[i, k, s] = s;
            for (int k = i / 3 * 3; k < i / 3 * 3 + 3; k++)
                for (int l = j / 3 * 3; l < j / 3 * 3 + 3; l++)
                    if (isEmpty(k, l))
                        matrix[k, l, s] = s;
        }

        public bool isEmpty(int i, int j) {
            return matrix[i, j, 0] == 0;
        }

        public int FillCell(int i, int j) {
            int count = 0;
            int icount = 0;
            for (int k = 1; k < n + 1; k++) {
                if (matrix[i, j, k] == 0) {
                    count++;
                    icount = k;
                }
            }
            if (count == 1) {
                matrix[i, j, 0] = icount;
                Clear(i, j, icount);
            }

            return count;
        }

        public void Copy(Field Fieald) {
            matrix = new int[n, n, n + 1];

            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    for (int k = 0; k < n + 1; k++)
                        matrix[i, j, k] = Fieald.matrix[i, j, k];

        }

        public bool IsCorrect() {
            for (int i = 0; i < n; i++) {
                for (int j = 0; j < n - 1; j++) {
                    for (int k = j + 1; k < n; k++)
                        if (matrix[i, j, 0] == matrix[i, k, 0] && matrix[i, j, 0] != 0)
                            return false;
                    for (int k = i + 1; k < n; k++)
                        if (matrix[i, j, 0] == matrix[k, j, 0] && matrix[i, j, 0] != 0)
                            return false;
                }
            }

            for (int i0 = 0; i0 < 3; i0++)
                for (int j0 = 0; j0 < 3; j0++)
                    for (int i = 0; i < n; i++)
                        for (int j = i + 1; j < n; j++) {
                            int v1 = matrix[i0 * 3 + i / 3, j0 * 3 + i % 3, 0];
                            int v2 = matrix[i0 * 3 + j / 3, j0 * 3 + j % 3, 0];
                            if (v1 == v2 && v1 != 0)
                                return false;
                        }
            return true;
        }

        public bool Fill(DataGridView data, ref Field field, List<Field> list, int deep = 0) {
            if (list.Count > 10)
                return false;
            if (!field.IsCorrect())
                return false;

            while (!field.AllFill()) {
                int count = 10;
                int indexi = 0;
                int indexj = 0;

                for (int i = 0; i < n; i++) {
                    for (int j = 0; j < n; j++) {
                        if (field.isEmpty(i, j)) {
                            int res = field.FillCell(i, j);
                            if (res < count) {
                                count = res;
                                indexi = i;
                                indexj = j;
                            }
                            if (res == 0)
                                return false;
                        }
                    }
                }

                if (count > 1) {
                    for (int k = 1; k < n + 1; k++) {
                        if (field.matrix[indexi, indexj, k] == 0) {
                            Field copy = new Field();
                            copy.Copy(field);

                            field.matrix[indexi, indexj, 0] = k;
                            field.Clear(indexi, indexj, k);

                            Fill(data, ref field, list);
                            field = copy;
                        }
                    }
                    if (list.Count > 0)
                        return true;
                    return false;
                }
            }
            list.Add(field);
            return true;
        }

        public List<Field> Solve(DataGridView data) {
            List<Field> list = new List<Field>();
            Field copy = new Field();
            copy.Copy(this);
            if (Fill(data, ref copy, list))
                return list;
            else {
                return null;
            }
        }
    }
}
