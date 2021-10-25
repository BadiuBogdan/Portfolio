using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlgPredictiv
{
    public partial class formHistogram : Form
    {
        private int[] histogram;
        private double histogramScale;
        public formHistogram(int[] histogram, double histogramScale)
        {
            this.histogramScale = histogramScale;
            this.histogram = histogram;
            InitializeComponent();
        }
        public formHistogram()
        {
            InitializeComponent();
        }
        private void formHistogram_Shown(object sender, EventArgs e)
        {
            SolidBrush colorBlack = new SolidBrush(Color.Black);
            Pen penBlack = new Pen(Color.Black);

            Graphics gAxis = panel.CreateGraphics();

            Font font = new Font("Arial", 10);
            StringFormat drawFormat = new StringFormat();
            drawFormat.FormatFlags = StringFormatFlags.DirectionVertical;

            for(var i=0;i<histogram.Length;i++)
            {
                gAxis.DrawLine(penBlack, new Point(i+30, panel.Height - 20), new Point(i + 30, (panel.Height - 20)-Convert.ToInt32((histogram[i]*histogramScale))));
            }


            gAxis.DrawLine(penBlack, new Point(20, panel.Height - 20), new Point(panel.Width - 20, panel.Height - 20));
            gAxis.DrawLine(penBlack, new Point(20, 0), new Point(20, panel.Height - 20));


            gAxis.DrawString("256", font, colorBlack, panel.Width - 30, panel.Height - 20);
            gAxis.DrawString("-256", font, colorBlack, 20, panel.Height - 20);
            gAxis.DrawString("Intensity", font, colorBlack, (panel.Width / 2), panel.Height - 20);

            GraphicsState state = gAxis.Save();
            gAxis.ResetTransform();
            gAxis.RotateTransform(-90);
            gAxis.TranslateTransform(0, (panel.Height / 2), MatrixOrder.Append);
            gAxis.DrawString("Frequancy ( # of pixels)", font, colorBlack, 0, 0);
            gAxis.Restore(state);
        }
    }
}
