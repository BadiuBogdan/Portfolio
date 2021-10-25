using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LabirintJocuri
{
    class Rezolvare
    {
        private Panel[,] viewLabyrinth;
        private Point start;
        private Point final;
        private int[] veciniRand = { -1, 0, 0, 1 };
        private int[] veciniColoana = { 0, -1, 1, 0 };

        private int nrRows;
        private int nrCols;
        private List<PunctLabirint> solutie;

        public Rezolvare(ref Panel[,] view)
        {
            this.viewLabyrinth = view;
            solutie = new List<PunctLabirint>();
        }
        private bool EsteVizitat(Point p, int[,] matrix)
        {
            int i = p.X;
            int j = p.Y;
            if (matrix[i, j] == 1)
            {
                return false;
            }
            return true;

        }
        private bool isInMatrix(int rand, int coloana)
        {
            return (rand >= 0) && (rand < nrRows) && (coloana >= 0) && (coloana < nrCols);
        }
        public void RezolvareLabirint_BFS(Labirint lab, Point str, Point end)
        {
            nrRows = lab.Rows;
            nrCols = lab.Cols;

            start = str;
            final = end;

            if ((start.X == 0 && start.Y == 0) || (final.X == 0 && final.Y == 0))
            {
                MessageBox.Show("Nu ai ales punctele de start si de final!!!!");
            }
            else
            {

                Queue<Point> coada = new Queue<Point>();

                Label eticheta1 = new Label();

                lab.Matrix[start.X, start.Y] = 2;
                eticheta1.Text = "S";
                viewLabyrinth[start.X, start.Y].BackColor = Color.LightSkyBlue;
                viewLabyrinth[start.X, start.Y].Controls.Add(eticheta1);


                coada.Enqueue(start);

                while (coada.Count > 0)
                {
                    Point pt = coada.Dequeue();


                    for (var i = 0; i < 4; i++)
                    {
                        int rand = pt.X + veciniRand[i];
                        int col = pt.Y + veciniColoana[i];

                        if (pt.X == final.X && pt.Y == final.Y)
                        {
                            viewLabyrinth[pt.X, pt.Y].BackColor = Color.LightSkyBlue;
                            coada.Clear();
                            break;
                        }
                        if (isInMatrix(rand, col) && !EsteVizitat(new Point(rand, col), lab.Matrix) && lab.Matrix[rand, col] != 0)
                        {
                            Label eticheta = new Label();
                            lab.Matrix[rand, col] = lab.Matrix[pt.X, pt.Y] + 1;
                            if ((rand == final.X) && (col == final.Y))
                            {
                                eticheta.Text = "E";
                            }

                            else
                            {
                                eticheta.Text = lab.Matrix[rand, col].ToString();
                            }

                            viewLabyrinth[rand, col].BackColor = Color.Orange;
                            viewLabyrinth[rand, col].Controls.Add(eticheta);
                            coada.Enqueue(new Point(rand, col));
                        }
                    }
                }

                solutie.Add(new PunctLabirint(final, lab.Matrix[final.X, final.Y]));
                int valIndex = 0;
                int valStop = lab.Matrix[final.X, final.Y];
                while (valStop > 2)
                {
                    for (var i = (lab.Rows - 1); i >= 0; i--)
                    {
                        for (var j = (lab.Cols - 1); j >= 0; j--) 
                        {

                            if ((lab.Matrix[i, j] == (solutie[valIndex].Value - 1)) && !isInList(solutie, lab.Matrix[i, j]) && isNeighbor(solutie[valIndex], i, j))
                            {
                                solutie.Add(new PunctLabirint(new Point(i, j), lab.Matrix[i, j]));
                                valStop = lab.Matrix[i, j];
                                valIndex++;
                            }
                        }
                    }
                }
            }
        }

        public void RezolvareLabirint_DFS(Labirint lab, Point str, Point end)
        {
            nrRows = lab.Rows;
            nrCols = lab.Cols;
            start = str;
            final = end;

            if ((start.X == 0 && start.Y == 0) || (final.X == 0 && final.Y == 0))
            {
                MessageBox.Show("Nu ai ales punctele de start si de final!!!!");
            }
            else
            {

                Stack<Point> stack = new Stack<Point>();

                Label eticheta1 = new Label();

                lab.Matrix[start.X, start.Y] = 2;
                eticheta1.Text = "S";
                viewLabyrinth[start.X, start.Y].BackColor = Color.LightSkyBlue;
                viewLabyrinth[start.X, start.Y].Controls.Add(eticheta1);


                stack.Push(start);

                while (stack.Count > 0)
                {
                    Point pt = stack.Pop();

                    if (pt.X == final.X && pt.Y == final.Y)
                    {
                        viewLabyrinth[pt.X, pt.Y].BackColor = Color.LightSkyBlue;
                        stack.Clear();
                        break;
                    }

                    for (var i = 0; i < 4; i++)
                    {
                        int rand = pt.X + veciniRand[i];
                        int col = pt.Y + veciniColoana[i];

                        if (isInMatrix(rand, col) && !EsteVizitat(new Point(rand, col), lab.Matrix) && lab.Matrix[rand, col] != 0)
                        {
                            Label eticheta = new Label();
                            lab.Matrix[rand, col] = lab.Matrix[pt.X, pt.Y] + 1;
                            if ((rand == final.X) && (col == final.Y))
                            {
                                eticheta.Text = "E";
                            }

                            else
                            {
                                eticheta.Text = lab.Matrix[rand, col].ToString();
                            }

                            viewLabyrinth[rand, col].BackColor = Color.Orange;
                            viewLabyrinth[rand, col].Controls.Add(eticheta);
                            stack.Push(new Point(rand, col));
                        }
                    }
                }

                solutie.Add(new PunctLabirint(final, lab.Matrix[final.X, final.Y]));
                int valIndex = 0;
                int valStop = lab.Matrix[final.X, final.Y];
                while (valStop > 2)
                {
                    for (var i = (lab.Rows - 1); i >= 0; i--)
                    {
                        for (var j = (lab.Cols - 1); j >= 0; j--)
                        {

                            if ((lab.Matrix[i, j] == (solutie[valIndex].Value - 1)) && !isInList(solutie, lab.Matrix[i, j]) && isNeighbor(solutie[valIndex], i, j))
                            {
                                solutie.Add(new PunctLabirint(new Point(i, j), lab.Matrix[i, j]));
                                valStop = lab.Matrix[i, j];
                                valIndex++;
                            }
                        }
                    }
                }
            }
        }

        private bool isInList(List<PunctLabirint> list, int val)
        {
            foreach (var i in list)
            {
                if (i.Value == val)
                {
                    return true;
                }
            }
            return false;
        }
        private bool isNeighbor(PunctLabirint p, int i, int j)
        {
            if (((i == p.Point.X - 1) && (j == p.Point.Y)) || ((i == p.Point.X + 1) && (j == p.Point.Y)) ||
               ((i == p.Point.X) && (j == p.Point.Y + 1)) || ((i == p.Point.X) && (j == p.Point.Y - 1)))
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        private Color GetColorsByValue(int value)
        {
            switch (value)
            {
                case 0: return Color.Black;
                case 1: return Color.White;
                default:
                    return Color.Lime;

            }
        }
        public void AfiseazaLabirintul(Labirint labirint, ref Panel principal)
        {
            for (int i = 0; i < labirint.Rows; i++)
            {
                for (int j = 0; j < labirint.Cols; j++)
                {
                    viewLabyrinth[i, j] = new Panel();
                    viewLabyrinth[i, j].BackColor = GetColorsByValue(labirint.Matrix[i, j]);
                    viewLabyrinth[i, j].Height = 20;
                    viewLabyrinth[i, j].Width = 20;
                    viewLabyrinth[i, j].Top = 100 + i * 22;
                    viewLabyrinth[i, j].Left = 10 + j * 22;

                    principal.Controls.Add(viewLabyrinth[i, j]);
                }

            }
        }

        public void Solutie(Labirint lab)
        {
            if (solutie.Count == 0)
            {
                MessageBox.Show("Nu ai rezolvat lairintul", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            foreach (var i in solutie)
            {
                if ((i.Value > lab.Matrix[start.X, start.Y]) && (i.Value < lab.Matrix[final.X, final.Y]))
                {
                    viewLabyrinth[i.Point.X, i.Point.Y].BackColor = Color.Lime;
                }
            }
        }
    }
}
