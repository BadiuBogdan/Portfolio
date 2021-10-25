using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LZW
{
    class LzwClass
    {
        public void CodareLzw(out List<int> code, string filePathToRead, int dimensiuneBuffer, int fOrE)
        {
            BitReader br = new BitReader(filePathToRead);
            long lungime = br.Length;

            code = new List<int>();
            List<byte> temp = new List<byte>();
            List<int> fisier = new List<int>();


            while (lungime > 0)
            {
                fisier.Add(br.ReadNBit(8));
                lungime--;
            }


            List<byte>[] vectorList = new List<byte>[dimensiuneBuffer];
            int lungimeDictionar = 256;

            for (var i = 0; i < lungimeDictionar; i++)
            {
                vectorList[i] = new List<byte>();
                vectorList[i].Add((byte)i);
            }
            int lungimeFisier = fisier.Count;

            int indexCaracter = 0;
            int indexBuff = lungimeDictionar;
            int nrCode = 0;

            while (lungimeFisier > 0)
            {

                bool gata = false;
                if (indexCaracter >= fisier.Count)
                {
                    code.Add(nrCode);
                    break;
                }
                else
                {
                    temp.Add((byte)fisier[indexCaracter]);


                }

                for (var i = 0; i < dimensiuneBuffer; i++)
                {
                    if (vectorList[i] == null)
                    {
                        break;
                    }
                    if (vectorList[i].SequenceEqual(temp))
                    {
                        nrCode = i;
                        indexCaracter++;
                        gata = false;
                        break;
                    }
                    else
                    {

                        gata = true; ;
                    }
                }
                if (gata)
                {
                    code.Add(nrCode);

                    if (indexBuff < vectorList.Length)
                    {
                        vectorList[indexBuff] = new List<byte>(temp);
                        indexBuff++;
                    }
                    else if (fOrE == 0)
                    {
                        for (var i = lungimeDictionar; i < vectorList.Length; i++)
                        {
                            vectorList[i] = null;
                        }
                        indexBuff = lungimeDictionar;
                    }
                    else if (fOrE == 1) {/*Nu se modifica numic in buffer, deci nu fa nimic, lasa totul asa*/}

                    fisier.RemoveRange(0, temp.Count - 1);
                    indexCaracter = 0;
                    temp.Clear();
                }

            }
        }

        public void DecodareLzw(out List<byte> decodeList,string filePathToRead)
        {
            BitReader br = new BitReader(filePathToRead);
            decodeList = new List<byte>();


            List<byte> temp = new List<byte>();
            List<int> code = new List<int>();
            long lungimeFisier = br.Length * 8;

            int numberOfBitsForIndex = br.ReadNBit(4);
            int dimensiuneBuffer = (int)Math.Pow(2, (double)numberOfBitsForIndex);

            int fOrE = br.ReadNBit(1);
            lungimeFisier -= 5;


            while (lungimeFisier >= numberOfBitsForIndex)
            {
                code.Add(br.ReadNBit((uint)numberOfBitsForIndex));
                lungimeFisier -= numberOfBitsForIndex;
            }

            List<byte>[] vectorList = new List<byte>[dimensiuneBuffer];
            int lungimeDictionar = 256;

            for (var i = 0; i < lungimeDictionar; i++)
            {
                vectorList[i] = new List<byte>();
                vectorList[i].Add((byte)i);
            }

            int indexBuffer = lungimeDictionar;

            while (code.Count > 0)
            {
                int indexSymbol = code[0];
                
                if ((vectorList[indexSymbol] != null))
                {
                    decodeList.AddRange(vectorList[indexSymbol]);

                    if (indexBuffer < vectorList.Length)
                    {
                        if (code.Count > 1)
                        {
                            temp.AddRange(vectorList[indexSymbol]);
                            temp.AddRange(vectorList[code[1]].GetRange(0,1));
                        }
                        else
                        {
                            temp.AddRange(vectorList[indexSymbol]);
                        }
                        vectorList[indexBuffer] = new List<byte>(temp);
                        temp.Clear();
                        indexBuffer++;
                    }
                    else if (fOrE == 0)
                    {
                        for (var i = lungimeDictionar; i < vectorList.Length; i++)
                        {
                            vectorList[i] = null;
                        }
                        indexBuffer = lungimeDictionar;
                    }
                    else if (fOrE == 1) {/*Nu se modifica numic in buffer, deci nu fa nimic, lasa totul asa*/}

                    code.RemoveAt(0);

                }
            }
        }
    }
}
