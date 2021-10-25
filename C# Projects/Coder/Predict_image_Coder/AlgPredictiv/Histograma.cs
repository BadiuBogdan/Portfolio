using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgPredictiv
{
    class Histograma
    {
        public int[] FunctieHistograma(int[,] mat)
        {
            int[] histogram = new int[512];
            for (var i = 0; i < 256; i++)
            {
                for (var j = 0; j < 256; j++)
                {
                    histogram[mat[i, j] + 256]++;
                }
            }
            return histogram;
        }
        public int[] FunctieHistograma(byte[,] mat)
        {
            int[] histogram = new int[512];
            for (var i = 0; i < 256; i++)
            {
                for (var j = 0; j < 256; j++)
                {
                    histogram[mat[i, j] + 256]++;
                }
            }
            return histogram;
        }
    }
}
