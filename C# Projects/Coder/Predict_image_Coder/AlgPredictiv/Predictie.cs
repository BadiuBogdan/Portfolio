using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgPredictiv
{
    class Predictie
    {
        public void Preditie128(byte[,] orig, byte[,] pred)
        {
            for (var i = 0; i < 256; i++)
            {
                for (var j = 0; j < 256; j++)
                {
                    pred[i, j] = 128;
                }
            }
        }
        public void PreditieA(byte[,] orig, byte[,] pred)
        {
            for (var i = 0; i < 256; i++)
            {
                for (var j = 0; j < 256; j++)
                {
                    if ((i == 0) && (j == 0))
                    {
                        pred[i, j] = 128;
                    }
                    else if ((i == 0) && (j != 0))
                    {
                        pred[i, j] = orig[i, j - 1];
                    }
                    else if ((i != 0) && (j == 0))
                    {
                        pred[i, j] = orig[i - 1, j];
                    }
                    else
                    {
                        pred[i, j] = orig[i, j - 1];
                    }
                }
            }
        }
        public void PreditieB(byte[,] orig, byte[,] pred)
        {
            for (var i = 0; i < 256; i++)
            {
                for (var j = 0; j < 256; j++)
                {
                    if ((i == 0) && (j == 0))
                    {
                        pred[i, j] = 128;
                    }
                    else if ((i == 0) && (j != 0))
                    {
                        pred[i, j] = orig[i, j - 1];
                    }
                    else if ((i != 0) && (j == 0))
                    {
                        pred[i, j] = orig[i - 1, j];
                    }
                    else
                    {
                        pred[i, j] = orig[i - 1, j];
                    }
                }
            }
        }

        public void PreditieC(byte[,] orig, byte[,] pred)
        {
            for (var i = 0; i < 256; i++)
            {
                for (var j = 0; j < 256; j++)
                {
                    if ((i == 0) && (j == 0))
                    {
                        pred[i, j] = 128;
                    }
                    else if ((i == 0) && (j != 0))
                    {
                        pred[i, j] = orig[i, j - 1];
                    }
                    else if ((i != 0) && (j == 0))
                    {
                        pred[i, j] = orig[i - 1, j];
                    }
                    else
                    {
                        pred[i, j] = orig[i - 1, j - 1];
                    }
                }
            }
        }

        public void PreditieABC1(byte[,] orig, byte[,] pred)
        {
            for (var i = 0; i < 256; i++)
            {
                for (var j = 0; j < 256; j++)
                {
                    if ((i == 0) && (j == 0))
                    {
                        pred[i, j] = 128;
                    }
                    else if ((i == 0) && (j != 0))
                    {
                        pred[i, j] = orig[i, j - 1];
                    }
                    else if ((i != 0) && (j == 0))
                    {
                        pred[i, j] = orig[i - 1, j];
                    }
                    else if ((i != 0) && (j != 0))
                    {
                        int aux = orig[i, j - 1] + orig[i - 1, j] - orig[i - 1, j - 1];
                        pred[i, j] = AproximareInterval(aux);
                    }
                }
            }
        }

        public void PreditieABC2(byte[,] orig, byte[,] pred)
        {
            for (var i = 0; i < 256; i++)
            {
                for (var j = 0; j < 256; j++)
                {
                    if ((i == 0) && (j == 0))
                    {
                        pred[i, j] = 128;
                    }
                    else if ((i == 0) && (j != 0))
                    {
                        pred[i, j] = orig[i, j - 1];
                    }
                    else if ((i != 0) && (j == 0))
                    {
                        pred[i, j] = orig[i - 1, j];
                    }
                    else if ((i != 0) && (j != 0))
                    {
                        int aux = orig[i, j - 1] + (orig[i - 1, j] - orig[i - 1, j - 1]) / 2;
                        pred[i, j] = AproximareInterval(aux);
                    }
                }
            }
        }
        public void PreditieABC3(byte[,] orig, byte[,] pred)
        {
            for (var i = 0; i < 256; i++)
            {
                for (var j = 0; j < 256; j++)
                {
                    if ((i == 0) && (j == 0))
                    {
                        pred[i, j] = 128;
                    }
                    else if ((i == 0) && (j != 0))
                    {
                        pred[i, j] = orig[i, j - 1];
                    }
                    else if ((i != 0) && (j == 0))
                    {
                        pred[i, j] = orig[i - 1, j];
                    }
                    else if ((i != 0) && (j != 0))
                    {
                        int aux = orig[i - 1, j] + (orig[i, j - 1] - orig[i - 1, j - 1]) / 2;
                        pred[i, j] = AproximareInterval(aux);
                    }
                }
            }
        }

        public void PreditieAB(byte[,] orig, byte[,] pred)
        {
            for (var i = 0; i < 256; i++)
            {
                for (var j = 0; j < 256; j++)
                {
                    if ((i == 0) && (j == 0))
                    {
                        pred[i, j] = 128;
                    }
                    else if ((i == 0) && (j != 0))
                    {
                        pred[i, j] = orig[i, j - 1];
                    }
                    else if ((i != 0) && (j == 0))
                    {
                        pred[i, j] = orig[i - 1, j];
                    }
                    else if ((i != 0) && (j != 0))
                    {
                        int aux = (orig[i - 1, j] + orig[i, j - 1]) / 2;
                        pred[i, j] = AproximareInterval(aux);
                    }
                }
            }
        }

        public void PreditiejpegLS(byte[,] orig, byte[,] pred)
        {
            for (var i = 0; i < 256; i++)
            {
                for (var j = 0; j < 256; j++)
                {
                    if ((i == 0) && (j == 0))
                    {
                        pred[i, j] = 128;
                    }
                    else if ((i == 0) && (j != 0))
                    {
                        pred[i, j] = orig[i, j - 1];
                    }
                    else if ((i != 0) && (j == 0))
                    {
                        pred[i, j] = orig[i - 1, j];
                    }
                    else if ((i != 0) && (j != 0))
                    {

                        int aux = orig[i, j - 1] + orig[i - 1, j] - orig[i - 1, j - 1];

                        if (aux < 0)
                        {
                            pred[i, j] = 0;
                        }
                        else if (aux > 255)
                        {
                            pred[i, j] = 255;
                        }
                        else
                        {
                            if (orig[i - 1, j - 1] >= Math.Max(orig[i, j - 1], orig[i - 1, j]))
                            {
                                pred[i, j] = Math.Min(orig[i, j - 1], orig[i - 1, j]);
                            }
                            else if (orig[i - 1, j - 1] <= Math.Min(orig[i, j - 1], orig[i - 1, j]))
                            {
                                pred[i, j] = Math.Max(orig[i, j - 1], orig[i - 1, j]);
                            }
                            else
                            {
                                pred[i, j] = (byte)aux;
                            }
                        }
                    }
                }
            }
        }

        public void DecodePreditie128(byte[,] orig, byte[,] pred, int[,] error)
        {
            for (var i = 0; i < 256; i++)
            {
                for (var j = 0; j < 256; j++)
                {
                    pred[i, j] = 128;
                    orig[i, j] = (byte)(error[i, j] + pred[i, j]);
                }
            }
        }
        public void DecodePreditieA(byte[,] orig, byte[,] pred, int[,] error)
        {
            for (var i = 0; i < 256; i++)
            {
                for (var j = 0; j < 256; j++)
                {
                    if ((i == 0) && (j == 0))
                    {
                        pred[i, j] = 128;
                        orig[i, j] = (byte)(error[i, j] + pred[i, j]);
                    }
                    else if ((i == 0) && (j != 0))
                    {
                        pred[i, j] = orig[i, j - 1];
                        orig[i, j] = (byte)(error[i, j] + pred[i, j]);
                    }
                    else if ((i != 0) && (j == 0))
                    {
                        pred[i, j] = orig[i - 1, j];
                        orig[i, j] = (byte)(error[i, j] + pred[i, j]);
                    }
                    else
                    {
                        pred[i, j] = orig[i, j - 1];
                        orig[i, j] = (byte)(error[i, j] + pred[i, j]);
                    }
                }
            }
        }
        public void DecodePreditieB(byte[,] orig, byte[,] pred, int[,] error)
        {
            for (var i = 0; i < 256; i++)
            {
                for (var j = 0; j < 256; j++)
                {
                    if ((i == 0) && (j == 0))
                    {
                        pred[i, j] = 128;
                        orig[i, j] = (byte)(error[i, j] + pred[i, j]);
                    }
                    else if ((i == 0) && (j != 0))
                    {
                        pred[i, j] = orig[i, j - 1];
                        orig[i, j] = (byte)(error[i, j] + pred[i, j]);
                    }
                    else if ((i != 0) && (j == 0))
                    {
                        pred[i, j] = orig[i - 1, j];
                        orig[i, j] = (byte)(error[i, j] + pred[i, j]);
                    }
                    else
                    {
                        pred[i, j] = orig[i - 1, j];
                        orig[i, j] = (byte)(error[i, j] + pred[i, j]);
                    }
                }
            }
        }

        public void DecodePreditieC(byte[,] orig, byte[,] pred, int[,] error)
        {
            for (var i = 0; i < 256; i++)
            {
                for (var j = 0; j < 256; j++)
                {
                    if ((i == 0) && (j == 0))
                    {
                        pred[i, j] = 128;
                        orig[i, j] = (byte)(error[i, j] + pred[i, j]);
                    }
                    else if ((i == 0) && (j != 0))
                    {
                        pred[i, j] = orig[i, j - 1];
                        orig[i, j] = (byte)(error[i, j] + pred[i, j]);
                    }
                    else if ((i != 0) && (j == 0))
                    {
                        pred[i, j] = orig[i - 1, j];
                        orig[i, j] = (byte)(error[i, j] + pred[i, j]);
                    }
                    else
                    {
                        pred[i, j] = orig[i - 1, j - 1];
                        orig[i, j] = (byte)(error[i, j] + pred[i, j]);
                    }
                }
            }
        }

        public void DecodePreditieABC1(byte[,] orig, byte[,] pred, int[,] error)
        {
            for (var i = 0; i < 256; i++)
            {
                for (var j = 0; j < 256; j++)
                {
                    if ((i == 0) && (j == 0))
                    {
                        pred[i, j] = 128;
                        orig[i, j] = (byte)(error[i, j] + pred[i, j]);
                    }
                    else if ((i == 0) && (j != 0))
                    {
                        pred[i, j] = orig[i, j - 1];
                        orig[i, j] = (byte)(error[i, j] + pred[i, j]);
                    }
                    else if ((i != 0) && (j == 0))
                    {
                        pred[i, j] = orig[i - 1, j];
                        orig[i, j] = (byte)(error[i, j] + pred[i, j]);
                    }
                    else if ((i != 0) && (j != 0))
                    {
                        int aux = orig[i, j - 1] + orig[i - 1, j] - orig[i - 1, j - 1];
                        pred[i, j] = AproximareInterval(aux);
                        orig[i, j] = (byte)(error[i, j] + pred[i, j]);
                    }
                }
            }
        }

        public void DecodePreditieABC2(byte[,] orig, byte[,] pred, int[,] error)
        {
            for (var i = 0; i < 256; i++)
            {
                for (var j = 0; j < 256; j++)
                {
                    if ((i == 0) && (j == 0))
                    {
                        pred[i, j] = 128;
                        orig[i, j] = (byte)(error[i, j] + pred[i, j]);
                    }
                    else if ((i == 0) && (j != 0))
                    {
                        pred[i, j] = orig[i, j - 1];
                        orig[i, j] = (byte)(error[i, j] + pred[i, j]);
                    }
                    else if ((i != 0) && (j == 0))
                    {
                        pred[i, j] = orig[i - 1, j];
                        orig[i, j] = (byte)(error[i, j] + pred[i, j]);
                    }
                    else if ((i != 0) && (j != 0))
                    {
                        int aux = orig[i, j - 1] + (orig[i - 1, j] - orig[i - 1, j - 1]) / 2;
                        pred[i, j] = AproximareInterval(aux);
                        orig[i, j] = (byte)(error[i, j] + pred[i, j]);
                    }
                }
            }
        }
        public void DecodePreditieABC3(byte[,] orig, byte[,] pred, int[,] error)
        {
            for (var i = 0; i < 256; i++)
            {
                for (var j = 0; j < 256; j++)
                {
                    if ((i == 0) && (j == 0))
                    {
                        pred[i, j] = 128;
                        orig[i, j] = (byte)(error[i, j] + pred[i, j]);
                    }
                    else if ((i == 0) && (j != 0))
                    {
                        pred[i, j] = orig[i, j - 1];
                        orig[i, j] = (byte)(error[i, j] + pred[i, j]);
                    }
                    else if ((i != 0) && (j == 0))
                    {
                        pred[i, j] = orig[i - 1, j];
                        orig[i, j] = (byte)(error[i, j] + pred[i, j]);
                    }
                    else if ((i != 0) && (j != 0))
                    {
                        int aux = orig[i - 1, j] + (orig[i, j - 1] - orig[i - 1, j - 1]) / 2;
                        pred[i, j] = AproximareInterval(aux);
                        orig[i, j] = (byte)(error[i, j] + pred[i, j]);
                    }
                }
            }
        }

        public void DecodePreditieAB(byte[,] orig, byte[,] pred, int[,] error)
        {
            for (var i = 0; i < 256; i++)
            {
                for (var j = 0; j < 256; j++)
                {
                    if ((i == 0) && (j == 0))
                    {
                        pred[i, j] = 128;
                        orig[i, j] = (byte)(error[i, j] + pred[i, j]);
                    }
                    else if ((i == 0) && (j != 0))
                    {
                        pred[i, j] = orig[i, j - 1];
                        orig[i, j] = (byte)(error[i, j] + pred[i, j]);
                    }
                    else if ((i != 0) && (j == 0))
                    {
                        pred[i, j] = orig[i - 1, j];
                        orig[i, j] = (byte)(error[i, j] + pred[i, j]);
                    }
                    else if ((i != 0) && (j != 0))
                    {
                        int aux = (orig[i - 1, j] + orig[i, j - 1]) / 2;
                        pred[i, j] = AproximareInterval(aux);
                        orig[i, j] = (byte)(error[i, j] + pred[i, j]);
                    }
                }
            }
        }

        public void DecodePreditiejpegLS(byte[,] orig, byte[,] pred, int[,] error)
        {
            for (var i = 0; i < 256; i++)
            {
                for (var j = 0; j < 256; j++)
                {
                    if ((i == 0) && (j == 0))
                    {
                        pred[i, j] = 128;
                        orig[i, j] = (byte)(error[i, j] + pred[i, j]);
                    }
                    else if ((i == 0) && (j != 0))
                    {
                        pred[i, j] = orig[i, j - 1];
                        orig[i, j] = (byte)(error[i, j] + pred[i, j]);
                    }
                    else if ((i != 0) && (j == 0))
                    {
                        pred[i, j] = orig[i - 1, j];
                        orig[i, j] = (byte)(error[i, j] + pred[i, j]);
                    }
                    else if ((i != 0) && (j != 0))
                    {

                        int aux = orig[i, j - 1] + orig[i - 1, j] - orig[i - 1, j - 1];

                        if (aux < 0)
                        {
                            pred[i, j] = 0;
                            orig[i, j] = (byte)(error[i, j] + pred[i, j]);
                        }
                        else if (aux > 255)
                        {
                            pred[i, j] = 255;
                            orig[i, j] = (byte)(error[i, j] + pred[i, j]);
                        }
                        else
                        {
                            if (orig[i - 1, j - 1] >= Math.Max(orig[i, j - 1], orig[i - 1, j]))
                            {
                                pred[i, j] = Math.Min(orig[i, j - 1], orig[i - 1, j]);
                                orig[i, j] = (byte)(error[i, j] + pred[i, j]);
                            }
                            else if (orig[i - 1, j - 1] <= Math.Min(orig[i, j - 1], orig[i - 1, j]))
                            {
                                pred[i, j] = Math.Max(orig[i, j - 1], orig[i - 1, j]);
                                orig[i, j] = (byte)(error[i, j] + pred[i, j]);
                            }
                            else
                            {
                                pred[i, j] = (byte)aux;
                                orig[i, j] = (byte)(error[i, j] + pred[i, j]);
                            }
                        }
                    }
                }
            }
        }

        public byte AproximareInterval(int val)
        {
            if (val < 0)
            {
                return 0;
            }
            else if (val > 255)
            {
                return 255;
            }
            else
            {
                return (byte)val;
            }
        }
    }
}
