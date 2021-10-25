using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LZW
{
    public partial class fLZW : Form
    {
        private string pathToSaveEncodedFile;
        private string pathFileToDecode;
        private string pathToSaveDecodedFile;

        LzwClass lzw = new LzwClass();

        public fLZW()
        {
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
                pathToSaveEncodedFile = openFileDialog1.FileName;
            }
        }

        private void btnEncodeFile_Click(object sender, EventArgs e)
        {

            List<int> code = new List<int>();
            int numberOfBitsForIndex = Convert.ToInt32(numIndex.Value);
            int dimensiuneBuffer = (int)Math.Pow(2, (double)numberOfBitsForIndex);
            int fOrE = 1;
            string addExt1 = "";
            if (rbFreeze.Checked == true)
            {
                fOrE = 1;
                addExt1 = "f";
            }
            else if (rbEmpty.Checked == true)
            {
                fOrE = 0;
                addExt1 = "e";
            }
            string encodedFileExtension = pathToSaveEncodedFile + "." + addExt1 + "l" + numberOfBitsForIndex.ToString() + ".lzw";

            BitWriter bw = new BitWriter(encodedFileExtension);
            bw.WriteNBits(4, numberOfBitsForIndex);
            bw.WriteNBits(1, fOrE);

            lzw.CodareLzw(out code, pathToSaveEncodedFile, dimensiuneBuffer, fOrE);

            //afisarea indexes
            if (cbShowIndexes.Checked)
            {
                foreach (int c in code)
                {
                    dgIndexes.Rows.Add(c.ToString());
                }
            }

            for (var i = 0; i < code.Count; i++)
            {
                bw.WriteNBits((uint)numberOfBitsForIndex, code[i]);
            }

            for (var i = 0; i < 7; i++)
            {
                bw.WriteNBits(1, 1);
            }



        }

        private void btnLoadFileDecode_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog2 = new OpenFileDialog
            {
                InitialDirectory = @"C:\",
                Title = "Browse Text Files",

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = ".lzw",
                Filter = "LZW files (*.lzw)|*.lzw",
                FilterIndex = 2,
                RestoreDirectory = true,

                ReadOnlyChecked = true,
                ShowReadOnly = true
            };

            if (openFileDialog2.ShowDialog() == DialogResult.OK)
            {
                pathFileToDecode = openFileDialog2.FileName;
                string extensie1 = System.IO.Path.GetFileNameWithoutExtension(openFileDialog2.FileName);
                string extensie2 = System.IO.Path.GetFileNameWithoutExtension(extensie1);

                string finalExtensie = System.IO.Path.GetExtension(extensie2);
                pathToSaveDecodedFile = openFileDialog2.FileName + finalExtensie;
            }

        }

        private void btnDecode_Click(object sender, EventArgs e)
        {
            List<byte> decodeList=new List<byte>();
            lzw.DecodareLzw(out decodeList,pathFileToDecode);

            BitWriter bw = new BitWriter(pathToSaveDecodedFile);
          
            foreach (byte b in decodeList)
            {
                bw.WriteNBits(8, (int)b);
            }
        }
    }
}
