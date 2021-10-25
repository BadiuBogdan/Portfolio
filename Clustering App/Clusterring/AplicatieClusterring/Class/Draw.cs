using System;
using System.Drawing;
using System.Windows.Forms;

namespace AplicatieClusterring
{
    class Draw
    {
        public void DrawAxis(Panel panel)
        {
            SolidBrush colorBlack = new SolidBrush(Color.Black);
            Pen penBlack = new Pen(Color.Black);
            Font font = new Font("Arial", 10);
            Graphics gAxis = panel.CreateGraphics();

            //deseneaza numele axei X sau Y
            gAxis.DrawString("-x", font, colorBlack, 0, (panel.Height / 2 - 20));
            gAxis.DrawString("x", font, colorBlack, (panel.Width - 20), (panel.Height / 2 - 20));
            gAxis.DrawString("y", font, colorBlack, (panel.Width / 2 - 20), 0);
            gAxis.DrawString("-y", font, colorBlack, (panel.Width / 2 - 20), (panel.Height - 20));

            //deseneaza intervalul [-200, +200]
            gAxis.DrawString("-200", font, colorBlack, 0, (panel.Height / 2 + 10));
            gAxis.DrawString("200", font, colorBlack, (panel.Width - 25), (panel.Height / 2 + 10));
            gAxis.DrawString("200", font, colorBlack, (panel.Width / 2 + 10), 20);
            gAxis.DrawString("-200", font, colorBlack, (panel.Width / 2 + 10), (panel.Height - 25));

            //deseneaza axele
            gAxis.DrawLine(penBlack, new Point(0, panel.Height / 2), new Point(panel.Width, panel.Height / 2));
            gAxis.DrawLine(penBlack, new Point(panel.Width / 2, 0), new Point(panel.Width / 2, panel.Height));

            //deseneaza linile care reprezinta limitele pe X
            gAxis.DrawLine(penBlack, new Point(panel.Width / 2 + 200, (panel.Height / 2 + 5)), new Point(panel.Width / 2 + 200, (panel.Height / 2 - 5)));//[min,max] pe axa X
            gAxis.DrawLine(penBlack, new Point(panel.Width / 2 - 200, (panel.Height / 2 + 5)), new Point(panel.Width / 2 - 200, (panel.Height / 2 - 5)));

            //deseneaza linile care reprezinta limitele pe Y
            gAxis.DrawLine(penBlack, new Point((panel.Width / 2 + 5), panel.Height / 2 + 200), new Point((panel.Width / 2 - 5), panel.Height / 2 + 200));//[min,max] pe axa Y
            gAxis.DrawLine(penBlack, new Point((panel.Width / 2 + 5), panel.Height / 2 - 200), new Point((panel.Width / 2 - 5), panel.Height / 2 - 200));

        }
        public void DrawPoint(int X, int Y, Panel panel, int color)
        {
            string[] colors = new string[] {"Black", "Gold", "Indigo", "Blue", "Green", "Cyan",
                                            "Brown", "Orange", "Violet", "LightCoral", "SandyBrown", "Plum",
                                            "DarkGoldenrod", "MediumAquamarine", "NavajoWhite","Red"};

            //deseneaza un singur punct
            if (color > 15) color = 15;
            SolidBrush colorBlack = new SolidBrush(Color.FromName(colors[color]));
            Graphics gPoint = panel.CreateGraphics();
            gPoint.FillEllipse(colorBlack, (panel.Width / 2 + X), (panel.Height / 2 + (-Y)), 3, 3);
        }
        public void DrawPoints(Int16[,] matrix, Panel panel,int color)
        {

            int numberOfLines = matrix.GetLength(0); //aceasta linie de cod intoarce numarul de linii din matrice

            //se deseneaza toate punctele din lista points pe care am citito in Read2DFile
            for (var i = 0; i < numberOfLines; i++)
            {
                DrawPoint(matrix[i, 0], matrix[i, 1], panel, color);
            }
        }

        public void DrawPointsColor(Int16[,] matrix,int pointId, Panel panel, int color)
        {
            DrawPoint(matrix[pointId, 0], matrix[pointId, 1], panel, color);
        }
    }
}
