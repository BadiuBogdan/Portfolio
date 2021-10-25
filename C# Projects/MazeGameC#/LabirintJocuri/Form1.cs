using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace LabirintJocuri
{
    public partial class Form1 : Form
    {
        private int contor; //pentru a apasa doar de 2 ori pe el ca sa alegem start si end
        private Labirint labirint;
        private Panel[,] viewLabyrinth;
        private Rezolvare rez;
        private Point start;
        private Point final;

        public Form1()
        {
            InitializeComponent();
            labirint = new Labirint();
            viewLabyrinth = new Panel[100, 100];
            rez = new Rezolvare(ref viewLabyrinth);
            contor = 0;
        }

        private void btnLoadMatrix_Click(object sender, EventArgs e)
        {

            labirint = LabirintData.Get();
            rez.AfiseazaLabirintul(labirint,ref pPrincipal);

            for (int i = 0; i < labirint.Rows; i++)
            {
                for (int j = 0; j < labirint.Cols; j++)
                {
                    viewLabyrinth[i, j].MouseClick += new System.Windows.Forms.MouseEventHandler(ClickOnPanel);
                }

            }
        }
        
      

        private void btnBFS_Click(object sender, EventArgs e)
        {
            rez.RezolvareLabirint_BFS(labirint,start,final);
        }

        private void btnSolutie_Click(object sender, EventArgs e)
        {
            rez.Solutie(labirint);
        }

        private void btnDFS_Click(object sender, EventArgs e)
        {
            rez.RezolvareLabirint_DFS(labirint,start,final);
        }


        //Eveniment de Click
        private void ClickOnPanel(object sender, MouseEventArgs e)
        {

            Panel pan = sender as Panel;
            if (contor == 0)
            {
                int x = (pan.Top - 100) / 22;
                int y = (pan.Left - 10) / 22;
                if (labirint.Matrix[x, y] == 0)
                {
                    MessageBox.Show("Acesta este zid");
                }
                else
                {
                    pan.BackColor = Color.LightBlue;
                    start.X = x;
                    start.Y = y;
                    contor++;
                }
            }
            else if (contor == 1)
            {
                int x = (pan.Top - 100) / 22;
                int y = (pan.Left - 10) / 22;
                if (labirint.Matrix[x, y] == 0)
                {
                    MessageBox.Show("Acesta este zid");
                }
                else
                {
                    pan.BackColor = Color.LightBlue;
                    final.X = x;
                    final.Y = y;
                    contor++;
                }
            }
            else
            {
                MessageBox.Show("Punctele de start si stop au fost alese");
            }

        }
    }
}
