using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlgPredictiv
{
    public partial class fPrincipala : Form
    {
        private string pathOriginaFile;
        private string pathToSaveEncoded;
        private string pathEncodedFile;
        private string pathToSaveDecoded;

        private BitReader bitReader;
        private BitWriter bitWriter;
        private BitReader bitReaderDecode;
        private BitWriter bitWriterDecode;
        private Predictie objPredictie;
        private Histograma objHistograma;

        private byte[] antet;
        private byte[,] original;
        private int[,] errorMatrix;
        private byte[,] errorMatrixAfis;
        private byte[,] decoded;
        private byte[,] predictie;

        private int tipPreditie;
        public fPrincipala()
        {
            InitializeComponent();
            antet = new byte[1078];
            original = new byte[256, 256];
            errorMatrix = new int[256, 256];
            errorMatrixAfis = new byte[256, 256];
            decoded = new byte[256, 256];
            predictie = new byte[256, 256];
            objPredictie = new Predictie();
            objHistograma = new Histograma();

            tipPreditie = 1;
        }

        private void btnShowHistogram_Click(object sender, EventArgs e)
        {
            double scaleValueHistogram = Convert.ToDouble(numUpScaleHistogram.Value);
            int[] histograma;
            if (rbOriginal.Checked == true)
            {
                histograma = objHistograma.FunctieHistograma(original);
            }
            else if (rbErrorPrediction.Checked == true)
            {
                histograma = objHistograma.FunctieHistograma(errorMatrix);
            }
            else
            {
                histograma = objHistograma.FunctieHistograma(decoded);
            }
            formHistogram histogram = new formHistogram(histograma, scaleValueHistogram);
            histogram.Show();
        }

        private void btnLoadImage_Click(object sender, EventArgs e)
        {
            Color color;
            Bitmap imagine = new Bitmap(256, 256);

            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                InitialDirectory = @"C:\",
                Title = "Browse Text Files",

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = ".bmp",
                Filter = "BMP files (*.bmp)|*.bmp",
                FilterIndex = 2,
                RestoreDirectory = true,

                ReadOnlyChecked = true,
                ShowReadOnly = true
            };

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pathOriginaFile = openFileDialog1.FileName;


            }

            try
            {
                bitReader = new BitReader(pathOriginaFile);

                for (var i = 0; i < 1078; i++)
                {
                    antet[i] = (byte)bitReader.ReadNBit(8);
                }

                for (var i = 0; i < 256; i++)
                {
                    for (var j = 0; j < 256; j++)
                    {
                        original[i, j] = (byte)bitReader.ReadNBit(8);
                    }
                }

                for (var i = 0; i < 256; i++)
                {
                    for (var j = 0; j < 256; j++)
                    {
                        color = Color.FromArgb(original[i, j], original[i, j], original[i, j]);
                        imagine.SetPixel(i, j, color);
                    }
                }

                imagine.RotateFlip(RotateFlipType.Rotate90FlipXY);
                pbOriginalImage.Size = new Size(imagine.Width, imagine.Height);
                pbOriginalImage.Image = (Image)imagine;




                MessageBox.Show("Your picture is loaded ", "Finish", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (System.ArgumentNullException)
            {
                MessageBox.Show("You did not load a picture", "Error Detected in Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPredict_Click(object sender, EventArgs e)
        {

            
            if (rbP128.Checked == true)
            {
                tipPreditie = 1;
            }
            else if (rbPA.Checked == true)
            {
                tipPreditie = 2;
            }
            else if (rbPB.Checked == true)
            {
                tipPreditie = 3;
            }
            else if (rbPC.Checked == true)
            {
                tipPreditie = 4;
            }
            else if (rbPABC1.Checked == true)
            {
                tipPreditie = 5;
            }
            else if (rbPABC2.Checked == true)
            {
                tipPreditie = 6;
            }
            else if (rbPABC3.Checked == true)
            {
                tipPreditie = 7;
            }
            else if (rbPAB.Checked == true)
            {
                tipPreditie = 8;
            }
            else if (rbPjpegLS.Checked == true)
            {
                tipPreditie = 9;
            }
            switch (tipPreditie)
            {
                case 1:
                    objPredictie.Preditie128(original, predictie);
                    break;

                case 2:
                    objPredictie.PreditieA(original, predictie);
                    break;
                case 3:
                    objPredictie.PreditieB(original, predictie);
                    break;
                case 4:
                    objPredictie.PreditieC(original, predictie);
                    break;
                case 5:
                    objPredictie.PreditieABC1(original, predictie);
                    break;
                case 6:
                    objPredictie.PreditieABC2(original, predictie);
                    break;
                case 7:
                    objPredictie.PreditieABC3(original, predictie);
                    break;
                case 8:
                    objPredictie.PreditieAB(original, predictie);
                    break;
                case 9:
                    objPredictie.PreditiejpegLS(original, predictie);
                    break;
            }


            for (var i = 0; i < 256; i++)
            {
                for (var j = 0; j < 256; j++)
                {
                    errorMatrix[i, j] = original[i, j] - predictie[i, j];
                }
            }

            MessageBox.Show("Finish error matrix ", "Finish", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

       

        private void btnShowErrorMatrix_Click(object sender, EventArgs e)
        {
            Color color;
            Bitmap imagine = new Bitmap(256, 256);
            double valueScalError = Convert.ToDouble(numUpScaleError.Value);
            for (var i = 0; i < 256; i++)
            {
                for (var j = 0; j < 256; j++)
                {
                    int aux = Convert.ToInt16((128 + (errorMatrix[i, j] * valueScalError)));
                    errorMatrixAfis[i, j] = objPredictie.AproximareInterval(aux);
                }
            }

            for (var i = 0; i < 256; i++)
            {
                for (var j = 0; j < 256; j++)
                {
                    color = Color.FromArgb(errorMatrixAfis[i, j], errorMatrixAfis[i, j], errorMatrixAfis[i, j]);
                    imagine.SetPixel(i, j, color);
                }
            }

            imagine.RotateFlip(RotateFlipType.Rotate90FlipXY);
            pbErrorMatrix.Size = new Size(imagine.Width, imagine.Height);
            pbErrorMatrix.Image = (Image)imagine;

        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            pathToSaveEncoded = pathOriginaFile  + tipPreditie.ToString() + ".pre";

            try
            {
                bitWriter = new BitWriter(pathToSaveEncoded);

                
                for (var i = 0; i < 1078; i++)
                {
                    bitWriter.WriteNBits(8, antet[i]);
                }

                bitWriter.WriteNBits(4, tipPreditie);

                for (var i = 0; i < 256; i++)
                {
                    for (var j = 0; j < 256; j++)
                    {
                        int valWrite = 0;
                        if (errorMatrix[i, j] < 0)
                        {
                            valWrite = errorMatrix[i, j] * -1;
                            bitWriter.WriteNBits(1, 1);
                        }
                        else
                        {
                            valWrite = errorMatrix[i, j];
                            bitWriter.WriteNBits(1,0);
                        }
                        bitWriter.WriteNBits(8, valWrite);
                    }
                }

                for (var i = 0; i < 7; i++)
                {
                    bitWriter.WriteNBits(1, 1);
                }
                MessageBox.Show("Your picture is encoded ", "Finish", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (System.ArgumentNullException)
            {
                MessageBox.Show("You did not load a picture", "Error Detected in Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnLoadEncoded_Click(object sender, EventArgs e)
        {
            Array.Clear(errorMatrix, 0, errorMatrix.Length);

            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                InitialDirectory = @"C:\",
                Title = "Browse Text Files",

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = ".pre",
                Filter = "PRE files (*.pre)|*.pre",
                FilterIndex = 2,
                RestoreDirectory = true,

                ReadOnlyChecked = true,
                ShowReadOnly = true
            };

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pathEncodedFile = openFileDialog1.FileName;
            }

            try
            {
                bitReaderDecode = new BitReader(pathEncodedFile);

                

                for (var i = 0; i < 1078; i++)
                {
                    antet[i] = (byte)bitReaderDecode.ReadNBit(8);
                }

                tipPreditie = bitReaderDecode.ReadNBit(4);

                for (var i = 0; i < 256; i++)
                {
                    for (var j = 0; j < 256; j++)
                    {
                        int semn= bitReaderDecode.ReadNBit(1);
                        if (semn == 1)
                        {
                            errorMatrix[i, j] = bitReaderDecode.ReadNBit(8);
                            errorMatrix[i, j] = errorMatrix[i, j] * -1;

                        }
                        else
                        {
                            errorMatrix[i, j] = bitReaderDecode.ReadNBit(8);
                        }   
                    }
                }

                MessageBox.Show("Your picture is loaded ", "Finish", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (System.ArgumentNullException)
            {
                MessageBox.Show("You did not load a picture", "Error Detected in Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDecode_Click(object sender, EventArgs e)
        {

            Color color;
            Bitmap imagine = new Bitmap(256, 256);

            switch (tipPreditie)
            {
                case 1:
                    objPredictie.DecodePreditie128(decoded, predictie,errorMatrix);
                    break;

                case 2:
                    objPredictie.DecodePreditieA(decoded, predictie, errorMatrix);
                    break;
                case 3:
                    objPredictie.DecodePreditieB(decoded, predictie, errorMatrix);
                    break;
                case 4:
                    objPredictie.DecodePreditieC(decoded, predictie, errorMatrix);
                    break;
                case 5:
                    objPredictie.DecodePreditieABC1(decoded, predictie, errorMatrix);
                    break;
                case 6:
                    objPredictie.DecodePreditieABC2(decoded, predictie, errorMatrix);
                    break;
                case 7:
                    objPredictie.DecodePreditieABC3(decoded, predictie, errorMatrix);
                    break;
                case 8:
                    objPredictie.DecodePreditieAB(decoded, predictie, errorMatrix);
                    break;
                case 9:
                    objPredictie.DecodePreditiejpegLS(decoded, predictie, errorMatrix);
                    break;
            }

            for (var i = 0; i < 256; i++)
            {
                for (var j = 0; j < 256; j++)
                {
                    color = Color.FromArgb(decoded[i, j], decoded[i, j], decoded[i, j]);
                    imagine.SetPixel(i, j, color);
                }
            }

            imagine.RotateFlip(RotateFlipType.Rotate90FlipXY);
            pbDecodedImage.Size = new Size(imagine.Width, imagine.Height);
            pbDecodedImage.Image = (Image)imagine;

            MessageBox.Show("Your file is decoded", "Finish", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnSaveDecode_Click(object sender, EventArgs e)
        {
            pathToSaveDecoded = pathEncodedFile + ".decoded";
            try 
            {
                bitWriterDecode = new BitWriter(pathToSaveDecoded);

                for (var i = 0; i < 1078; i++)
                {
                    bitWriterDecode.WriteNBits(8, antet[i]);
                }

                for (var i = 0; i < 256; i++)
                {
                    for (var j = 0; j < 256; j++)
                    {
                        bitWriterDecode.WriteNBits(8, decoded[i, j]);
                    }
                }

                for (var i = 0; i < 7; i++)
                {
                    bitWriterDecode.WriteNBits(1, 1);
                }
                MessageBox.Show("Your picture is saved ", "Finish", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (System.ArgumentNullException)
            {
                MessageBox.Show("You did not load a picture", "Error Detected in Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void fPrincipala_Load(object sender, EventArgs e)
        {

        }
    }
}
