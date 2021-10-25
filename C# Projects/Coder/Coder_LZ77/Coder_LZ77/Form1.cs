using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Coder_LZ77
{
    public partial class fCoderLZ77 : Form
    {
        private string pathToSave;
        private string pathToSave2;
        private string pathToSave3;
        private Lz77 lz77;
        private List<Token> tokenList;
        private BitWriter bitWriteCode;
        private BitWriter bitWriteDecode;
        private int numBitiLen;
        private int numBitiOff;


        public fCoderLZ77()
        {
            lz77 = new Lz77();
            tokenList = new List<Token>();

            InitializeComponent();
        }


        private void btnLoadFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                InitialDirectory = @"C:\",
                Title = "Browse Text Files",

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = "txt",
                Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*",
                FilterIndex = 2,
                RestoreDirectory = true,

                ReadOnlyChecked = true,
                ShowReadOnly = true
            };

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pathToSave = openFileDialog1.FileName;
            }
        }

        private void btnEncodeFile_Click(object sender, EventArgs e)
        {
            tokenDataGrid.Rows.Clear();
            string varPath = pathToSave;
            string stOffset = numUpOffset.Value.ToString();
            string stLength = numUpLength.Value.ToString();
            pathToSave = pathToSave + ".o" + stOffset + "l" + stLength + ".lz77";

            try
            {
                numBitiLen = Convert.ToInt32(numUpLength.Value);
                numBitiOff = Convert.ToInt32(numUpOffset.Value);

                int maxLungime = (int)Math.Pow(2, (double)numBitiLen);
                int maxOffset = (int)Math.Pow(2, (double)numBitiOff);

                lz77.CodareAlgLz77(out tokenList, maxOffset, maxLungime, varPath);

                //afisarea tokenilor
                if (cbShowTokens.Checked)
                {
                    foreach (Token t in tokenList)
                    {
                        
                        string[] row = new string[] { t.Poz.ToString(), t.Len.ToString(), t.Sym.ToString() };
                        tokenDataGrid.Rows.Add(row);
                    }
                }

                bitWriteCode = new BitWriter(pathToSave);

                bitWriteCode.WriteNBits(4, numBitiOff);  //Scrie cei 4 biti pentru a vedea lungimea offsetului
                bitWriteCode.WriteNBits(3, numBitiLen);  //Scrie cei 3 biti pentru a vedea lungimea length-ului

                for (var i = 0; i < tokenList.Count; i++)
                {
                    bitWriteCode.WriteNBits((uint)numBitiOff, tokenList[i].Poz);
                    bitWriteCode.WriteNBits((uint)numBitiLen, tokenList[i].Len);
                    bitWriteCode.WriteNBits(8, tokenList[i].Sym);
                }

                for (var i = 0; i < 7; i++)
                {
                    bitWriteCode.WriteNBits(1, 1);  //Scrie cei 7 biti la finalul 
                                                //pentru a ne asigura ca o sa golim buffer-ul
                }

                MessageBox.Show("Your file is encoded ", "Finish", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (System.ArgumentNullException)
            {
                MessageBox.Show("You did not load a file", "Error Detected in Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            pathToSave = varPath;
        }

        private void btnLoadFileDecode_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog2 = new OpenFileDialog
            {
                InitialDirectory = @"C:\",
                Title = "Browse Text Files",

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = ".lz77",
                Filter = "LZ77 files (*.lz77)|*.lz77",
                FilterIndex = 2,
                RestoreDirectory = true,

                ReadOnlyChecked = true,
                ShowReadOnly = true
            };

            if (openFileDialog2.ShowDialog() == DialogResult.OK)
            {
                pathToSave3 = openFileDialog2.FileName;
                string extensie1 = System.IO.Path.GetFileNameWithoutExtension(openFileDialog2.FileName);
                string extensie2 = System.IO.Path.GetFileNameWithoutExtension(extensie1); 
                
                string finalExtensie = System.IO.Path.GetExtension(extensie2);
                pathToSave2 = openFileDialog2.FileName + finalExtensie;
            }
        }

        private void btnDecode_Click(object sender, EventArgs e)
        {

            try
            {
                List<byte> SB = new List<byte>();
                lz77.DecoderAlgLz77(out SB, pathToSave3);

                BitWriter bw = new BitWriter(pathToSave2);
                SB.Reverse();
                foreach (byte b in SB)
                {
                    bw.WriteNBits(8, (int)b);
                }
               
                MessageBox.Show("Your file is decoded ", "Finish", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (System.ArgumentNullException)
            {
                MessageBox.Show("You did not load a file", "Error Detected in Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
