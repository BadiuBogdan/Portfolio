using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AplicatieClusterring.Class;

namespace AplicatieClusterring
{
    public partial class FormRezultateMetrici : Form
    {
        private MetriciExterne metriciExterne;
        private List<String> zonas;
        private double procentDist;
        private double distMax;
        private string tipAlg;

        #region Afisare date DBSCAN + Constructor dedicat DBSCAN
        private int nrMinDocCluster;
        public FormRezultateMetrici( MetriciExterne metriciExterne,  List<string> zonas, ref double procentDist, ref double distMax, ref int nrMinDocCluster,ref string tipAlg)
        {
            
            this.metriciExterne = metriciExterne;
            this.zonas = zonas;
            this.procentDist = procentDist;
            this.distMax = distMax;
            this.nrMinDocCluster = nrMinDocCluster;
            this.tipAlg = tipAlg;

            InitializeComponent();
        }
        #endregion

        #region Afisare date HAC + Constructor dedicat HAC
        private string tipSimilarotate;
        public FormRezultateMetrici(MetriciExterne metriciExterne, List<string> zonas, ref double procentDist, ref double distMax, ref string tipSimilarotate, ref string tipAlg)
        {

            this.metriciExterne = metriciExterne;
            this.zonas = zonas;
            this.procentDist = procentDist;
            this.distMax = distMax;
            this.tipSimilarotate = tipSimilarotate;
            this.tipAlg = tipAlg;

            InitializeComponent();
        }
        #endregion
        public FormRezultateMetrici()
        {
            InitializeComponent();
        }

        private void FormRezultateMetrici_Shown(object sender, EventArgs e)
        {
            if (tipAlg == "DBSCAN")
            {
                lTipAlg.Text = "Algoritm " + tipAlg;
                List<List<double>> metriciPerClass = metriciExterne.MetriciPerClass;

                string[] row = new string[] { "Distanta Maxima", distMax.ToString() };
                dgRezMetrici.Rows.Add(row);

                row = new string[] { "Procenet distanta maxima", procentDist.ToString() };
                dgRezMetrici.Rows.Add(row);

                row = new string[] { "Distanta minima intre 2 puncte (D.Max*(Proc/100))", (distMax * (procentDist / 100.0)).ToString() };
                dgRezMetrici.Rows.Add(row);

                row = new string[] { "Nr minim de puncte din cluster", nrMinDocCluster.ToString() };
                dgRezMetrici.Rows.Add(row);

                row = new string[] { "" };
                dgRezMetrici.Rows.Add(row);

                row = new string[] { "" };
                dgRezMetrici.Rows.Add(row);

                row = new string[] { "", "Acuratete", "Precizie", "Recall" };
                dgRezMetrici.Rows.Add(row);

                for (int i = 0; i < metriciPerClass.Count; i++)
                {
                    row = new string[] { "Clasa: \" " + zonas[i] + " \"", metriciPerClass[i][0].ToString(), metriciPerClass[i][1].ToString(), metriciPerClass[i][2].ToString() };
                    dgRezMetrici.Rows.Add(row);
                }

                row = new string[] { "Media Aritmetica", metriciExterne.Accuracy.ToString(), metriciExterne.Precision.ToString(), metriciExterne.Recall.ToString() };
                dgRezMetrici.Rows.Add(row);
            }
            else
            {
                lTipAlg.Text = "Algoritm " + tipAlg;
                List<List<double>> metriciPerClass = metriciExterne.MetriciPerClass;

                string[] row = new string[] { "Distanta Maxima", distMax.ToString() };
                dgRezMetrici.Rows.Add(row);

                row = new string[] { "Procenet distanta maxima", procentDist.ToString() };
                dgRezMetrici.Rows.Add(row);

                row = new string[] { "Prag de oprire", (distMax * (procentDist / 100.0)).ToString() };
                dgRezMetrici.Rows.Add(row);

                row = new string[] { "Tip de similaritate", tipSimilarotate };
                dgRezMetrici.Rows.Add(row);
                row = new string[] { "" };
                dgRezMetrici.Rows.Add(row);

                row = new string[] { "" };
                dgRezMetrici.Rows.Add(row);

                row = new string[] { "", "Acuratete", "Precizie", "Recall" };
                dgRezMetrici.Rows.Add(row);

                for (int i = 0; i < metriciPerClass.Count; i++)
                {
                    row = new string[] { "Clasa: \" " + zonas[i] + " \"", metriciPerClass[i][0].ToString(), metriciPerClass[i][1].ToString(), metriciPerClass[i][2].ToString() };
                    dgRezMetrici.Rows.Add(row);
                }

                row = new string[] { "Media Aritmetica", metriciExterne.Accuracy.ToString(), metriciExterne.Precision.ToString(), metriciExterne.Recall.ToString() };
                dgRezMetrici.Rows.Add(row);
            }
        }
        private void FormRezultateMetrici_Load(object sender, EventArgs e)
        {

        }
    }
}
