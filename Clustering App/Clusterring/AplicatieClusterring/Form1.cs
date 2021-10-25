using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using AplicatieClusterring.Class;

namespace AplicatieClusterring
{
    public partial class fPrincipala : Form
    {
        private Draw draw;
        private ReadFile read;
        private Int16[,] dataMatrix;
        private String[] initialClass;
        private double[,] normalizedData;
        private double[,] distanceMatrix;
        private DBSCAN dBSCAN;
        private HAC hac;
        private List<Data> dataInfo;
        private int mAjustare;

        private bool isNormalize;
        private bool isLoad;
        private bool isDistance;

        private string fileNameDistante;
        private string fileName;
        private string tipDistanta;
        private string tipAlgoritm;
        private string tipNormalizare;
        private string tipSimilaritate;
        private Distante distance;
        private Evaluare eval;
        public fPrincipala()
        {
            InitializeComponent();
            draw = new Draw();
            read = new ReadFile();
            isNormalize = false;
            isLoad = false;
            isDistance = false;

        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            draw.DrawAxis(panelDate);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            fileNameDistante = "DistanteFisier2D_Puncte.txt";
            mAjustare = 200;
            string filePath = "";
            OpenFileDialog openFile = new OpenFileDialog
            {
                InitialDirectory = @"C:\",
                Title = "Browse Text Files",

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = "txt",
                Filter = "txt files (*.txt)|*.txt",
                FilterIndex = 2,
                RestoreDirectory = true,

                ReadOnlyChecked = true,
                ShowReadOnly = true
            };

            if (openFile.ShowDialog() == DialogResult.OK)
            {
                filePath = openFile.FileName;
            }

            try
            {
                panelDate.CreateGraphics().Clear(Color.WhiteSmoke);
                read.Read2DFile(out dataMatrix, out initialClass, filePath);
                draw.DrawPoints(dataMatrix, panelDate, DataProperties.UNCLUSTERED);

                fileName = Path.GetFileNameWithoutExtension(filePath);
                MessageBox.Show("Fisier incarcat cu succes ", "Finish", MessageBoxButtons.OK, MessageBoxIcon.Information);
                isLoad = true;
            }
            catch (System.ArgumentNullException)
            {
                MessageBox.Show("Eroare la incarcarea fisierului.\n\n Alegeti un fisier .arrf sau .txt de pe disc", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (System.ArgumentException)
            {
                MessageBox.Show("Eroare la incarcarea fisierului.\n\n Alegeti un fisier .arrf sau .txt de pe disc", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnLoadNDFile_Click(object sender, EventArgs e)
        {
            fileNameDistante = "DistanteFisierND_Documente.txt";
            mAjustare = 0;
            string filePath = "";
            OpenFileDialog openFile2 = new OpenFileDialog
            {
                InitialDirectory = @"C:\",
                Title = "Browse Text Files",

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = ".txt",
                Filter = "txt files (*.txt)|*.txt|ARFF File (*.arff)|*.arff",
                FilterIndex = 2,
                RestoreDirectory = true,

                ReadOnlyChecked = true,
                ShowReadOnly = true
            };
            if (openFile2.ShowDialog() == DialogResult.OK)
            {
                filePath = openFile2.FileName;
            }
            try
            {

                read.ReadNDFile(out dataMatrix, out initialClass, filePath);
                fileName = Path.GetFileNameWithoutExtension(filePath);
                MessageBox.Show("Fisier incarcat cu succes ", "Finish", MessageBoxButtons.OK, MessageBoxIcon.Information);
                isLoad = true;
            }
            catch (System.ArgumentNullException)
            {
                MessageBox.Show("Eroare la incarcarea fisierului.\n\n Alegeti un fisier .arrf sau .txt de pe disc", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (System.ArgumentException)
            {
                MessageBox.Show("Eroare la incarcarea fisierului.\n\n Alegeti un fisier .arrf sau .txt de pe disc", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnDBSCAN_Click(object sender, EventArgs e)
        {
            tipAlgoritm = "DBSCAN";
            Stopwatch sw = new Stopwatch();

            double eps = Convert.ToDouble(tbDistMax.Text) * (Convert.ToDouble(numEps.Value) / 100.0);
            int minPoints = Convert.ToInt32(numMinPoints.Value);

            if (isDistance)
            {
                dBSCAN = new DBSCAN(ref distanceMatrix);
                sw.Start();
                dBSCAN.Implementation(out dataInfo, eps, minPoints);
                sw.Stop();

                Console.WriteLine("DBSCAN Run Time: {0}", sw.Elapsed);



                int numberOfDimensions = dataMatrix.GetLength(1);

                if (numberOfDimensions == 2)
                {
                    panelDate.CreateGraphics().Clear(Color.WhiteSmoke);
                    foreach (var d in dataInfo)
                    {
                        if (d.ClusterId != -1)
                        {
                            draw.DrawPointsColor(dataMatrix, d.DocId, panelDate, d.ClusterId);
                        }
                    }

                }

                MessageBox.Show("Datele au fost grupate ", "Finish", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("!!EROARE!!.\n\n Verificati pasii anteriori", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnZgomot_Click(object sender, EventArgs e)
        {
            if (isDistance)
            {
                int numberOfDimensions = dataMatrix.GetLength(1);

                if (numberOfDimensions == 2)
                {
                    foreach (var d in dataInfo)
                    {
                        if (d.ClusterId == -1)
                        {
                            draw.DrawPointsColor(dataMatrix, d.DocId, panelDate, 15);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("!!EROARE!!.\n\n Verificati pasii anteriori", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNormalizare_Click(object sender, EventArgs e)
        {
            Normalizare normalizare = new Normalizare();
            if (isLoad)
            {
                if (rbBinara.Checked == true)
                {
                    tipNormalizare = "Binara";
                    normalizedData = normalizare.NormalizareBinara(dataMatrix);
                }
                else if (rbNominala.Checked == true)
                {
                    tipNormalizare = "Nominala";
                    normalizedData = normalizare.NormalizareNominala(dataMatrix, mAjustare);
                }
                else if (rbSuma.Checked == true)
                {
                    tipNormalizare = "Suma1";
                    normalizedData = normalizare.NormalizareSumaUnu(dataMatrix, mAjustare);
                }
                else if (rbMaxMin.Checked == true)
                {
                    tipNormalizare = "Max_Min";
                    normalizedData = normalizare.NormalizareMinMax(dataMatrix, 0, 1);
                }
                else if (rbCornelSmart.Checked == true)
                {
                    tipNormalizare = "Cornell";
                    normalizedData = normalizare.NormalizareCornel_Smart(dataMatrix, mAjustare);
                }
                isNormalize = true;
                MessageBox.Show("Datele au fost normalizate ", "Finish", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Eroare la incarcarea fisierului.\n\n Alegeti un fisier de pe disc ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnEval_Click(object sender, EventArgs e)
        {
            eval.EvaluareDate();
            if (tipAlgoritm == "DBSCAN")
            {
                double distMax = Convert.ToDouble(tbDistMax.Text);
                double procent = Convert.ToDouble(numEps.Value);
                int minPoints = Convert.ToInt32(numMinPoints.Value);
                FormRezultateMetrici rezultateMetrici = new FormRezultateMetrici(eval.MetriciExterne, eval.Zones, ref procent, ref distMax, ref minPoints, ref tipAlgoritm);
                rezultateMetrici.ShowDialog();
            }
            else
            {
                double distMax = Convert.ToDouble(tbDistMax.Text);
                double procent = Convert.ToDouble(numUpPreagHac.Value);
                FormRezultateMetrici rezultateMetrici = new FormRezultateMetrici(eval.MetriciExterne, eval.Zones, ref procent, ref distMax, ref tipSimilaritate, ref tipAlgoritm);
                rezultateMetrici.ShowDialog();
            }
        }
        private void btnCalcDist_Click(object sender, EventArgs e)
        {
            distance = new Distante();
            if (isNormalize)
            {
                distanceMatrix = distance.GetDistanceMatrix(ref normalizedData, TipDistanta());
                tbDistMax.Text = distance.DistMax.ToString();
                MessageBox.Show("Matricea de distante este calculata", "Finish", MessageBoxButtons.OK, MessageBoxIcon.Information);
                isDistance = true;

            }
            else
            {
                MessageBox.Show("Eroare la normalizare sau la incarcarea fisierului.\n\n Alegeti un fisier de pe disc si dupa normalizati datele", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        ///////////Metode Adiacente/////////////////////
        private int TipDistanta()
        {
            if (rbManhattan.Checked == true)
            {
                tipDistanta = "Manhattan";
                return 1;
            }
            else if (rbEuclid.Checked == true)
            {
                tipDistanta = "Euclidiana";
                return 2;
            }
            else if (rbCosinus.Checked == true)
            {
                tipDistanta = "Cosinus";
                return -1;
            }
            else
            {
                tipDistanta = "Minkowski";
                return Convert.ToInt32(numOrdin.Value);
            }
        }

        private void btnGenFile_Click(object sender, EventArgs e)
        {
            string filePath = @"./../../FisiereListeDistante/" + fileNameDistante;
            List<double> dLisist = new List<double>();
            for (int i = 0; i < distanceMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < distanceMatrix.GetLength(1); j++)
                {
                    dLisist.Add(distanceMatrix[i, j]);
                }
            }

            dLisist.Sort((a, b) => b.CompareTo(a));
            using (System.IO.StreamWriter writer = new System.IO.StreamWriter(filePath))
            {
                writer.WriteLine("Eps(Distanta minima intre puncte): " + numEps.Value);
                writer.WriteLine("Numarul minim de puncte care formeaza un cluster: " + numMinPoints.Value);
                writer.WriteLine("Tipul de distanta folosit: " + tipDistanta);
                writer.WriteLine("Lista de distante ordonata descrescator:");
                foreach (var item in dLisist)
                {
                    writer.WriteLine(item);
                }
                writer.Close();
            }
            dLisist.Clear();
        }

        private void btnCorespondenta_Click(object sender, EventArgs e)
        {
            eval = new Evaluare(ref dataInfo, ref initialClass, ref distanceMatrix);
            eval.CorespondenaIntreDate();


            #region Test Centroizi grafic
            int numberOfDimensions = dataMatrix.GetLength(1);

            if (numberOfDimensions == 2)
            {
                Dictionary<int, int> centroizi = eval.Medoizi;
                List<String> docPerClas = eval.FunDocPerClass;
                panelDate.CreateGraphics().Clear(Color.WhiteSmoke);
                foreach (var d in dataInfo)
                {
                    draw.DrawPointsColor(dataMatrix, d.DocId, panelDate, 0);
                }

                foreach (var d in centroizi)
                {
                    draw.DrawPointsColor(dataMatrix, d.Value, panelDate, 15);
                }
                MessageBox.Show("S-au afisat centrizii, iar dupa o sa se afiseze fiecare punct cu o culoare specidica clasei din care face parte", "Finish", MessageBoxButtons.OK, MessageBoxIcon.Information);

                for (int i = 0; i < docPerClas.Count; i++)
                {
                    if (docPerClas[i] != "noise")
                    {
                        draw.DrawPointsColor(dataMatrix, i, panelDate, (Convert.ToInt32(docPerClas[i]) + 1));
                    }
                    else
                    {
                        draw.DrawPointsColor(dataMatrix, i, panelDate, 15);
                    }

                }

                MessageBox.Show("S-au afisat punctele cu o culoare specifica clasei din care face parte", "Finish", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            #endregion
        }

        private void btnGenerareExcel_Click(object sender, EventArgs e)
        {
            if (tipAlgoritm == "DBSCAN")
            {
                double distMax = Convert.ToDouble(tbDistMax.Text);
                double procent = Convert.ToDouble(numEps.Value);
                int minPoints = Convert.ToInt32(numMinPoints.Value);
                ExcelDoc excel = new ExcelDoc("Raport_" + tipAlgoritm + "_" +tipDistanta+ "_"+tipNormalizare+"_"+ fileName);
                excel.SaveExcelFileDBSCAN(eval.MetriciExterne, eval.Zones, procent, distMax, minPoints, fileName);
            }
            else
            {
                double distMax = Convert.ToDouble(tbDistMax.Text);
                double procent = Convert.ToDouble(numUpPreagHac.Value);
                ExcelDoc excel = new ExcelDoc("Raport_" + tipAlgoritm + "_" + tipDistanta + "_" + tipNormalizare + "_" +tipSimilaritate+"_"+ fileName);
                excel.SaveExcelFileHAC(eval.MetriciExterne, eval.Zones, procent, distMax, tipSimilaritate, fileName);
            }
            MessageBox.Show("Fișier Excel Generat", "Finish", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnHAC_Click(object sender, EventArgs e)
        {
            tipAlgoritm = "HAC";
            Stopwatch sw = new Stopwatch();

            double eps = Convert.ToDouble(tbDistMax.Text) * (Convert.ToDouble(numUpPreagHac.Value) / 100.0);

            if (isDistance)
            {
                double[,] distanceMatrixTemp = (double[,])distanceMatrix.Clone();
                hac = new HAC(ref distanceMatrixTemp);
                sw.Start();
                if (rbSingleLink.Checked == true)
                {
                    hac.ImplementationSingleLink(out dataInfo, eps);
                    tipSimilaritate = "SingleLink";
                }
                else if (rbCompleteLink.Checked == true)
                {
                    hac.ImplementationCompleteLink(out dataInfo, eps);
                    tipSimilaritate = "CompleteLink";
                }
                sw.Stop();

                Console.WriteLine("HAC Run Time: {0}", sw.Elapsed);

                distanceMatrixTemp = null;
                GC.Collect(); //Pentru eliberarea memoriei

                int numberOfDimensions = dataMatrix.GetLength(1);

                if (numberOfDimensions == 2)
                {
                    panelDate.CreateGraphics().Clear(Color.WhiteSmoke);
                    foreach (var d in dataInfo)
                    {
                        if (d.ClusterId != -1)
                        {
                            draw.DrawPointsColor(dataMatrix, d.DocId, panelDate, d.ClusterId);
                        }
                    }

                }

                MessageBox.Show("Datele au fost grupate ", "Finish", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                MessageBox.Show("!!EROARE!!.\n\n Verificati pasii anteriori", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
