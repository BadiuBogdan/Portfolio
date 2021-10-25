using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Coder_LZ77
{
    class Lz77
    {
        private bool isEqual(byte[] arr1, byte[] arr2)
        {
            bool isEqual = true;
            if (arr1.Length != arr2.Length)
            {
                return false;
            }
            for (var i = 0; i < arr1.Length; i++)
            {
                if (arr1[i] != arr2[i])
                {
                    isEqual = false;
                }
            }
            return isEqual;
        }
        public void CodareAlgLz77(out List<Token> tokens, int lungimeBitiOff, int lungimeBitiLen, string filePathToRead)
        {
            BitReader br = new BitReader(filePathToRead);

            tokens = new List<Token>();
            List<byte> SB = new List<byte>();
            List<byte> temp = new List<byte>();
            List<byte> LB = new List<byte>();

            bool gataLungimea = false;
            bool gataOffset = false;


            long lungimeFisier = br.Length;

            while (lungimeFisier > 0)
            {
                LB.Add((byte)br.ReadNBit(8));
                lungimeFisier--;

            }
            
            long lungime = (LB.Count - 1);

            if (SB.Count == 0)
            {
                SB.Insert(0, (byte)LB[0]);
                tokens.Add(new Token(0, 0, LB[0]));
                LB.RemoveAt(0);
            }

            while (lungime > 0)
            {
                byte[] strTempSB = { };
                byte[] strTempLB = { };
                int lungimeIndex = 1;
                int offset = 0;
                if (LB.Count == 0)
                {
                    break;
                }
                if (temp.Count <= lungimeBitiLen)
                {
                    temp.Add(LB[0]);
                    LB.RemoveAt(0);
                }
                else
                {
                    gataLungimea = true;
                }

                for (var i = 0; i < temp.Count; i++)
                {
                    if (SB.Count > lungimeBitiOff)
                    {
                        gataOffset = true;


                    }

                    for (var j = 0; j < SB.Count; j++)
                    {

                        if (gataOffset)
                        {
                            SB.RemoveAt((SB.Count - 1));
                            gataOffset = false;
                        }

                        if ((j + (lungimeIndex-1)) >= SB.Count)
                        {
                            strTempLB = temp.GetRange(0, temp.Count).ToArray();
                            Array.Reverse(strTempLB);
                            temp.RemoveRange(0, temp.Count - 1);
                            break;
                        }
                        else
                        {
                            strTempSB = SB.GetRange(j, lungimeIndex).ToArray();
                            strTempLB = temp.GetRange(0, temp.Count).ToArray();
                            Array.Reverse(strTempLB);
                            if (isEqual(strTempSB, strTempLB))
                            {
                                if (LB.Count == 0)
                                {
                                    break;
                                }
                                temp.Add(LB[0]);
                                LB.RemoveAt(0);
                                if (lungimeIndex > 0)
                                {
                                    offset = j + (lungimeIndex - 1);
                                }
                                else
                                {
                                    offset = j;
                                }

                                lungimeIndex++;
                                break;
                            }

                        }
                    }
                    if (gataLungimea)
                    {
                        gataLungimea = false;
                        break;
                    }


                }
                SB.InsertRange(0, strTempLB);
                tokens.Add(new Token(offset, (lungimeIndex - 1), temp[temp.Count - 1]));
                temp.Clear();

            }

        }

        public void DecoderAlgLz77(out List<byte> SB, string filePathToRead)
        {


            BitReader br = new BitReader(filePathToRead);

            List<Token> tokenList = new List<Token>();
            SB = new List<byte>();
            List<byte> temp = new List<byte>();
            List<byte> LB = new List<byte>();


            int lungimeBitiOff = br.ReadNBit(4);
            int lungimeBitiLen = br.ReadNBit(3); 



            long lungimeFisier = (br.Length) * 8;

            while (lungimeFisier >= (lungimeBitiOff + lungimeBitiLen + 8))
            {
                int poz = br.ReadNBit((uint)lungimeBitiOff);
                int len = br.ReadNBit((uint)lungimeBitiLen);
                int sym = br.ReadNBit(8);
                tokenList.Add(new Token(poz, len, (byte)sym));
                lungimeFisier -= (lungimeBitiOff + lungimeBitiLen + 8);

            }
          
            foreach (Token t in tokenList)
            {
                if ((t.Len == 0) && (t.Poz == 0))
                {
                    SB.Insert(0, t.Sym);
                }
                else if (t.Poz == 0)
                {
                    byte[] strTempSB = SB.GetRange(t.Poz, t.Len).ToArray();
                    Array.Reverse(strTempSB);
                    SB.InsertRange(0, strTempSB);
                    SB.Insert(0, t.Sym);
                }

                else
                {
                    byte[] strTemp = SB.GetRange(0, t.Poz+1).ToArray();
                    temp = new List<byte>(strTemp);
                    Array.Clear(strTemp,0,strTemp.Length);
                    temp.Reverse();
                    byte[] strTempSB = temp.GetRange(0, t.Len).ToArray();
                    Array.Reverse(strTempSB);
                    SB.InsertRange(0, strTempSB);
                    SB.Insert(0, t.Sym);
                }
            }
        }
    }
}
