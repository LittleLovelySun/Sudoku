using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sudoku {
    class Field {
        public int[,,] matrix;
        const int n0 = 3;
        const int n = n0 * n0;

        public Field() {
            matrix = new int[n, n, n + 1];
            for (int i = 0; i < n; i++) {
                for (int j = 0; j < n; j++) {
                    for (int k = 0; k < n + 1; k++)
                        matrix[i, j, k] = 0;
                }
            }
        }

        public int this[int i, int j, int k] {
            get {
                return matrix[i, j, k];
            }
            set {
                matrix[i, j, k] = value;
                Clear(i, j, value);
            }
        }

        public void Clear(int i, int j, int s) {
            for (int k = 0; k < n; k++)
                if (isEmpty(k, j))
                    matrix[k, j, s] = s;

            for (int k = 0; k < n; k++)
                if (isEmpty(i, k))
                    matrix[i, k, s] = s;

            for (int k = i / n0 * n0; k < i / n0 * n0 + n0; k++)
                for (int l = j / n0 * n0; l < j / n0 * n0 + n0; l++)
                    if (isEmpty(k, l))
                        matrix[k, l, s] = s;
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
                    } else
                        this[i, j, 0] = int.Parse(data[j, i].Value.ToString());
                }
            }
        }

        public void read(Field field) {
            matrix = new int[n, n, n + 1];
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++) {
                    if (!field.isEmpty(i, j))
                        this[i, j, 0] = field[i, j, 0];

                }
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
                this[i, j, 0] = icount;
            }

            return count;
        }

        public void Copy(Field field) {
            matrix = new int[n, n, n + 1];

            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    for (int k = 0; k < n + 1; k++)
                        matrix[i, j, k] = field[i, j, k];
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

            for (int i0 = 0; i0 < n0; i0++)
                for (int j0 = 0; j0 < n0; j0++)
                    for (int i = 0; i < n; i++)
                        for (int j = i + 1; j < n; j++) {
                            int v1 = matrix[i0 * n0 + i / n0, j0 * n0 + i % n0, 0];
                            int v2 = matrix[i0 * n0 + j / n0, j0 * n0 + j % n0, 0];
                            if (v1 == v2 && v1 != 0)
                                return false;
                        }
            return true;
        }

        public bool Fill(ref Field field, List<Field> list, int solutionCount = 10, int deep = 0) {
            if (list.Count > solutionCount)
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
                        if (field[indexi, indexj, k] == 0) {
                            Field copy = new Field();
                            copy.Copy(field);

                            field[indexi, indexj, 0] = k;

                            Fill(ref field, list, solutionCount);
                            field = copy;
                        }
                    }

                    return list.Count > 0;
                }
            }
            list.Add(field);
            return true;
        }

        public List<Field> Solve(int solutionCount = 10) {
            List<Field> list = new List<Field>();
            Field copy = new Field();
            copy.Copy(this);
            Fill(ref copy, list, solutionCount);
            return list;
        }

        public Field Generate() {
            Field field = new Field();
            Random rnd = new Random();

            for (int s = 1; s < n + 1; s++) {
                int i, j;
                do {
                    i = rnd.Next(n);
                    j = rnd.Next(n);
                } while (!field.isEmpty(i, j));

                field[i, j, 0] = s;
            }
            
            List<Field> list = field.Solve(100);

            field = list[rnd.Next(list.Count)];

            Field copy = new Field();
            Field result = new Field();

            int index = n * n;

            do {
                result.read(field);
                int i, j, s;
                do {
                    i = rnd.Next(n);
                    j = rnd.Next(n);
                } while (field.isEmpty(i, j));

                s = field[i, j, 0];
                field[i, j, 0] = 0;
                copy.read(field);
                index--;
            } while (copy.Solve().Count() == 1 && index > n);
            
            return result;
           // return new Field[2] { field, list.Count == 0 ? null : list[rnd.Next(list.Count)] };
        }
    }
}