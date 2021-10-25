using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Coder
{
    public partial class fCoderSF : Form
    {
        private string pathToSave;
        private string extension;
        private int bytesToRead;
        private int bytesRead;
        private int bytesToWrite;
        private int bytesWrite;
        private int nrSimbValide;

        private int[] bufferReader;
        private int[] count;
        private int[] hartaBiti;

        private BitReader bitRead;
        private BitWriter bitWrite;
        private BitWriter bitWriteTb;

        private CoderClass cd;

        private List<Node> listOfNodes;

        //variabilele pentru decodare
        private string pathToSave2;
        private string extension2;


        private int bitsToRead2;
        private int bytesToWrite2;
        private int bytesWrite2;
        private int nrSymValide2;

        private List<int> bufferReader2;
        private int[] bufferReader23;
        private int[] count2;
        private int[] hartaBiti2;


        private CoderClass cd2;

        private List<Node> listOfNodes2;

        public fCoderSF()
        {
            bytesToRead = 0;
            bytesRead = 0;
            bytesToWrite = 0;
            bytesWrite = 0;
            nrSimbValide = 0;

            count = new int[256];
            hartaBiti = new int[256];

            cd = new CoderClass();

            listOfNodes = new List<Node>();

            //variabilele pentru decodare
            bitsToRead2 = 0;
            bytesToWrite2 = 0;
            bytesWrite2 = 0;
            nrSymValide2 = 0;

            hartaBiti2 = new int[256];
            count2 = new int[256];

            cd2 = new CoderClass();

            listOfNodes2 = new List<Node>();
            bufferReader2 = new List<int>();


            InitializeComponent();
        }

        private void btnLoad_Click(object sender, EventArgs e)
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

                bitRead = new BitReader(openFileDialog1.FileName);
                pathToSave = openFileDialog1.FileName + ".sf";

                
            }


        }

        private void btnEncodeFile_Click(object sender, EventArgs e)
        {
            int nrBitiScrisi = 0;
            bytesWrite = 0;
            cbdataGrid.Rows.Clear();
            try
            {
                bufferReader = new int[bitRead.Length];
                bytesToRead = (int)bitRead.Length;

                //cod care executa codarea
                while (bytesToRead > 0)
                {
                    bufferReader[bytesRead] = bitRead.ReadNBit(8);
                    bytesToRead--;
                    bytesRead++;
                }
                bytesToWrite = bytesToRead;
                // bytesWrite = bytesRead;

                bytesToRead = 0;
                bytesRead = 0;

                //Creaza codificarea si statistica
                cd.Statistica(bufferReader, count, hartaBiti);

                for (var i = 0; i < count.Length; i++)
                {
                    if (count[i] != 0)
                    {
                        listOfNodes.Add(new Node((byte)i, count[i]));

                    }
                }
                listOfNodes.Sort(((Node x, Node y) => x.frequency.CompareTo(y.frequency)));


                cd.ShannonFano(listOfNodes, 0, (listOfNodes.Count - 1));

                //Partea de scriere in fisier a codului
                bitWrite = new BitWriter(pathToSave);

                for (var i = 0; i < 256; i++)
                {
                    if (hartaBiti[i] == 1)
                    {
                        nrSimbValide++;
                    }
                    bitWrite.WriteNBits(1, (byte)hartaBiti[i]);
                }

                for (var i = 0; i < 256; i++)
                {
                    if ((hartaBiti[i] != 0) && (nrSimbValide > 0))
                    {
                        bitWrite.WriteNBits(32, (byte)count[i]);
                        nrSimbValide--;
                    }

                }

                for (var i = 0; i < listOfNodes.Count; i++)
                {
                    bytesWrite = bytesWrite + (int)(listOfNodes[i].nrBits * listOfNodes[i].frequency);
                }

                while (bytesWrite > 0)
                {
                    for (var i = 0; i < listOfNodes.Count; i++)
                    {
                        if (listOfNodes[i].symbol == (byte)bufferReader[bytesToWrite])// convertes in byte pentru a ma 
                                                                                      //asigura ca val este in intervalul [0, 255]
                        {
                            bitWrite.WriteNBits(listOfNodes[i].nrBits, listOfNodes[i].code);
                            nrBitiScrisi = (int)listOfNodes[i].nrBits;
                        }
                    }

                    // bitWrite.WriteNBits(8, (byte)bufferReader[bytesToWrite]); //pentru test sa vad 
                    //ca ce scriu este corect 
                    //si ca se decodeaza exact ce scriu in fisier

                    bytesWrite -= nrBitiScrisi;
                    bytesToWrite++;
                }


                //afisarea codurilor
                if (cbCoduri.Checked)
                {

                    for (var i = 0; i < listOfNodes.Count; i++)
                    {
                        string binary=Convert.ToString(listOfNodes[i].code, 2).PadLeft((int)listOfNodes[i].nrBits, '0');
                        string[] row = new string[] { listOfNodes[i].symbol.ToString(), binary.ToString() };
                        cbdataGrid.Rows.Add(row);
                    }

                }

                nrSimbValide = 0;
                Array.Clear(count, 0, count.Length);
                Array.Clear(hartaBiti, 0, hartaBiti.Length);
                listOfNodes.Clear();

                for (var i = 0; i < 7; i++)
                {
                    bitWrite.WriteNBits(1, 1);  //Scrie cei 7 biti la finalul 
                                                //pentru a ne asigura ca o sa golim buffer-ul
                }


                MessageBox.Show("Your file is encoded ", "Finish", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (System.ArgumentNullException)
            {
                MessageBox.Show("You did not load a file", "Error Detected in Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           

        }

        private void btnEncodeText_Click(object sender, EventArgs e)
        {
            cbdataGrid.Rows.Clear();
            FolderBrowserDialog fb = new FolderBrowserDialog();
            string localPath;
            if (fb.ShowDialog() == DialogResult.OK)
            {

                localPath = fb.SelectedPath + "\\TextTB.txt.sf";
            }
            else 
            {
                localPath = "..\\TextTB.txt.sf";
                MessageBox.Show("You must select a folder", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

            bitWriteTb = new BitWriter(localPath);
            int byteTbWrite = 0;
            byte[] buffReadTb = Encoding.ASCII.GetBytes(tbInputText.Text);

            int byteTbRead = buffReadTb.Length;

            //Creaza codificarea si statistica
            cd.Statistica(buffReadTb, count, hartaBiti);

            for (var i = 0; i < count.Length; i++)
            {
                if (count[i] != 0)
                {
                    listOfNodes.Add(new Node((byte)i, count[i]));

                }
            }
            listOfNodes.Sort(((Node x, Node y) => x.frequency.CompareTo(y.frequency)));
                cd.ShannonFano(listOfNodes, 0, (listOfNodes.Count - 1));

            //afisarea codurilor
            if (cbCoduri.Checked)
            {

                for (var i = 0; i < listOfNodes.Count; i++)
                {
                    string binary = Convert.ToString(listOfNodes[i].code, 2).PadLeft((int)listOfNodes[i].nrBits, '0');
                    string[] row = new string[] { listOfNodes[i].symbol.ToString(), binary.ToString() };
                    cbdataGrid.Rows.Add(row);
                }

            }
            //-----------------------------------------

            for (var i = 0; i < 256; i++)
            {
                if (hartaBiti[i] == 1)
                {
                    nrSimbValide++;
                }
                bitWriteTb.WriteNBits(1, (byte)hartaBiti[i]);
            }

            for (var i = 0; i < 256; i++)
            {
                if ((hartaBiti[i] != 0) && (nrSimbValide > 0))
                {
                    bitWriteTb.WriteNBits(32, (byte)count[i]);
                    nrSimbValide--;
                }

            }

            while (byteTbRead > 0)
            {
                for (var i = 0; i < listOfNodes.Count; i++)
                {
                    if (listOfNodes[i].symbol == (byte)buffReadTb[byteTbWrite])// convertes in byte pentru a ma 
                                                                               //asigura ca val este in intervalul [0, 255]
                    {
                        bitWriteTb.WriteNBits(listOfNodes[i].nrBits, listOfNodes[i].code);
                    }
                }

                //bitWriteTb.WriteNBits(8, (byte)buffReadTb[byteTbWrite]); //pentru test sa vad 
                //ca ce scriu este corect
                //si ca se decodeaza exact ce scriu in fisier

                byteTbRead--;
                byteTbWrite++;
            }

            for (var i = 0; i < 7; i++)
            {
                bitWriteTb.WriteNBits(1, 1);  //Scrie cei 7 biti la finalul 
                                              //pentru a ne asigura ca o sa golim buffer-ul
            }

            tbInputText.Text = "";
            MessageBox.Show("Your text is encoded ", "Finish", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        private void btnLoadEnc_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                InitialDirectory = @"C:\",
                Title = "Browse Text Files",

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = "sf",
                Filter = "shannon fannon file (*.sf)|*.sf",
                FilterIndex = 2,
                RestoreDirectory = true,

                ReadOnlyChecked = true,
                ShowReadOnly = true
            };

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                bitRead = new BitReader(openFileDialog1.FileName);

                DateTime now = DateTime.Now;
                extension2 = System.IO.Path.GetExtension(System.IO.Path.GetFileNameWithoutExtension(openFileDialog1.FileName));
                string date = now.Day.ToString() + "-" + now.Month.ToString() + "-" + now.Year.ToString()
                    + "-" + now.Hour.ToString() + "-" + now.Minute.ToString();

                pathToSave2 = openFileDialog1.FileName + "." + date + extension2;


            }
        }

        private void btnDecode_Click(object sender, EventArgs e)
        {
            try
            {
                ///Decodarea fisierului de input
                var index = 0;

                bufferReader23 = new int[bitRead.Length];
                bitsToRead2 = (int)bitRead.Length;
                int lungimeHartaBiti = bitsToRead2 - (bitsToRead2 - 256);
                bitsToRead2 = bitsToRead2 - lungimeHartaBiti;

                while (lungimeHartaBiti > 0)
                {

                    hartaBiti2[index] = bitRead.ReadNBit(1);

                    if (hartaBiti2[index] == 1)
                    {
                        nrSymValide2++;
                    }


                    lungimeHartaBiti--;
                    index++;

                }
                nrSymValide2 *= 32;

                bitsToRead2 = bitsToRead2 - nrSymValide2;
                for (var i = 0; i < 256; i++)
                {
                    if ((hartaBiti2[i] == 1) && (nrSymValide2 > 0))
                    {
                        count2[i] = bitRead.ReadNBit(32);
                        nrSymValide2 -= 32;
                    }
                }
                //Creaza codificarea si statistica

                for (var i = 0; i < count2.Length; i++)
                {
                    if (count2[i] != 0)
                    {
                        listOfNodes2.Add(new Node((byte)i, count2[i]));

                    }
                }
                listOfNodes2.Sort(((Node x, Node y) => x.frequency.CompareTo(y.frequency)));
                cd2.ShannonFano(listOfNodes2, 0, (listOfNodes2.Count - 1));
                uint maxList = cd2.MaxNrBiti(listOfNodes2);

                bitsToRead2 = 0;
                for (var i = 0; i < listOfNodes2.Count; i++)
                {
                    bitsToRead2 = bitsToRead2 + (int)(listOfNodes2[i].nrBits * listOfNodes2[i].frequency);
                }


                bool scris;
                int indexBit = 0;
                int valTemp = 0;
                while (bitsToRead2 > 0)
                {
                    scris = false;
                    for (int j = 1; j <= maxList; j++)
                    {

                        valTemp = valTemp << 1;
                        valTemp = bitRead.ReadNBit(1);
                        for (int i = 0; i < listOfNodes2.Count; i++)
                        {

                            if ((listOfNodes2[i].code == valTemp) && (listOfNodes2[i].nrBits == j))
                            {
                                bufferReader2.Add(listOfNodes2[i].symbol);
                                indexBit = j;
                                scris = true;
                                break;
                            }
                        }
                        if (scris == true)
                        {
                            break;
                        }
                    }
                    valTemp = 0;
                    bitsToRead2 -= indexBit;

                }

                bytesWrite2 = bufferReader2.Count;

                bitsToRead2 = 0;

                nrSymValide2 = 0;
                Array.Clear(count2, 0, count2.Length);
                Array.Clear(hartaBiti2, 0, hartaBiti2.Length);
                listOfNodes2.Clear();


                ///Partea de scriere a codului in fisier
                bitWrite = new BitWriter(pathToSave2);
                while (bytesWrite2 > 0)
                {
                    // bitWrite.WriteNBits(8, (byte)bufferReader23[bytesToWrite2]);// convertes in byte pentru a ma 
                    bitWrite.WriteNBits(8, (byte)bufferReader2[bytesToWrite2]);                                                        //asigura ca val este in intervalul [0, 255]
                    bytesWrite2--;
                    bytesToWrite2++;
                }
                MessageBox.Show("Your file is decoded", "Finish", MessageBoxButtons.OK, MessageBoxIcon.Information);
                bufferReader2.Clear();
            }
            catch (System.ArgumentNullException)
            {
                MessageBox.Show("You did not load a file", "Error Detected in Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}


